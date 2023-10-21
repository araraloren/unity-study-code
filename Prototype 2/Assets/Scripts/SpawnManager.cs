using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] animalPrefabs;

    private float spawnTopRangeX = 20.0f;
    private float spawnPositionZ = 20.0f;

    private float spawnRangeMinZ = 4.5f;
    private float spawnRangeMaxZ = 15.0f;
    private float spawnPositionX = 25.0f;

    private float startDelay = 2.0f;
    private float spawnInterval = 1.5f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnRandomAnimal", startDelay, spawnInterval);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SpawnRandomAnimal()
    {
        int index = Random.Range(0, animalPrefabs.Length);
        var animal = animalPrefabs[index];
        var spawnPos = new Vector3(Random.Range(-spawnTopRangeX, spawnTopRangeX), 0, spawnPositionZ);

        Instantiate(animal, spawnPos, animal.transform.rotation);

        int indexLeft = Random.Range(0, animalPrefabs.Length);
        var animalLeft = animalPrefabs[indexLeft];
        var spawnPosLeft = new Vector3(-spawnPositionX, 0, Random.Range(spawnRangeMinZ, spawnRangeMaxZ));
        var instanceLeft = Instantiate(animalLeft, spawnPosLeft, animalLeft.transform.rotation);

        instanceLeft.transform.Rotate(0.0f, -90.0f, 0.0f);

        int indexRight = Random.Range(0, animalPrefabs.Length);
        var animalRight = animalPrefabs[indexRight];
        var spawnPosRight = new Vector3(spawnPositionX, 0, Random.Range(spawnRangeMinZ, spawnRangeMaxZ));
        var instanceRight = Instantiate(animalRight, spawnPosRight, animalRight.transform.rotation);

        instanceRight.transform.Rotate(0.0f, 90.0f, 0.0f);
    }
}
