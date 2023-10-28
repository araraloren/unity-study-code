using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRigidbody;
    private Animator playerAnimator;
    private AudioSource playerAudio;

    private const string JumpTrigger = "Jump_trig";
    private const string DeathBool = "Death_b";
    private const string DeathType = "DeathType_int";
    private const string Speed = "Speed_f";

    public ParticleSystem explosionParticle;
    public ParticleSystem dirtParticle;

    public AudioClip jumpSound;
    public AudioClip crashSound;

    public bool doubleJump = true;
    public float jumpForce = 10;
    public float gravityModifier = 1;
    public bool isOnGround = true;
    public bool gameOver = false;
    public bool startAnimation = true;

    // Start is called before the first frame update
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
        playerAnimator = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
        Physics.gravity = Physics.gravity * gravityModifier;
    }

    // Update is called once per frame
    void Update()
    {
        if (startAnimation)
        {
            if (transform.position.x < 2)
            {
                transform.Translate(Vector3.forward * Time.deltaTime * 2);
            }
            else
            {
                playerAnimator.SetFloat(Speed, 1.0f);
                startAnimation = false;
            }
        }
        else  if ((isOnGround || doubleJump) && Input.GetKeyDown(KeyCode.Space) && !gameOver)
        {
            playerRigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            playerAnimator.SetTrigger(JumpTrigger);
            dirtParticle.Stop();
            playerAudio.PlayOneShot(jumpSound, 1.0f);
            if (isOnGround)
            {
                isOnGround = false;
            }
            else
            {
                doubleJump = false;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        var obj = collision.gameObject;

        if (obj.CompareTag("Ground"))
        {
            isOnGround = true;
            doubleJump = true;
            dirtParticle.Play();
        }
        else if (obj.CompareTag("Obstacle") && !gameOver)
        {
            gameOver = true;
            Debug.Log("Game over!!");
            playerAnimator.SetBool(DeathBool, true);
            playerAnimator.SetInteger(DeathType, 1);
            explosionParticle.Play();
            dirtParticle.Stop();
            playerAudio.PlayOneShot(crashSound, 1.0f);
        }
    }
}
