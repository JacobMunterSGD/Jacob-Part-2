using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TeamController : MonoBehaviour
{

    public Slider chargeSlider;
    float chargeValue;
    public float maxCharge;
    Vector2 direction;

    public TMP_Text scoreText;

    public static float score = 0;

    public static Player SelectedPlayer { get; private set; }

    

    public static void SetSelectedPlayer(Player player)
    {

        if (SelectedPlayer != null)
        {

            SelectedPlayer.Selected(false);

        }

        player.Selected(true);
        SelectedPlayer = player;
    
    }

    private void FixedUpdate()
    {
        if (direction != Vector2.zero)
        {
            SelectedPlayer.Move(direction);
            direction = Vector2.zero;
            chargeValue = 0;
            chargeSlider.value = chargeValue;
        }
    }

    private void Update()
    {
        scoreText.text = "score: " + score;

        if (SelectedPlayer == null) return;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            chargeValue = 0;
            Mathf.Clamp(chargeValue, 0, maxCharge);
            direction = Vector2.zero;
        }

        if (Input.GetKey(KeyCode.Space))
        {
            chargeValue += Time.deltaTime;
            chargeSlider.value = chargeValue;
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            direction = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - SelectedPlayer.transform.position).normalized * chargeValue;
        }

    }


}
