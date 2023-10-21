using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DetectCollisions : MonoBehaviour
{
    public bool logGameOver = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (logGameOver)
        {
            GetComponent<PlayerReference>().DecreaseLives();
        }
        else
        {
            Destroy(gameObject);
            GetComponent<PlayerReference>().IncreaseScores();

            var lives = other.GetComponent<LivesController>();

            if (lives == null)
            {
                Destroy(other.gameObject);
            }
            else
            {
                lives.DecreaseLives();
                other.GetComponentInChildren<Slider>().value = lives.Lives;
                if (lives.Lives == 0)
                {
                    Destroy(other.gameObject);
                }
            }
        }
    }
}
