using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarScript : MonoBehaviour
{
    public Slider slider;
    public Damage damage;
    public float health;
    public bool isDead;


    void Start()
    {
        var t = Time.deltaTime;
        isDead = false;
    }
    void FixedUpdate()
    {
        health -= (float)damage.dps * Time.deltaTime;
        if (health <= 0 && isDead == false)
        {
            isDead = true;
        }
        slider.value = health;

    }
}
