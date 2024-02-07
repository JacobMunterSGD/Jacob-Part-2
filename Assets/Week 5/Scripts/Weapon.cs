using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{

    Rigidbody2D rb;

    void Start()
    {
        transform.position = new Vector3(-7, Random.Range(-5, 5), 0);
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + new Vector2(Time.deltaTime, 0));
    }

    public void TakeDamage()
    {
        Debug.Log("works");
        Destroy(gameObject);
    }


}
