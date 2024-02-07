using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{

    Rigidbody2D rb;
    public GameObject knight;
    float speed = 3;

    float timer;

    void Start()
    {
        
        rb = GetComponent<Rigidbody2D>();
        timer = 10;

    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + new Vector2(Time.deltaTime * speed, 0));
    }

    private void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        knight.SendMessage("TakeDamage", 5);
        


        Debug.Log("asdaijdaoi");

        Destroy(gameObject);

    }

}
