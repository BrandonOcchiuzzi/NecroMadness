using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthBar : MonoBehaviour
{

    public Slider slider; //references the slider component on the healthbar
    public Gradient gradient; // gradient adds a component to the healthbar that allows colour changes based on hp values
    public Image fill; //references the fill component of the healthbar

    public void SetMaxHealth(int health)
    {
        slider.maxValue = health; //starts the slider component at set maxHealth
        slider.value = health; //sets the slider value to current hp, called from SetHealth function

        fill.color = gradient.Evaluate(1f); //fills the whole (remaining) bar the color chosen at each value

    }

    public void SetHealth(int health) 
    {
        slider.value = health; 
        fill.color = gradient.Evaluate(slider.normalizedValue); //normalizes the fill colour value at 1
    }
}
