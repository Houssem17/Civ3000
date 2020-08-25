using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBars : MonoBehaviour
{
    public Slider slider;
    public void setMaxHeart(int health)
    {
        slider.maxValue = health;
        slider.value = health;
    }
    public void setHeart(int health)
    {
        slider.value = health;
    }
}
