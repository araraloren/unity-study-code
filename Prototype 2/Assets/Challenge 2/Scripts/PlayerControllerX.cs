using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public GameObject dogPrefab;

    public float spawnDelay = 2.0f;
    private bool spawnDog = true;

    // Update is called once per frame
    void Update()
    {
        // On spacebar press, send dog
        if (spawnDog && Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(dogPrefab, transform.position, dogPrefab.transform.rotation);
            spawnDog = false;
            Invoke("DelayAfterSpawn", spawnDelay);
        }
    }

    void DelayAfterSpawn()
    {
        spawnDog = true;
    }
}
