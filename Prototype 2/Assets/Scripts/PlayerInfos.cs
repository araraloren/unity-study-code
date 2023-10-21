using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfos : MonoBehaviour
{
    public ScoreController scoreController;

    public LivesController livesController;

    public void DecreaseLives()
    {
        livesController.DecreaseLives();

        int lives = livesController.Lives;

        if (lives != 0)
        {
            Debug.Log("Current lives = " + lives);
        }
        else if (lives == 0)
        {
            Debug.Log("Game over ... !!!!!!!!");
        }
    }

    public void IncreaseScores()
    {
        scoreController.IncreaseScores();
        Debug.Log("Current score = " + scoreController.Scores);
    }
}
