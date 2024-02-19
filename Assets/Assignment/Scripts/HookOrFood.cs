using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class HookOrFood : MonoBehaviour
{

    Rigidbody2D rb;
    public GameObject player;
    public GameObject gm;

    float leftOrRight;
    float verticalSpawnBuffer;

    float foodSpeed;
    float foodChangeScoreBy;

    float hookSpeed;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.Find("Player");
        gm = GameObject.Find("Game Manager");

        verticalSpawnBuffer = 4;

        foodSpeed = Random.Range(2, 4);

        hookSpeed = Random.Range(3, 5);

        foodChangeScoreBy = 5;

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

        transform.position = new Vector2(player.transform.position.x + 10 * leftOrRight, Random.Range(player.transform.position.y - verticalSpawnBuffer, player.transform.position.y + verticalSpawnBuffer));

    }

    private void FixedUpdate()
    {
        if (gameObject.tag == "Food")
        {
            rb.MovePosition(rb.position + new Vector2(Time.deltaTime * foodSpeed * -leftOrRight, 0));
        }

        if (gameObject.tag == "Hook")
        {
            rb.MovePosition(rb.position + new Vector2(Time.deltaTime * hookSpeed * -leftOrRight, 0));
        }
        

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (gameObject.tag == "Food")
        {
            gm.SendMessage("ChangeScore", foodChangeScoreBy);
            Destroy(gameObject);
        }

        if (gameObject.tag == "Hook")
        {
            gm.SendMessage("GameOver");
        }
    }
}
