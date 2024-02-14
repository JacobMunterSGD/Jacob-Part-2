using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    
    public Slider slider;

    public void ResetHealth()
    {
        slider.value = PlayerPrefs.GetFloat("health");
    }

    public void TakeDamage(float damage)
    {
        /*float tempHealth = PlayerPrefs.GetFloat("health");
        tempHealth -= damage;
        PlayerPrefs.SetFloat("health", tempHealth);*/
        slider.value = PlayerPrefs.GetFloat("health");
    }
}
