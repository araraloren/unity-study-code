using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerReference : MonoBehaviour
{
    public PlayerInfos playerInfos;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setPlayer(PlayerInfos playerInfos)
    {
        this.playerInfos = playerInfos;
    }

    public void DecreaseLives()
    {
        playerInfos.DecreaseLives();
    }

    public void IncreaseScores()
    {
        playerInfos.IncreaseScores();
    }
}
