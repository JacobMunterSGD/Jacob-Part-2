using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalkeeperController : MonoBehaviour
{

    public Rigidbody2D rb;

    Vector2 direction;

    float minDistance;

    Player tempPlayer;

    float speed = 2;

    void Start()
    {
        minDistance = 2;
    }

    void Update()
    {
        if (TeamController.SelectedPlayer == null) return;
        tempPlayer = TeamController.SelectedPlayer;
        //Debug.Log(tempPlayer);
        direction = transform.position - tempPlayer.transform.position;
        //- TeamController.SelectedPlayer.transform.position;
        //Debug.Log(TeamController.SelectedPlayer.transform.position);

        if (direction.magnitude < minDistance)
        {
            //Vector2 a = ((Vector2)transform.position - (Vector2)direction / 2);
            rb.position = Vector2.MoveTowards(tempPlayer.transform.position, direction - direction/2, speed * Time.deltaTime);
        }
        else 
        {
            //rb.position = (Vector2)transform.position - direction.normalized * minDistance;
            //Vector2 a = ((Vector2)transform.position - (Vector2)direction / 2);
            rb.position = Vector2.MoveTowards(rb.position, (Vector2)transform.position - (Vector2)direction.normalized * minDistance, speed * Time.deltaTime);
        }

    }
}
