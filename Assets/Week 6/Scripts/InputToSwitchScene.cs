using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputToSwitchScene : MonoBehaviour
{

    public SceneLoader loaderScript;

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {

            loaderScript.LoadNextScene();

        }

    }
}
