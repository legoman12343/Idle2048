using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthBarScript : MonoBehaviour
{
    public Slider slider;
    public Damage damage;
    public float health;
    public bool isDead;
    public TextMeshProUGUI healthCounter;
    public float totalHealth;
    public List<string> numbers;

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
        slider.maxValue = totalHealth;
        slider.value = health;
        updateNumber();
    }

    void updateNumber()
    {
        string healthString;
        if (health < 0)
        {
            healthString = FormatNumber(0);
            
        }
        else
        {
            healthString = FormatNumber(health);
        }
        if (!healthString.Contains("."))
        {
            if (numbers.Contains(healthString[healthString.Length-1].ToString()))
            {
                healthString += ".0";
            }
            else 
            {
                Debug.Log(healthString);
                string letter = healthString[healthString.Length - 1].ToString();
                healthString = healthString.Remove(healthString.Length - 1, 1);
                healthString += ".0" + letter;
                Debug.Log(healthString);
            }
        }

        string total = FormatNumber(totalHealth);

        healthCounter.text = healthString + "/" + total;
    }

    string FormatNumber(float num)
    {
        if (num >= 100000000)
        {

            return (num / 1000000D).ToString("0.#M");
        }
        if (num >= 1000000)
        {
            return (num / 1000000D).ToString("0.##M");
        }
        if (num >= 100000)
        {
            return (num / 1000D).ToString("0.#k");
        }
        if (num >= 10000)
        {
            return (num / 1000D).ToString("0.##k");
        }
        if (num >= 1000)
        {
            return num.ToString("#,0");
        }
        return num.ToString("0.#");
    }
}
