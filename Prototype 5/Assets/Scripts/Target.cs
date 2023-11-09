using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    private Rigidbody targetRigibody;

    public float minForce = 12.0f;
    public float maxForce = 16.0f;

    public float minTorque = -10.0f;
    public float maxTorque = 10.0f;

    public float minTargetX = -4.5f;
    public float maxTargetX = 4.5f;

    public float targetY = -6.0f;

    // Start is called before the first frame update
    void Start()
    {
        targetRigibody = GetComponent<Rigidbody>();

        targetRigibody.AddForce(RandomForce(), ForceMode.Impulse);
        targetRigibody.AddTorque(RandomTorque(), ForceMode.Impulse);

        transform.position = RandomPosition();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }

    Vector3 RandomPosition()
    {
        return new Vector3(Random.Range(minTargetX, maxTargetX), targetY);
    }

    Vector3 RandomForce()
    {
        return Vector3.up * Random.Range(minForce, maxForce);
    }

    Vector3 RandomTorque()
    {
        var x = Random.Range(minTorque, maxTorque);
        var y = Random.Range(minTorque, maxTorque);
        var z = Random.Range(minTorque, maxTorque);

        return new Vector3(x, y, z);
    }
}
