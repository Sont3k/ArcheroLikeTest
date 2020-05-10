using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarController : MonoBehaviour
{
    Slider slider;

    private void Start() {
        slider = GetComponent<Slider>();
    }

    public void SetMaxHealth(int health)
    {
        if(slider != null)
        {
            slider.maxValue = health;
        }
    }

    public void SetHealth(int health)
    {
        if(slider != null)
        {
            slider.value = health;
        }
    }
}
