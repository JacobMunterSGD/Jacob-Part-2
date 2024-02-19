using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HookAndFoodSpawner : MonoBehaviour
{

    public GameObject hook;
    public GameObject food;

    float foodTimer;
    float startTimer;

    private void Start()
    {
        startTimer = 3;
        foodTimer = startTimer;
    }

    void Update()
    {
        if (foodTimer < 0)
        {
            Instantiate(food);
            foodTimer = startTimer;
        }
        else
        {
            foodTimer -= Time.deltaTime;
        }
    }
}
