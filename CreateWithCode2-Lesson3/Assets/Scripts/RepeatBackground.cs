using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBackground : MonoBehaviour
{
    private Vector3 startPos;
    private BoxCollider boxCollider;

    void Start()
    {
       startPos = transform.position;
       boxCollider = GetComponent<BoxCollider>();
    }

    void Update()
    {
        if (transform.position.x < (startPos.x - boxCollider.size.x / 2)) {
            transform.position = startPos;
        }
    }
}
