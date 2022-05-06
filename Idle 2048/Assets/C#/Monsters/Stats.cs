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
    private bool respawn = false;

    public void Init()
    {
        totalHealth = 150000000;
        currentHealth = 150000000;
        healthBar.health = totalHealth;
        healthBar.totalHealth = totalHealth;
    }
    
    void Update()
    {
        if (healthBar.isDead == true && respawn == false)
        {
            respawn = true;
            StartCoroutine(monsterScript.respawnMonster());
        }        
    }
}
