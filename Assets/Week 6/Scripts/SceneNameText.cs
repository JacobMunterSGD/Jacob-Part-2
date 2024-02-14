using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class SceneNameText : MonoBehaviour
{

    TextMeshProUGUI sceneName;

    void Start()
    {
        sceneName = GetComponent<TextMeshProUGUI>();
        sceneName.text = SceneManager.GetActiveScene().name;
    }

    void Update()
    {
        


    }
}
