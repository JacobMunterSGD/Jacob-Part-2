using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Menu : MonoBehaviour
{

    public TMP_Text highScore;

    public void Start()
    {

        if (PlayerPrefs.GetFloat("LastScore") > PlayerPrefs.GetFloat("HighScore"))
        {
            PlayerPrefs.SetFloat("HighScore", PlayerPrefs.GetFloat("LastScore"));
        }

        highScore.SetText("High Score: " + PlayerPrefs.GetFloat("HighScore"));
    }

    public void LoadNextScene()
    {



        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = (currentSceneIndex + 1) % SceneManager.sceneCountInBuildSettings;

        SceneManager.LoadScene(nextSceneIndex);


    }
}
