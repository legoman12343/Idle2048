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
    private bool respawn = true;
    public LevelController level;
    public bool boss;
    private IEnumerator coroutine;
    public Quests quest;

    public void Init()
    {
        coins = level.getMonsterCoins();
        totalHealth = level.getMonsterHealth();
        if(totalHealth < 1)
        {
            totalHealth = 10;
            coins = 1;
        }
        if (boss == true)
        {
            totalHealth *= 10;
            coins = level.getMonsterCoins() * 5;
        }
        currentHealth = totalHealth;
        healthBar.health = totalHealth;
        healthBar.totalHealth = totalHealth;
        respawn = false;
        coroutine = bossTimer();
        if(boss == true)
        {
            StartCoroutine(coroutine);
        }
    }
    
    void Update()
    {
        if (healthBar.isDead == true && respawn == false)
        {
            respawn = true;
            if (boss == true)
            {
                StopCoroutine(coroutine);
                quest.updateKillBossQuest(1);
            }
            else
            {
                quest.updateKillMonstersQuest(1);
            }
            StartCoroutine(monsterScript.respawnMonster());
        }        
    }

    public IEnumerator bossTimer()
    {
        yield return new WaitForSeconds(30);
        coins = 0;
        StartCoroutine(monsterScript.respawnMonster());
    }
}
