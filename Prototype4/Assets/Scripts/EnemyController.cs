using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private GameObject player;
    private Rigidbody rb;
    public float speed = 1.0f;
    void Start()
    {
        player = GameObject.Find("Player");
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Vector3 lookDirection = (player.transform.position - this.transform.position).normalized;
        rb.AddForce(lookDirection * speed);

        if (transform.position.y < -10)
        {
            Destroy(this.gameObject);
        }
    }
}
