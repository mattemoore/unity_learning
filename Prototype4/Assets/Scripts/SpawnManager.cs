using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject powerupPrefab;
    public int enemyCount = 0;
    public int waveNumber = 0;
    private float maxSpawnDistanceFromOrigin = 8;
    void Start()
    {
        // StartNextWave();
    }

    void Update()
    {
        enemyCount = FindObjectsOfType<EnemyController>().Length;
        if (enemyCount == 0)
        {
            StartNextWave();
        }
    }

    void StartNextWave()
    {
        waveNumber++;
        SpawnEnemies(waveNumber);
        SpawnPowerUp();
    }

    Vector3 GetRandomSpawnPoint()
    {
        float randomSpawnDistance = Random.Range(maxSpawnDistanceFromOrigin * -1, maxSpawnDistanceFromOrigin);
        Vector3 randomSpawnPoint = new Vector3(randomSpawnDistance, 0, randomSpawnDistance);
        return randomSpawnPoint;
    }

    void SpawnPowerUp()
    {
        Instantiate(powerupPrefab, GetRandomSpawnPoint(), powerupPrefab.transform.rotation);
    }

    void SpawnEnemies(int numToSpawn)
    {
        Debug.Log(numToSpawn);
        for (int i = 0; i < numToSpawn; i++)
        {
            Instantiate(enemyPrefab, GetRandomSpawnPoint(), enemyPrefab.transform.rotation);
        }
    }

}