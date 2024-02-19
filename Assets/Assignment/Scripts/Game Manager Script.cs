using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{

    float isGameOver;

    float score;

    GameObject player;
    
    void Start()
    {
        player = GameObject.Find("Player");

        score = 0;

    }

    public void GameOver()
    {
        Debug.Log("Game Over :(");
    }

    public void ChangeScore(float changeBy)
    {
        
        score += changeBy;
        Debug.Log(score);

    }

}
