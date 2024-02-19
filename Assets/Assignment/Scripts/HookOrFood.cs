using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HookOrFood : MonoBehaviour
{

    Rigidbody2D rb;
    public GameObject fish;

    float leftOrRight;
    float verticalSpawnBuffer;
    float speed;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        fish = GameObject.Find("Player");

        verticalSpawnBuffer = 4;

        speed = 2;

        int tempLeftRight = Random.Range(0, 2);

        //Debug.Log(tempLeftRight);

        if (tempLeftRight == 0)
        {
            leftOrRight = -1;
        }
        else
        {
            leftOrRight = 1;
        }

        transform.position = new Vector2(fish.transform.position.x + 5 * leftOrRight, Random.Range(fish.transform.position.y - verticalSpawnBuffer, fish.transform.position.y + verticalSpawnBuffer));

    }

    private void FixedUpdate()
    {

        rb.MovePosition(rb.position + new Vector2(Time.deltaTime * speed * -leftOrRight, 0));

    }

    void Update()
    {

        if (gameObject.tag == "Food")
        {
            
        }

    }
}
