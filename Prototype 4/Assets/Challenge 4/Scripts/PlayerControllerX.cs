using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    private Rigidbody playerRb;
    private float speed = 500;
    private float turboMulti = 2;
    private float turboSpeed = 1;
    private GameObject focalPoint;
    private Coroutine powerUpCoolDown;

    public bool hasPowerup;
    public GameObject powerupIndicator;
    public int powerUpDuration = 5;

    public bool hasTurboBoost = false;
    public ParticleSystem turboParticleSystem;
    public int turboBoostDuration = 3;

    private float normalStrength = 10; // how hard to hit enemy without powerup
    private float powerupStrength = 25; // how hard to hit enemy with powerup
    
    void Start()
    {
        turboSpeed = speed;
        playerRb = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("Focal Point");
    }

    void Update()
    {
        // Add force to player in direction of the focal point (and camera)
        float verticalInput = Input.GetAxis("Vertical");

        if (!hasTurboBoost)
        {
            if (Input.GetKeyDown(KeyCode.Space) && verticalInput > 0.0001)
            {
                hasTurboBoost = true;
                turboSpeed *= turboMulti;
                turboParticleSystem.Play();
                StartCoroutine(TurboBoostCoolDown());
            }
        }
        playerRb.AddForce(focalPoint.transform.forward * verticalInput * turboSpeed * Time.deltaTime); 

        // Set powerup indicator position to beneath player
        powerupIndicator.transform.position = transform.position + new Vector3(0, -0.6f, 0);

    }

    // Coroutine to count down powerup duration
    IEnumerator TurboBoostCoolDown()
    {
        yield return new WaitForSeconds(turboBoostDuration);
        turboSpeed = speed;
        turboParticleSystem.Stop();
        yield return new WaitForSeconds(turboBoostDuration);
        hasTurboBoost = false;
    }

    // If Player collides with powerup, activate powerup
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Powerup"))
        {
            if (powerUpCoolDown != null)
            {
                StopCoroutine(powerUpCoolDown);
            }
            Destroy(other.gameObject);
            hasPowerup = true;
            powerupIndicator.SetActive(true);
            powerUpCoolDown = StartCoroutine(PowerupCooldown());
        }
    }

    // Coroutine to count down powerup duration
    IEnumerator PowerupCooldown()
    {
        yield return new WaitForSeconds(powerUpDuration);
        hasPowerup = false;
        powerupIndicator.SetActive(false);
        powerUpCoolDown = null;
    }

    // If Player collides with enemy
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Rigidbody enemyRigidbody = other.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer =  other.gameObject.transform.position - transform.position; 
           
            if (hasPowerup) // if have powerup hit enemy with powerup force
            {
                enemyRigidbody.AddForce(awayFromPlayer * powerupStrength, ForceMode.Impulse);
            }
            else // if no powerup, hit enemy with normal strength 
            {
                enemyRigidbody.AddForce(awayFromPlayer * normalStrength, ForceMode.Impulse);
            }


        }
    }



}
