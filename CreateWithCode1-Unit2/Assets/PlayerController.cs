using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 10.0f;
    public GameObject projectilePrefab;
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

        // NOTE: Can only instantiate prefabs
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(projectilePrefab, new Vector3(this.transform.position.x, this.transform.position.y + 1, this.transform.position.z), this.transform.rotation);
        }
    }
}