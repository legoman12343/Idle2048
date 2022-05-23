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
        

        if (!bigInt)
        {
            string healthString;
            if (health < 1000)
            {
                float temp = (int)Math.Round(health * 10);
                healthString = fn.formatNumber(temp / 10);
                if ((temp/10) % 1 == 0)
                {
                    healthString += ".0";
                }
            }else
            {
                healthString = fn.formatNumber(health);
            }
            string total = fn.formatNumber(totalHealth);
            if (health < 0)
            {
                healthCounter.text = "0/" + total;
            }
            else
            {
                healthCounter.text = healthString + "/" + total;
            }
        }else
        {
            string healthString = fn.formatNumberBigNumber(healthBI);
            string total = fn.formatNumberBigNumber(totalHealthBI);

            if (health < 0)
            {
                healthCounter.text = "0/" + total;
            }
            else
            {
                healthCounter.text = healthString + "/" + total;
            }
        }
    }

}
