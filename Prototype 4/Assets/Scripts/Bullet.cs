using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20.0f;
    public float force = 20.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(transform.forward * speed * Time.deltaTime);
        if (transform.position.x < -20 || transform.position.x > 20
                ||transform.position.z > 20 || transform.position.z < -20)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            var rigibody = other.GetComponent<Rigidbody>();
            var direction = (other.gameObject.transform.position - transform.position).normalized;

            rigibody.AddForce(direction * force, ForceMode.Impulse);
        }
    }
}
