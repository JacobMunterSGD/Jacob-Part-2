using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public GameObject Plane1;
    public GameObject Plane2;
    public GameObject Plane3;
    public GameObject Plane4;
    float timer;

    List<GameObject> planes = new List<GameObject>();

    void Start()
    {
        timer = Random.Range(1, 5);
        planes = new List<GameObject>() { Plane1, Plane2, Plane3, Plane4 };
    }

    void Update()
    {

        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
        else
        {

            GameObject tempPlane = planes[Random.Range(0, 4)];

            Instantiate(tempPlane);
            timer = Random.Range(1, 5);

        }

    }
}
