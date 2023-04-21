using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCamera : MonoBehaviour
{
    public float rotationSpeed = 3.0f;
    void Start()
    {

    }

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        this.transform.Rotate(Vector3.up, horizontalInput * rotationSpeed * Time.deltaTime);
    }
}
