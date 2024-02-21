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
            rb.position = (Vector2)transform.position - direction / 2;
        }
        else 
        {
            rb.position = (Vector2)transform.position - direction.normalized * minDistance;
        }

    }
}
