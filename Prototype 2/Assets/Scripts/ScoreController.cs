using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreController : MonoBehaviour
{
    public int Scores { get; protected set; }

    public void IncreaseScores()
    {
        Scores += 1;
    }
}
