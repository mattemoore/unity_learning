using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] animalPrefabs;
    public int minXSpawn = -10;
    public int maxXSpawn = 10;
    public int minZSpawn = 15;
    public int maxZSpawn = 30;
    private float spawnDelay = 2;
    private float spawnTimer = 1.5f;

    void Start()
    {
        InvokeRepeating("SpawnRandomAnimal", spawnDelay, spawnTimer);
    }

    // Update is called once per frame
    void Update()
    {
    }

    void SpawnRandomAnimal() {
         var xSpawn = Random.Range(minXSpawn, maxXSpawn);
        var zSpawn = Random.Range(minZSpawn, maxZSpawn);
        var rotSpawn = new Quaternion(0, 180, 0, 0);
        Instantiate(animalPrefabs[Random.Range(0, animalPrefabs.Length)], 
            new Vector3(xSpawn, 0, zSpawn), 
            rotSpawn);
    }
}
