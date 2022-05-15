using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
using Assets.FantasyMonsters.Scripts;
using DG.Tweening;
using TMPro;

public class MonsterPrefabStuff : MonoBehaviour
{
    
    public List<GameObject> monsterPrefabList = new List<GameObject>();
    public List<GameObject> bossPrefabList = new List<GameObject>();
    public LevelController level;
    public Transform monsterSpawnPointRight;
    public Transform monsterBattlePoint;
    public Transform monsterSpawnPointLeft;
    private GameObject[] monster;
    public HealthBarScript healthBar;
    //coin splash
    public GameObject coinPrefab;
    public CoinsDisplay moneyScript;
    public int multiplier;
    bool backLevel;
    private Vector3 spawnPoint;
    public Quests quest;
    bool duck;
    public bool bossDead;
    public TextMeshProUGUI timerText;

    void Start()
    {
        backLevel = false;
        monster = new GameObject[1];
        spawnMonster();
        //coin multiplier for crates
        multiplier = 1;
        duck = false;
    }

    public void spawnMonster()
    {
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
            monster[0] = Instantiate(bossPrefabList[prefabIndex], spawnPoint, Quaternion.identity);
            var s = monster[0].GetComponent<Stats>();
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
            monster[0] = Instantiate(monsterPrefabList[prefabIndex], spawnPoint, Quaternion.identity);
            monster[0].GetComponent<Stats>().boss = false;
            level.requiredKills = 10;
            level.killSlider.maxValue = 10;

        }
        //set monster values
        var stats = monster[0].GetComponent<Stats>();
        stats.healthBar = healthBar;
        stats.monsterScript = this;
        stats.level = level;
        stats.quest = quest;
        healthBar.isDead = false;
        stats.Init();
        monster[0].transform.DOMove(monsterBattlePoint.position, 1f);
    }

    public IEnumerator DecreaseLevel()
    {
        var deadMonster = monster[0];
        deadMonster.transform.DOMove(monsterSpawnPointRight.position, 1f);
        backLevel = true;
        spawnMonster();
        yield return new WaitForSeconds(1f);
        Destroy(deadMonster);
    }

    public IEnumerator IncreaseLevel()
    {
        var deadMonster = monster[0];
        deadMonster.transform.DOMove(monsterSpawnPointLeft.position, 1f);
        spawnMonster();
        yield return new WaitForSeconds(1f);
        Destroy(deadMonster);
    }

    //coroutine for death
    public IEnumerator respawnMonster()
    {
        if (level.level == level.levelMax && level.killCount != level.requiredKills && bossDead) level.killCount++;
        level.LevelUpdate();
        bossDead = true;
        bool coinsMade = false;
        if (duck) { quest.updateDuckQuest(1); duck = false; }
            
        //death animation script
        monster[0].GetComponent<Monster>().Die();
        //make coins splash
        if (coinsMade == false && monster[0].GetComponent<Stats>().coins > 0)
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
        }
        //add coins to total
        moneyScript.addCoins(monster[0].GetComponent<Stats>().coins * multiplier);
        //wait
        yield return new WaitForSeconds(1.1f);
        var deadMonster = monster[0];
        deadMonster.transform.DOMove(monsterSpawnPointLeft.position, 1f);
        if (level.level == level.levelMax && level.killCount == level.requiredKills && level.ProgressMode == true) level.killCount = 0;
        spawnMonster();
        level.LevelUpdate();
        yield return new WaitForSeconds(1f);
        //destroy obj
        Destroy(deadMonster);
    }


}





