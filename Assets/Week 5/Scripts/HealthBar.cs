using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{

    public Slider slider;

    public void Start()
    {
        slider.value = PlayerPrefs.GetFloat("health");
    }

    public void TakeDamage(float damage)
    {
        //slider.value -= damage;
        slider.value = PlayerPrefs.GetFloat("health");
    }
}
