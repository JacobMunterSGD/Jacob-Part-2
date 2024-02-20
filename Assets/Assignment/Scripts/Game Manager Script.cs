using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManagerScript : MonoBehaviour
{

    float score;

    public TMP_Text scoreText;

    void Start()
    {

        score = 0;
        scoreText.SetText("Score: " + score);

    }

    public void GameOver()
    {
        //Debug.Log("Game Over :(");

        PlayerPrefs.SetFloat("LastScore", score);

        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = (currentSceneIndex + 1) % SceneManager.sceneCountInBuildSettings;
        SceneManager.LoadScene(nextSceneIndex);
    }

    public void ChangeScore(float changeBy)
    {
        
        score += changeBy;
        //Debug.Log(score);
        scoreText.SetText("Score: " + score);

    }

}
