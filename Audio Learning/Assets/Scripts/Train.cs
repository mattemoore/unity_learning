using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Train : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float x_movement = -0.70f * Time.deltaTime;
        this.transform.position += new Vector3(x_movement, 0, 0);
    }
}
