using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Shark : MonoBehaviour
{

    Rigidbody2D rb;
    public GameObject player;
    public GameObject gm;

    public AnimationCurve moveCurve;

    Vector2 target;
    Vector2 movement;

    float timer;
    float timerStart;

    float moveSpeed;
    

    void Start()
    {

        player = GameObject.Find("Player");
        rb = GetComponent<Rigidbody2D>();

        timerStart = 1;
        timer = timerStart;

        moveSpeed = 5;

        
    }

    void GetTarget()
    {       
        target = (Vector2)player.transform.position;  
    }

    void FixedUpdate()
    {
        movement = target - (Vector2)transform.position;
        float angle = Mathf.Atan2(movement.x, movement.y) * Mathf.Rad2Deg;

        if (timer < 0)
        {
            GetTarget();
            timer = timerStart;
        }
        else
        {
            float interpolation = moveCurve.Evaluate(timer);
            timer -= Time.deltaTime;
            rb.MovePosition(rb.position + movement.normalized * Time.deltaTime * moveSpeed * interpolation);
            rb.rotation = -angle;

        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        gm.SendMessage("GameOver");

    }
}
