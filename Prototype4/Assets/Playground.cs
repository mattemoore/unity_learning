using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playground : MonoBehaviour
{

    public GameObject missilePrefab;
    public GameObject focalPoint;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        // TODO: Only shoot missiles while `hasMissilePowerup` is true
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // fire missile
            GameObject missile = Instantiate(missilePrefab, this.transform.position, missilePrefab.transform.rotation);
            //Vector3 target = new Vector3(0, 50, 0);
            //missile.transform.Rotate(0, 90, 0, Space.World);
            missile.transform.Rotate(0, focalPoint.transform.rotation.eulerAngles.y, 0, Space.World);
            missile.GetComponent<Rigidbody>().AddForce(focalPoint.transform.forward * 15);
        }

    }
}
