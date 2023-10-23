using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public MeshRenderer Renderer;
    public float rotateSpeed = 1.0f;
    public float forwardSpeed = 1.0f;
    public float leftSpeed = 1.0f;

    private bool goForward = false;

    void Start()
    {
        InvokeRepeating("ColorUpdate", 2.0f, 2.0f);
    }

    void Update()
    {
        transform.Rotate(rotateSpeed * Time.deltaTime, 0.0f, 0.0f, Space.World);
    }

    void ColorUpdate()
    {
        var r = Random.Range(0, 1.0f);
        var g = Random.Range(0, 1.0f);
        var b = Random.Range(0, 1.0f);
        var a = Random.Range(0, 1.0f);

        Renderer.material.color = new Color(r, g, b, a);
    }

    void PositionUpdate()
    {
        if (goForward)
        {
            // x
            transform.Translate(Vector3.forward * forwardSpeed * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector3.left * forwardSpeed * Time.deltaTime);
        }
    }
}
