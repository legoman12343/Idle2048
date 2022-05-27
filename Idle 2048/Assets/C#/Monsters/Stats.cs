using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Numerics;
using QUEST;

public class Stats : MonoBehaviour
{
    public BigInteger currentHealth;
    public BigInteger coins;
    public BigInteger totalHealth;
    public HealthBarScript healthBar;
    public MonsterPrefabStuff monsterScript;
    private bool respawn = true;
    public LevelController level;
    public bool boss;
    private IEnumerator coroutine;
    public QuestManager quest;
    public TextMeshProUGUI timerText;
    private float timer;
    public AudioSource deathSound;
    public bool bigInt;

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
        if (totalHealth > 1000000000)
        {
            bigInt = true;
            healthBar.bigInt = true;
            healthBar.healthBI = totalHealth;
            healthBar.totalHealthBI = totalHealth;
        }
        else
        {
            bigInt = false;
            int temp = (int)totalHealth;
            healthBar.bigInt = false;
            healthBar.health = temp;
            healthBar.totalHealth = temp;
        }
        
        respawn = false;
        coroutine = bossTimer();
        if(boss == true)
        {
            StartCoroutine(coroutine);
        }
        monsterScript.deathSound = deathSound;
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
                quest.update(QuestType.killBoss, 1);
            }
            else
            {
                quest.update(QuestType.killMonster,1);
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
