using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    private Rigidbody targetRigibody;
    private GameManager gameManager;

    public ParticleSystem explosionParticleSystem;

    public int score = 5;

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
        gameManager = FindFirstObjectByType<GameManager>();
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
        if (gameManager.isGameActive)
        {
            Destroy(gameObject);
            Instantiate(explosionParticleSystem, transform.position, explosionParticleSystem.transform.rotation);
            gameManager.UpdateScore(score);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!gameObject.CompareTag("Bad"))
        {
            gameManager.GameOver();
        }
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
