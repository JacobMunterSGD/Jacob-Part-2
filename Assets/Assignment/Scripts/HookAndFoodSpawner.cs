using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HookAndFoodSpawner : MonoBehaviour
{

    public GameObject hook;     // https://www.vecteezy.com/png/36492667-cartoon-doodle-fish-hook
    public GameObject food;     // https://www.shutterstock.com/sv/image-vector/cute-garden-earthworm-ground-worm-creeps-2181488945

    float foodTimer;
    float hookTimer;

    float startTimerMin;
    float startTimerMax;

    private void Start()
    {
        startTimerMin = 2;
        startTimerMax = 4;
        foodTimer = Random.Range(startTimerMin, startTimerMax);
        hookTimer = Random.Range(startTimerMin + 3, startTimerMax + 3);
    }

    void Update()
    {
        if (foodTimer < 0)
        {
            Instantiate(food);
            foodTimer = Random.Range(startTimerMin, startTimerMax);
        }
        else
        {
            foodTimer -= Time.deltaTime;
        }

        if (hookTimer < 0)
        {
            Instantiate(hook);
            hookTimer = Random.Range(startTimerMin, startTimerMax);
        }
        else
        {
            hookTimer -= Time.deltaTime;
        }
    }
}
