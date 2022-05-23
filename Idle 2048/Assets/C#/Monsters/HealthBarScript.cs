using System.Collections;
using System.Collections.Generic;
using System;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Numerics;

public class HealthBarScript : MonoBehaviour
{
    public Slider slider;
    public Damage damage;
    public float health;
    public BigInteger healthBI;
    public bool isDead;
    public TextMeshProUGUI healthCounter;
    public float totalHealth;
    public BigInteger totalHealthBI;
    public List<string> numbers;
    public bool bigInt;
    public FormatNumber fn;

    void Start()
    {
        var t = Time.deltaTime;
        isDead = false;
        health = 10.0f;
        healthBI = new BigInteger(10);
    }
    void FixedUpdate()
    {
        if (!bigInt)
        {
            health -= (float)damage.getDPS() * damage.multiplier * Time.deltaTime;
            if (health <= 0 && isDead == false)
            {
                isDead = true;
            }
            slider.maxValue = totalHealth;
            slider.value = health;
        }
        else
        {
            BigInteger d = damage.getDPS();
            BigInteger dm = new BigInteger(damage.multiplier * 1000);
            BigInteger t = new BigInteger(Time.deltaTime * 10000000);


            BigInteger temp = d * dm * t;
            healthBI -= temp / 10000000000;
            if (healthBI <= 0 && isDead == false)
            {
                isDead = true;
            }
            slider.maxValue = 100;
            var tempF = healthBI / totalHealthBI * 100;
            slider.value = (float)tempF;
        }
        updateNumber();
    }

    void updateNumber()
    {
        string healthString;
        if (health < 0)
        {
            healthString = fn.formatNumber(0);
            
        }
        else
        {
            healthString = fn.formatNumber(health);
        }
        if (!healthString.Contains("."))
        {
            if (numbers.Contains(healthString[healthString.Length-1].ToString()))
            {
                healthString += ".0";
            }
            else 
            {
                string letter = healthString[healthString.Length - 1].ToString();
                healthString = healthString.Remove(healthString.Length - 1, 1);
                healthString += ".0" + letter;
            }
        }

        string total = fn.formatNumber(totalHealth);

        healthCounter.text = healthString + "/" + total;
    }

}
