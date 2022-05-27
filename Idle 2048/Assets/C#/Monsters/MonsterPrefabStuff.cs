using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
using Assets.FantasyMonsters.Scripts;
using DG.Tweening;
using TMPro;
using QUEST;

public class MonsterPrefabStuff : MonoBehaviour
{
    
    public List<GameObject> monsterPrefabList = new List<GameObject>();
    public List<GameObject> bossPrefabList = new List<GameObject>();
    public LevelController level;
    public Transform monsterSpawnPointRight;
    public Transform monsterBattlePoint;
    public Transform monsterSpawnPointLeft;
    private List<GameObject> monster = new List<GameObject>();
    public HealthBarScript healthBar;
    //coin splash
    public GameObject coinPrefab;
    public Infuse infuse;
    public CoinsDisplay moneyScript;
    public float multiplier;
    bool backLevel;
    private Vector3 spawnPoint;
    public QuestManager quest;
    bool duck;
    public bool bossDead;
    public TextMeshProUGUI timerText;
    public bool giveMoney;
    public AudioSource deathSound;
    public bool sounds = true;
    public float infuseChance;

    void Start()
    {
        infuseChance = 0.001f;
        backLevel = false;
        spawnMonster();
        //coin multiplier for crates
        multiplier = 1;
        duck = false;
    }

    public IEnumerator removeDeadMonster(GameObject Monster, bool dir)
    {
        if (!dir) Monster.transform.DOMove(monsterSpawnPointLeft.position, 1f);
        else Monster.transform.DOMove(monsterSpawnPointRight.position, 1f);
        yield return new WaitForSeconds(1f);
        Destroy(Monster);
    }

    public void spawnMonster()
    {
        while (monster.Count != 0)
        {
            StartCoroutine(removeDeadMonster(monster[0], backLevel));
            monster.RemoveAt(0);
        }
        if (backLevel == true)
        {
            spawnPoint = monsterSpawnPointLeft.position;
            backLevel = false;
        }
        else spawnPoint = monsterSpawnPointRight.position;

        //spawn boss
        if (level.level % 10 == 0 && level.level > 9)
        {
            int prefabIndex = UnityEngine.Random.Range(0, bossPrefabList.Count - 1);
            monster.Add(Instantiate(bossPrefabList[prefabIndex], spawnPoint, Quaternion.identity));
            var s = monster[monster.Count - 1].GetComponent<Stats>();
            s.boss = true;
            s.timerText = timerText;
            level.requiredKills = 1;
            level.killSlider.maxValue = 1;
        }
        else
        {//spawn normal monster
            int prefabIndex = Random.Range(0, monsterPrefabList.Count - 1);
            if (prefabIndex == 12)
                duck = true;
            monster.Add(Instantiate(monsterPrefabList[prefabIndex], spawnPoint, Quaternion.identity));
            monster[monster.Count - 1].GetComponent<Stats>().boss = false;
            level.requiredKills = 10;
            level.killSlider.maxValue = 10;

        }
        //set monster values
        var stats = monster[monster.Count - 1].GetComponent<Stats>();
        stats.healthBar = healthBar;
        stats.monsterScript = this;
        stats.level = level;
        stats.quest = quest;
        healthBar.isDead = false;
        stats.Init();
        monster[monster.Count - 1].transform.DOMove(monsterBattlePoint.position, 1f);
    }

    public void DecreaseLevel()
    {
        backLevel = true;
        spawnMonster();
    }

    public void IncreaseLevel()
    {
        backLevel = false;
        spawnMonster();
    }

    //coroutine for death
    public IEnumerator respawnMonster()
    {
        if (level.level == level.levelMax && level.killCount != level.requiredKills && bossDead) level.killCount++;
        level.LevelUpdate();
        bossDead = true;
        bool coinsMade = false;
        if (duck) { quest.update(QuestType.killDucks, 1); duck = false; }
        if (deathSound != null && sounds) deathSound.Play();

        if(level.level == level.levelMax && Random.value < infuseChance)
        {
            infuse.increaseScraps();
        }

        //death animation script
        monster[0].GetComponent<Monster>().Die();
        //make coins splash
        if (coinsMade == false && monster[0].GetComponent<Stats>().coins > 0 && giveMoney)
        {
            int range = Random.Range(5, 8);
            if ( level.level < range)
            {
                range = level.level;
            }
            for (int i = 0; i < range; i++)
            {
                Vector3 vec = monsterBattlePoint.position;
                vec.y += 0.5f;
                Instantiate(coinPrefab, vec, Quaternion.identity);
            }
            coinsMade = true;
            //add coins to total
            moneyScript.addCoins((monster[0].GetComponent<Stats>().coins * (int)(multiplier*100))/100);
        }
        
        //wait
        yield return new WaitForSeconds(1.1f);
        if (level.level == level.levelMax && level.killCount == level.requiredKills && level.ProgressMode == true) level.killCount = 0;
        backLevel = false;
        spawnMonster();
        level.LevelUpdate();
    }


}





