using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.EventSystems;

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

    public HealthBar healthBar;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        gameObject.SendMessage("ResetHealth");

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
        if (Input.GetMouseButtonDown(0) && !(clickingOnSelf) && !EventSystem.current.IsPointerOverGameObject())
        {

            destination = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        }

        if (Input.GetMouseButtonDown(1))
        {

            animator.SetTrigger("Attack");

        }

        animator.SetFloat("Movement", movement.magnitude);

    }

    private void OnMouseDown()
    {
        if (isDead) return;
        clickingOnSelf = true;
        gameObject.SendMessage("TakeDamage", 1);

    }

    private void OnMouseUp()
    {
        clickingOnSelf = false;
    }

    public void TakeDamage(float damage)
    {

        health -= damage;
        PlayerPrefs.SetFloat("health", health);
        UnityEngine.Debug.Log(PlayerPrefs.GetFloat("health"));

        health = Mathf.Clamp(health, 0, maxHealth);
        if (PlayerPrefs.GetFloat("health") <= 0)
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

    public void ResetHealth()
    {
        if (PlayerPrefs.GetFloat("health") < 0 || PlayerPrefs.GetFloat("health") > maxHealth)
        {
            health = maxHealth;
            PlayerPrefs.SetFloat("health", health);
        }

        health = PlayerPrefs.GetFloat("health");
        PlayerPrefs.SetFloat("health", health);

        if (PlayerPrefs.GetFloat("health") <= 0)
        {
            animator.SetTrigger("Death");
            isDead = true;
        }
    }   
}
