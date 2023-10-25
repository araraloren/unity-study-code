using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRigidbody;
    private Animator playerAnimator;

    private const string JumpTrigger = "Jump_trig";
    private const string DeathBool = "Death_b";
    private const string DeathType = "DeathType_int";

    public float jumpForce = 10;
    public float gravityModifier = 1;
    public bool isOnGround = true;
    public bool gameOver = false;

    // Start is called before the first frame update
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
        playerAnimator = GetComponent<Animator>();
        Physics.gravity = Physics.gravity * gravityModifier;
    }

    // Update is called once per frame
    void Update()
    {
        if (isOnGround && Input.GetKeyDown(KeyCode.Space) && !gameOver)
        {
            playerRigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
            playerAnimator.SetTrigger(JumpTrigger);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        var obj = collision.gameObject;

        if (obj.CompareTag("Ground"))
        {
            isOnGround = true;
        }
        else if (obj.CompareTag("Obstacle"))
        {
            gameOver = true;
            Debug.Log("Game over!!");
            playerAnimator.SetBool(DeathBool, true);
            playerAnimator.SetInteger(DeathType, 1);
        }
    }
}
