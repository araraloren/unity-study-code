using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PalyerController : MonoBehaviour
{
    public float lowSpeed = 1;
    public float highSpeed = 8;
    public float minPositionZ = -4;

    private float speed;
    private Vector3 movingDirection;

    // Start is called before the first frame update
    void Start()
    {
        speed = lowSpeed;
        movingDirection = Vector3.forward;
    }

    // Update is called once per frame
    void Update()
    {
        // if player out of bound, change moving direction
        if (transform.position.z < minPositionZ)
        {
            ChangeDirection();
        }
        else
        {
            // if right arrow pressed, change moving direction
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                ChangeDirection();
            }
            // If left pressed, using high speed
            if (Input.GetAxis("Left") < 0)
            {
                speed = highSpeed;
            }
            // otherwise using low speed
            else
            {
                speed = lowSpeed;
            }
        }
        transform.Translate(movingDirection * Time.deltaTime * speed);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter(Collision collision)
    {
        var obj = collision.gameObject;

        if (obj.CompareTag("Potato"))
        {
            ChangeDirection();
        }
    }

    /// <summary>
    ///  Change the player moving direction
    /// </summary>
    public void ChangeDirection()
    {
        if (movingDirection == Vector3.forward)
        {
            movingDirection = Vector3.back;
        }
        else
        {
            movingDirection = Vector3.forward;
        }
    }
}
