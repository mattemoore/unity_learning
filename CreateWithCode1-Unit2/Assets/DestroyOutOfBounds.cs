using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    // Start is called before the first frame update
    private float topBound = 30;
    private float lowerBound = -15;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (this.transform.position.z > topBound)
        {
            Destroy(gameObject);
        }
        else if (this.transform.position.z < lowerBound) { ShowGameOver(); }
    }

    private void ShowGameOver()
    {
        Debug.Log("Game Over!");
        Destroy(gameObject);
    }
}
