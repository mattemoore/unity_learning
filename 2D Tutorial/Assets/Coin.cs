using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public Collider2D goalCollider;
    private Collider2D thisCollider;

    // Start is called before the first frame update
    void Start()
    {
        // Set random start point within acceptable range x 110 to 120
        Vector3 currentPos = this.transform.position;
        var randomDeltaPosX = Random.Range(-4.0f, 4.0f);
        Debug.LogWarning(randomDeltaPosX);
        this.transform.position += new Vector3(randomDeltaPosX, 0);
    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("Collision triggered");
        if (other.collider == goalCollider)
        {
            Debug.Log("Destroying this");
            Destroy(this.gameObject);
        }
    }
}
