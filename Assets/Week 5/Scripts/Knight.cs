using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class Knight : MonoBehaviour
{

    Rigidbody2D rb;
    Vector2 destination;
    Vector2 movement;
    public float speed;

    Animator animator;

    bool clickingOnSelf = false;

    public float health;
    public float maxHealth;

    bool isDead;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        health = maxHealth;

        isDead = false;
    }

    private void FixedUpdate()
    {
        if (isDead) return;
        movement = destination - (Vector2)transform.position;

        if (movement.magnitude < 0.1)
        {
            movement = Vector2.zero;
        }

        rb.MovePosition(rb.position + movement.normalized * Time.deltaTime * speed);

    }

    void Update()
    {
        if (isDead) return;
        if (Input.GetMouseButtonDown(0) && !(clickingOnSelf))
        {

            destination = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        }

        animator.SetFloat("Movement", movement.magnitude);

    }

    private void OnMouseDown()
    {
        if (isDead) return;
        clickingOnSelf = true;
        takeDamage(1);

    }

    private void OnMouseUp()
    {
        clickingOnSelf = false;
    }

    private void takeDamage(float damage)
    {

        health -= damage;
        health = Mathf.Clamp(health, 0, maxHealth);
        if (health <= 0)
        {
            animator.SetTrigger("Death");
            isDead = true;
        }
        else
        {
            isDead = false;
            animator.SetTrigger("TakeDamage");
        }

    }
}
