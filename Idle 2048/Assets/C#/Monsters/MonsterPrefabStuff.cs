using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
using Assets.FantasyMonsters.Scripts;
using DG.Tweening;

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

    void Start()
    {
        backLevel = false;
        monster = new GameObject[1];
        spawnMonster();
        //coin multiplier for crates
        multiplier = 1;
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
            monster[0].GetComponent<Stats>().boss = true;
            level.requiredKills = 1;
        }
        else
        {//spawn normal monster
            int prefabIndex = UnityEngine.Random.Range(0, monsterPrefabList.Count - 1);
            monster[0] = Instantiate(monsterPrefabList[prefabIndex], spawnPoint, Quaternion.identity);
            monster[0].GetComponent<Stats>().boss = false;
            level.requiredKills = 10;

        }
        //set monster values
        var stats = monster[0].GetComponent<Stats>();
        stats.healthBar = healthBar;
        stats.monsterScript = this;
        stats.level = level;
        healthBar.isDead = false;
        stats.Init();
        monster[0].transform.DOMove(monsterBattlePoint.position, 1f);
    }

    public IEnumerator DecreaseLevel()
    {
        var deadMonster = monster[0];
        deadMonster.transform.DOMove(monsterSpawnPointRight.position, 1f);
        spawnMonster();
        yield return new WaitForSeconds(1f);
        backLevel = true;
    }

    //coroutine for death
    public IEnumerator respawnMonster()
    {
        level.killCount++;
        level.LevelUpdate();
        bool coinsMade = false;
        //death animation script
        monster[0].GetComponent<Monster>().Die();
        //make coins splash
        if (coinsMade == false)
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
        spawnMonster();
        yield return new WaitForSeconds(1f);
        //destroy obj
        Destroy(deadMonster);
        level.LevelUpdate();
    }


}





