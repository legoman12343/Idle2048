using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

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
    public TextMeshProUGUI timerText;
    private float timer;

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
            timerText.gameObject.SetActive(true);
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
                timerText.gameObject.SetActive(false);
                StopCoroutine(coroutine);
                quest.updateKillBossQuest(1);
            }
            else
            {
                quest.updateKillMonstersQuest(1);
            }
            monsterScript.giveMoney = true;
            StartCoroutine(monsterScript.respawnMonster());
        }        
    }

    public IEnumerator bossTimer()
    {
        timer -= Time.deltaTime;
        timer = 30f;
        while (timer>0)
        {
            timer -= 0.1f;
            timerText.text = timer.ToString("0.##") + "/30";
            yield return new WaitForSeconds(0.1f);
        }
        timerText.gameObject.SetActive(false);
        monsterScript.bossDead = false;
        monsterScript.giveMoney = false;
        StartCoroutine(monsterScript.respawnMonster());
        
    }
}
