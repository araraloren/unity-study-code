using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float leftBound = -14;
    public float rightBound = 14;

    public float speed = 5.0f;
    public bool movingLeft = false;


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dir = movingLeft ? Vector3.left : Vector3.right;

        transform.Translate(dir * Time.deltaTime * speed);

        if (transform.position.x > rightBound || transform.position.x < leftBound)
        {
            Destroy(gameObject);
        }
    }
}
