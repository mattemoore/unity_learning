using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyController : MonoBehaviour
{
    public float speed = 1.0f;
    public float hardSpeedMultiplier = 5;
    public bool isHard = false;
    private GameObject player;
    private Rigidbody rb;

    void Start()
    {
        player = GameObject.Find("Player");
        rb = GetComponent<Rigidbody>();
        isHard = Convert.ToBoolean(UnityEngine.Random.Range(0, 2));
        if (isHard)
        {
            gameObject.GetComponent<Renderer>().material.color = new Color(0, 0.78f, 0, 1);
        }
    }

    void Update()
    {
        Vector3 lookDirection = (player.transform.position - this.transform.position).normalized;
        float totalSpeed = (isHard) ? speed * hardSpeedMultiplier : speed;
        // TODO: Reenable this
        // rb.AddForce(lookDirection * totalSpeed);

        if (transform.position.y < -10)
        {
            Destroy(this.gameObject);
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Missile"))
        {
            Destroy(other.gameObject);
        }
    }
}
