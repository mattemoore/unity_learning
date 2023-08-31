using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TrailRenderer), typeof(BoxCollider))]
public class ClickAndSwipe : MonoBehaviour
{
    private GameManager gameManager;
    private Camera cam;
    private Vector3 mousePos;
    private TrailRenderer trailRenderer;
    private BoxCollider boxCollider;
    private AudioSource swipeSound;
    private bool isSwiping;
    void Awake()
    {
        cam = Camera.main;
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        trailRenderer = GetComponent<TrailRenderer>();
        boxCollider = GetComponent<BoxCollider>();
        trailRenderer.enabled = false;
        boxCollider.enabled = false;
        swipeSound = GetComponent<AudioSource>();
    }

    void UpdateMousePosition()
    {
        // -10 is z position of camera in scene
        mousePos = cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10.0f));
        transform.position = mousePos;
    }

    void UpdateComponents()
    {
        trailRenderer.enabled = isSwiping;
        boxCollider.enabled = isSwiping;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.isGameRunning)
        {
            if (Input.GetMouseButtonDown(0))
            {
                isSwiping = true;
                UpdateComponents();
            }
            else if (Input.GetMouseButtonUp(0))
            {
                isSwiping = false;
                UpdateComponents();
            }
            if (isSwiping)
            {
                swipeSound.Play();
                UpdateMousePosition();
            }
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        Target target = other.gameObject.GetComponent<Target>();
        if (target)
        {
            target.DestroyTarget();
        }
    }
}
