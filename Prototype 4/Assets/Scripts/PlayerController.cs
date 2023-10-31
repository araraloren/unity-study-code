using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRigidbody;

    public float speed = 5.0f;
    public GameObject focalPoint;
    public GameObject powerupIndicator;

    public float powerUpTime = 7.0f;
    public float powerUpStrength = 15.0f;
    public bool hasPowerup = false;

    // Start is called before the first frame update
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float forwardInput = Input.GetAxis("Vertical");

        playerRigidbody.AddForce(focalPoint.transform.forward * forwardInput * speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Powerup"))
        {
            hasPowerup = true;
            powerupIndicator.gameObject.SetActive(true);
            Destroy(other.gameObject);
        }
    }

    IEnumerator PowerupCountdown()
    {
        yield return new WaitForSeconds(powerUpTime);
        hasPowerup = false;
        powerupIndicator.gameObject.SetActive(false);
    }

    private void OnCollisionEnter(Collision collision)
    {
        var enemy = collision.gameObject;

        if (enemy.CompareTag("Enemy") && hasPowerup)
        {
            var rigidbody = enemy.GetComponent<Rigidbody>();
            var awayFromPlayer = enemy.transform.position - transform.position;

            rigidbody.AddForce(awayFromPlayer * powerUpStrength, ForceMode.Impulse);
            StartCoroutine(PowerupCountdown());
            Debug.Log("Collision with " + collision.gameObject.name);
        }
    }
}
