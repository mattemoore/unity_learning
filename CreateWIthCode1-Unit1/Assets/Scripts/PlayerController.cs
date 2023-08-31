using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float speed = 10.0f;
    private float turnSpeed = 20.0f;
    private float horizontalInput;
    private float verticalInput;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Move vehicle forward
        // NOTE: The `20` here actually translates to meters/s
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        this.transform.Translate(Vector3.forward * Time.deltaTime * this.speed * verticalInput);
        this.transform.Rotate(Vector3.up * Time.deltaTime * this.turnSpeed * horizontalInput);
    }
}
