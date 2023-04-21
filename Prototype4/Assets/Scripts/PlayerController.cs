using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject forcePowerUpIndicator;
    public GameObject missilePowerUpIndicator;
    public GameObject missilePrefab;
    public float speed = 1.0f;
    public bool hasForcePowerup = false;
    public bool hasMissilePowerup = false;
    public float forcePowerupStrength = 15.0f;
    public float forcePowerupTime = 7;
    public float missilePowerupTime = 5;
    public float missileSpeed = 30;
    public float missileForce = 10;
    private Rigidbody rb;
    private GameObject focalPoint;

    // TODO: Create Missile script that adds force to enemy oncollision

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("Focal Point");
    }

    void Update()
    {
        float forwardInput = Input.GetAxis("Vertical");
        rb.AddForce(focalPoint.transform.forward * speed * forwardInput);
        forcePowerUpIndicator.transform.position = this.transform.position;
        missilePowerUpIndicator.transform.position = this.transform.position;

        if (Input.GetKeyDown(KeyCode.Space)) /* TODO: && hasMissilePowerup*/
        {
            // fire missiles
            GameObject missile = Instantiate(missilePrefab, this.transform.position, missilePrefab.transform.rotation);
            missile.transform.Rotate(0, focalPoint.transform.rotation.eulerAngles.y, 0, Space.World);
            missile.GetComponent<Rigidbody>().AddForce(focalPoint.transform.forward * missileSpeed);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ForcePowerup"))
        {
            hasForcePowerup = true;
            Destroy(other.gameObject);
            forcePowerUpIndicator.SetActive(true);
            StartCoroutine(ForcePowerUpRoutine());
        }

        if (other.CompareTag("MissilePowerup"))
        {
            hasMissilePowerup = true;
            Destroy(other.gameObject);
            missilePowerUpIndicator.SetActive(true);
            StartCoroutine(MissilePowerUpRoutine());
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Enemy") && hasForcePowerup)
        {
            Rigidbody enemyRb = other.gameObject.GetComponent<Rigidbody>();
            Vector3 forceDirection = (other.gameObject.transform.position - this.transform.position).normalized;
            enemyRb.AddForce(forceDirection * forcePowerupStrength, ForceMode.Impulse);
        }
        Debug.Log($"Collision with {other.gameObject.name} and power set to: {hasForcePowerup}");
    }

    IEnumerator ForcePowerUpRoutine()
    {
        yield return new WaitForSeconds(forcePowerupTime);
        hasForcePowerup = false;
        forcePowerUpIndicator.SetActive(false);
    }
    IEnumerator MissilePowerUpRoutine()
    {
        yield return new WaitForSeconds(missilePowerupTime);
        hasMissilePowerup = false;
        missilePowerUpIndicator.SetActive(false);
    }
}
