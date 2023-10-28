using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] obstaclePrefabs;

    private Vector3 spawnPosition = new Vector3(25, 0, 0);
    private float spawnDelay = 2;
    private float spwanRepeatRate = 2;
    private PlayerController playerController;

    // Start is called before the first frame update
    void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        InvokeRepeating("SpawnObstacle", spawnDelay, spwanRepeatRate);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnObstacle()
    {
        if (!playerController.gameOver && !playerController.startAnimation)
        {
            var index = Random.Range(0, obstaclePrefabs.Length);
            var obstaclePrefab = obstaclePrefabs[index];

            Instantiate(obstaclePrefab, spawnPosition, obstaclePrefab.transform.rotation);
        }
    }
}
