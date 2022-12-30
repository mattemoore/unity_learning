using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject obstaclePrefab;
    private Vector3 spawnPosition = new Vector3(20, 0, 0);
    private float spawnDelay = 2;
    private float repeatRate = 2;
    private PlayerController playerController;
    void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        InvokeRepeating("SpawnObstacle", spawnDelay, repeatRate);
    }

    void Update()
    {

    }

    void SpawnObstacle()
    {
        if (!playerController.gameOver)
            Instantiate(obstaclePrefab, new Vector3(this.transform.position.x, 0, 0), obstaclePrefab.transform.rotation);
    }
}
