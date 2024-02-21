using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    SpriteRenderer sr;

    public bool isSelected;

    public Color selectedColour;
    public Color unSelectedColour;


    void Start()
    {
        sr = GetComponent<SpriteRenderer>();

        //selectedColour = new Color(255, 0, 0, 255);
        //unSelectedColour = new Color(130, 0, 0, 255);

        isSelected = false;
        Selected(false);

    }

    void Update()
    {
        
    }

    public void Selected(bool tempIsSelected)
    {

        //Debug.Log(isSelected);

        
        if (tempIsSelected)
        {
            sr.color = selectedColour;
            //Debug.Log("on");
            //isSelected = true;
        }
        else
        {
            sr.color = unSelectedColour;
            //Debug.Log("off");
            //isSelected = false;
        }



    }

    private void OnMouseDown()
    {
        Selected(true);
    }
}
