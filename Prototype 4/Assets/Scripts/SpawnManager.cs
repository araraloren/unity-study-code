using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject powerUpPrefab;

    public int enemyCount = 0;
    public int waveNumber = 1;

    private float spawnRange = 9.0f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (enemyCount == 0)
        {
            enemyCount += waveNumber;
            Debug.Log("spawn new enemy wave and new power up");
            SpawnPowerUpWave();
            SpawnEnemyWave(waveNumber++);
        }
    }

    void SpawnEnemyWave(int enemiesToSpawn)
    {
        for (int i = 0;i < enemiesToSpawn; i++)
        {
            Instantiate(enemyPrefab, GenerateSpawnPosition(), enemyPrefab.transform.rotation);
        }
    }

    void SpawnPowerUpWave()
    {
        Instantiate(powerUpPrefab, GenerateSpawnPosition(), enemyPrefab.transform.rotation);
    }

    private Vector3 GenerateSpawnPosition()
    {
        float x = Random.Range(-spawnRange, spawnRange);
        float z = Random.Range(-spawnRange, spawnRange);

        return new Vector3(x, 0.1f, z);
    }
}
