using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarScript : MonoBehaviour
{
    public Slider slider;
    public Damage damage;
    public float health;

    void Start()
    {
        var t = Time.deltaTime;
    }
    void FixedUpdate()
    {
        health -= (float)damage.dps * Time.deltaTime;
        if (health <= 0)
        {
            health = 10;
        }
        slider.value = health;

    }
}
