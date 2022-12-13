using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public GameObject dogPrefab;
    public float lastFireTime;

    // Update is called once per frame
    void Update()
    {
        // On spacebar press, send dog
        if (Input.GetKeyDown(KeyCode.Space) && Time.time - lastFireTime > 1.0f)
        {
            Instantiate(dogPrefab, transform.position, dogPrefab.transform.rotation);
            lastFireTime = Time.time;
        }
    }
}
