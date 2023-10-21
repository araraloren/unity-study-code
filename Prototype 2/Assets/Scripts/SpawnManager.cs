using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] animalPrefabs;

    public float spawnPosMinX = -20.0f;
    public float spawnPosMaxX = 20.0f;
    public float spawnPosMinY = 0.0f;
    public float spawnPosMaxY = 0.0f;
    public float spawnPosMinZ = 4.5f;
    public float spawnPosMaxZ = 15.0f;

    public Vector3 rotation = new Vector3(0.0f, 0.0f, 0.0f);

    private float startDelay = 2.0f;
    private float spawnInterval = 1.5f;

    private PlayerInfos playerInfos;

    // Start is called before the first frame update
    void Start()
    {
        playerInfos = GetComponent<PlayerReference>().playerInfos;
        InvokeRepeating("SpawnRandomAnimal", startDelay, spawnInterval);
    }

    void SpawnRandomAnimal()
    {

        int index = Random.Range(0, animalPrefabs.Length);
        var animal = animalPrefabs[index];
        var x = Random.Range(spawnPosMinX, spawnPosMaxX);
        var y = Random.Range(spawnPosMinY, spawnPosMaxY);
        var z = Random.Range(spawnPosMinZ, spawnPosMaxZ);
        var obj = Instantiate(animal, new Vector3(x, y, z), animal.transform.rotation);

        obj.transform.Rotate(rotation);
        obj.GetComponent<PlayerReference>().setPlayer(playerInfos);
    }
}
