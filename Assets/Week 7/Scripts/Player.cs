using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    SpriteRenderer sr;
    Rigidbody2D rb;

    public Color selectedColour;
    public Color unSelectedColour;

    float speed = 100;


    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();

        Selected(false);

    }

    public void Selected(bool isSelected)
    {
        
        if (isSelected)
        {
            sr.color = selectedColour;
        }
        else
        {
            sr.color = unSelectedColour;
        }

    }

    public void Move(Vector2 direction)
    {
        rb.AddForce(direction * speed, ForceMode2D.Impulse);
    }

    private void OnMouseDown()
    {
        TeamController.SetSelectedPlayer(this);
    }

    

}
