using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] enemyPrefabs;
    public GameObject powerUpPrefab;
    public GameObject bulletPrefab;

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
            var val = Random.Range(0, 2.0f);

            enemyCount += waveNumber;
            Debug.Log("spawn new enemy wave and new power up");
            if (val > 1.0f)
            {
                SpawnPowerUpWave();
            }
            else
            {
                SpawnBulletWave();
            }
            SpawnEnemyWave(waveNumber++);
        }
    }

    void SpawnEnemyWave(int enemiesToSpawn)
    {
        for (int i = 0;i < enemiesToSpawn; i++)
        {
            var j = Random.Range(0, enemyPrefabs.Length);

            Instantiate(enemyPrefabs[j], GenerateSpawnPosition(), enemyPrefabs[j].transform.rotation);
        }
    }

    void SpawnPowerUpWave()
    {
        Instantiate(powerUpPrefab, GenerateSpawnPosition(), powerUpPrefab.transform.rotation);
    }

    void SpawnBulletWave()
    {
        Instantiate(bulletPrefab, GenerateSpawnPosition(), bulletPrefab.transform.rotation);
    }

    private Vector3 GenerateSpawnPosition()
    {
        float x = Random.Range(-spawnRange, spawnRange);
        float z = Random.Range(-spawnRange, spawnRange);

        return new Vector3(x, 0.1f, z);
    }
}
