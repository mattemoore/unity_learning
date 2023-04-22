using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public float minSpeed = 12;
    public float maxSpeed = 16;
    public float minTorque = -10;
    public float maxTorque = 10;
    public float minXPos = -4;
    public float maxXPos = 4;
    public float yPos = -6;
    public int pointValue;
    public ParticleSystem explosionParticle;
    private Rigidbody rb;
    private GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        rb.AddForce(GetRandomForce(minSpeed, maxSpeed), ForceMode.Impulse);
        rb.AddTorque(GetRandomTorque(minTorque, maxTorque), ForceMode.Impulse);
        rb.transform.position = new Vector3(Random.Range(minXPos, maxXPos), yPos);
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnMouseDown()
    {
        Destroy(this.gameObject);
        gameManager.UpdateScore(pointValue);
        Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);
    }

    public void OnTriggerEnter(Collider other)
    {
        Destroy(this.gameObject);
        if (!gameObject.CompareTag("Bad"))
        {
            gameManager.EndGame();
        }
    }

    Vector3 GetRandomForce(float min, float max)
    {
        return Vector3.up * Random.Range(min, max);
    }

    Vector3 GetRandomTorque(float min, float max)
    {
        return new Vector3(Random.Range(min, max), Random.Range(min, max), Random.Range(min, max));
    }
}
