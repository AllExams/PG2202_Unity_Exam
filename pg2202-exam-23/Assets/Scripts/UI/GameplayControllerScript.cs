using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameplayControllerScript : MonoBehaviour
{
    public static GameplayControllerScript instance;

    public TextMeshProUGUI enemyCounter;
    private int deathCounter;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    public void SetKillCounter()
    {
        deathCounter++;
        enemyCounter.text = "ENEMIES KILLED: " + deathCounter;
    }
}
