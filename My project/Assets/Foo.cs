using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Foo : MonoBehaviour
{
    public string MyMessage = "";
    public Vector3 scaleChange;
    // Start is called before the first frame update
    void Start()
    {
         Debug.Log("bar");
    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale += new Vector3(0, scaleChange.y * Time.deltaTime,0);
        transform.position += (scaleChange * Time.deltaTime);
        transform.Rotate(scaleChange * Time.deltaTime);
    }
}
