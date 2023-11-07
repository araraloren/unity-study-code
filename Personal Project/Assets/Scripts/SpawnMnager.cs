using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMnager : MonoBehaviour
{
    public GameObject enemyPrefab;

    public float zMinBound = 0;
    public float zMaxBound = 0;
    public float xMinBound = -14;
    public float xMaxBound = 14;
    public float speedMulti = 1.0f;
    public float speedIncrement = 0.1f;

    private bool leftDirection = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var objs = GameObject.FindGameObjectsWithTag("Enemy");

        if (objs.Length == 0)
        {
            var x = leftDirection ? xMaxBound : xMinBound;
            var z = Random.Range(zMinBound, zMaxBound);
            var pos = new Vector3(x, transform.position.y, z);
            var obj = Instantiate(enemyPrefab, pos, transform.rotation);
            var enemy = obj.gameObject.GetComponent<Move>();

            enemy.movingLeft = leftDirection;
            enemy.speed *= speedMulti;
            leftDirection = !leftDirection;
            speedMulti += speedIncrement;
        }
    }
}
