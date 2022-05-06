using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stats : MonoBehaviour
{
    public float currentHealth;
    public int coins;
    public int totalHealth;
    public HealthBarScript healthBar;
    public MonsterPrefabStuff monsterScript;

    public void Init()
    {
        totalHealth = 10;
        currentHealth = 10;
        healthBar.health = currentHealth;
        healthBar.slider.maxValue = totalHealth;
    }
    
    void Update()
    {
        if (healthBar.isDead == true)
        {
            StartCoroutine(monsterScript.respawnMonster());
            healthBar.isDead = false;
        }        
    }
}
