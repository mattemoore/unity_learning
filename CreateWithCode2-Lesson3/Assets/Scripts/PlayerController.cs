using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    private Animator animator;
    private AudioSource playerAudio;
    public PlayerIntro playerIntro;
    public ParticleSystem explosionParticles;
    public ParticleSystem dirtParticles;
    public AudioClip jumpSound;
    public AudioClip crashSound;
    public float jumpForce;
    public float gravityModifier;
    public bool isOnGround = true;
    public bool gameOver = false;
    public bool isPlayerDashing = false;
    public float DASHTIME_CONST = 5;
    public int DASHTIME_DECAY = 1;
    public int DASH_ANIM_MULT = 3;
    public float dashTimeRemaining = 0;
    public int numJumps = 0;

    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
        playerIntro = GetComponent<PlayerIntro>();
        Physics.gravity *= gravityModifier;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && numJumps < 2 && !gameOver)
        {
            numJumps += 1;
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
            animator.SetTrigger("Jump_trig");
            dirtParticles.Stop();
            playerAudio.PlayOneShot(jumpSound, 1.0f);
        }

        // TODO: Future projects put dash into it's own script so that it can be reused
        if (Input.GetKeyDown(KeyCode.C) && !isPlayerDashing)
        {
            startDash();
        }
        if (isPlayerDashing)
        {
            updateDash();
        }
    }

    void startDash()
    {
        Debug.Log("Starting dash...");
        isPlayerDashing = true;
        dashTimeRemaining = DASHTIME_CONST;
        animator.SetFloat("Speed_f", DASH_ANIM_MULT);
    }

    void updateDash()
    {
        dashTimeRemaining -= Time.deltaTime * DASHTIME_DECAY;
        if (dashTimeRemaining < 0)
        {
            endDash();
        }
        Debug.Log(dashTimeRemaining);
    }

    void endDash()
    {
        Debug.Log("Ending dash...");
        isPlayerDashing = false;
        animator.SetFloat("Speed_f", 1);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("GameOver!!!!");
            dirtParticles.Stop();
            explosionParticles.Play();
            playerAudio.PlayOneShot(crashSound, 1.0f);
            gameOver = true;
            animator.SetBool("Death_b", true);
            animator.SetInteger("DeathType_int", 1);
        }
        else
        {
            isOnGround = true;
            numJumps = 0;
            dirtParticles.Play();
        }
    }
}
