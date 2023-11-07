using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRigidbody;

    public float speed = 5.0f;
    public int bulletCount = 6;
    public GameObject focalPoint;
    public GameObject powerupIndicator;
    public GameObject bulletObject;

    private Coroutine powerUpCountDown;

    public float powerUpTime = 7.0f;
    public float powerUpStrength = 15.0f;
    public bool hasPowerup = false;
    public bool hasBullet = false;

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
        powerupIndicator.transform.position = new Vector3(transform.position.x, powerupIndicator.transform.position.y, transform.position.z);

        if (hasBullet && Input.GetKeyDown(KeyCode.Space)) 
        {
             for (int i = 0;i < bulletCount; i ++)
            {
                var y =  i * (180 / bulletCount);

                Debug.Log("rotation : " + y);
                Instantiate(bulletObject, transform.position, Quaternion.Euler(0, y, 0));
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Powerup"))
        {
            if (hasPowerup && powerUpCountDown != null)
            {
                StopCoroutine(powerUpCountDown);
            }
            hasPowerup = true;
            powerupIndicator.gameObject.SetActive(true);
            Destroy(other.gameObject);
            powerUpCountDown = StartCoroutine(PowerupCountdown());
        }
        else if (other.CompareTag("Bullet"))
        {
            if (hasBullet && powerUpCountDown != null)
            {
                StopCoroutine(powerUpCountDown);
            }
            hasBullet = true;
            powerupIndicator.gameObject.SetActive(true);
            Destroy(other.gameObject);
            powerUpCountDown = StartCoroutine(PowerupCountdown());
        }
    }

    IEnumerator PowerupCountdown()
    {
        yield return new WaitForSeconds(powerUpTime);
        hasPowerup = false;
        hasBullet = false;
        powerupIndicator.gameObject.SetActive(false);
        powerUpCountDown = null;
    }

    private void OnCollisionEnter(Collision collision)
    {
        var enemy = collision.gameObject;

        if (enemy.CompareTag("Enemy") && hasPowerup)
        {
            var rigidbody = enemy.GetComponent<Rigidbody>();
            var awayFromPlayer = enemy.transform.position - transform.position;

            rigidbody.AddForce(awayFromPlayer * powerUpStrength, ForceMode.Impulse);
            Debug.Log("Collision with " + collision.gameObject.name);
        }
    }
}
