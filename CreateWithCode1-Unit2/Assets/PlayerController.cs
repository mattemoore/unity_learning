using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 10.0f;
    private float horizontalInput;
    private float horizontalBounds = 10.0f;

    void Start()
    {

    }

    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        this.transform.position += (Vector3.right * Time.deltaTime * speed * horizontalInput);
        if (this.transform.position.x < -horizontalBounds)
        {
            this.transform.position = new Vector3(-horizontalBounds, this.transform.position.y, this.transform.position.z);
        }
        if (this.transform.position.x > horizontalBounds)
        {
            this.transform.position = new Vector3(horizontalBounds, this.transform.position.y, this.transform.position.z);
        }
    }
}