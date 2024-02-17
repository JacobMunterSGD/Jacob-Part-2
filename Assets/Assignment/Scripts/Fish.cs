using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish : MonoBehaviour
{

    Animator animator;

    Rigidbody2D rb;
    Vector2 destination;
    Vector2 direction;

    public float moveSpeed;
    public float minSpeed;
    public float boostLose;
    public float boost;
    public float maxSpeed;

    bool isClickingOnSelf = false;

    private void Start()
    {

        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        moveSpeed = minSpeed;

    }


    private void FixedUpdate()
    {
        direction = destination - (Vector2)transform.position;

        if (direction.magnitude < 0.1)
        {
            direction = Vector2.zero;
            moveSpeed = minSpeed;
        }

        rb.MovePosition(rb.position + direction.normalized * Time.deltaTime * moveSpeed);
    }

    void Update()
    {

        if (moveSpeed > minSpeed)
        {
            moveSpeed -= Time.deltaTime * boostLose;
        }

        if (Input.GetKeyDown(KeyCode.Space) && moveSpeed < maxSpeed)
        {
            moveSpeed += boost;
        }

        if (Input.GetMouseButtonDown(0) == true && isClickingOnSelf == false)
        {
        
            destination = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        }

    }

    private void OnMouseDown()
    {
        isClickingOnSelf = true;

    }

    private void OnMouseUp()
    {
        isClickingOnSelf = false;
    }

}
