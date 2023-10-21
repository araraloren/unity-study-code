using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LivesController : MonoBehaviour
{
    public int lives = 3;

    public int Lives { get; protected set; }

    // Start is called before the first frame update
    void Start()
    {
        Lives = lives;
        var slider = GetComponentInChildren<Slider>();

        if (slider != null)
        {
            slider.value = lives;
        }
    }

    public void DecreaseLives()
    {
        if (Lives != 0)
        {
            Lives -= 1;
        }
    }
}
