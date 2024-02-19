using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish : MonoBehaviour
{

    Animator animator;
    Rigidbody2D rb;
    public GameObject gm;

    Vector2 destination;
    Vector2 movement;

    public float moveSpeed;
    public float minSpeed;
    public float boostLose;
    public float boost;
    public float maxSpeed;

    float boostSubtractScoreBy;

    float angle;

    bool isClickingOnSelf = false;

    private void Start()
    {

        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        gm = GameObject.Find("Game Manager");

        moveSpeed = minSpeed;

        boostSubtractScoreBy = -1;

    }


    private void FixedUpdate()
    {
        movement = destination - (Vector2)transform.position;

        if (movement.magnitude < 0.1)
        {
            movement = Vector2.zero;
            moveSpeed = minSpeed;
            animator.SetBool("Moving", false);
            
        }
        

        rb.MovePosition(rb.position + movement.normalized * Time.deltaTime * moveSpeed);
    }

    void Update()
    {

        

        if (moveSpeed > minSpeed)
        {
            moveSpeed -= Time.deltaTime * boostLose;
        }

        if (Input.GetKeyDown(KeyCode.Space) && moveSpeed < maxSpeed && movement.magnitude < 0.1)
        {
            Debug.Log(movement.magnitude);
            Boost();
        }

        if (Input.GetMouseButtonDown(0) == true && isClickingOnSelf == false && !EventSystem.current.IsPointerOverGameObject())
        {
        
            destination = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            

            CharacterDirection();

        }

    }

    private void CharacterDirection()
    {

        animator.SetBool("Moving", true);
        angle = Mathf.Rad2Deg * (Mathf.Atan2(destination.y - transform.position.y, destination.x - transform.position.x));

        if (angle > -135 && angle < -45) // UP
        {
            animator.SetFloat("Vertical", -1);
            animator.SetFloat("Horizontal", 0);
        }

        if (angle > 45 && angle < 135) // DOWN
        {
            animator.SetFloat("Vertical", 1);
            animator.SetFloat("Horizontal", 0);
        }

        if (angle > -45 && angle < 45) // RIGHT
        {//asdasd
            animator.SetFloat("Vertical", 0);
            animator.SetFloat("Horizontal", 1);
        }

        if (angle > 135 || angle < -135) // LEFT
        {
            animator.SetFloat("Vertical", 0);
            animator.SetFloat("Horizontal", -1);
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

    public void Boost()
    {
        if (moveSpeed < maxSpeed && movement.magnitude > 0)
        {
            moveSpeed += boost;
            gm.SendMessage("ChangeScore", boostSubtractScoreBy);
        }
        
    }

}
