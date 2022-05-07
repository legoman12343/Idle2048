using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
using Assets.FantasyMonsters.Scripts;

public class MonsterPrefabStuff : MonoBehaviour
{
    public List<GameObject> monsterPrefabList = new List<GameObject>();
    public List<GameObject> bossPrefabList = new List<GameObject>();
    public LevelController level;
    public Transform monsterSpawnPoint;
    private GameObject[] monster;
    public HealthBarScript healthBar;
    public GameObject coinPrefab;
    public CoinsDisplay moneyScript;
    public int multiplier;

    void Start()
    {
        monster = new GameObject[1];
        spawnMonster();
        multiplier = 1;
    }

    public void spawnMonster()
    {
        if(level.level % 10 == 0 && level.level > 9)
        {
            int prefabIndex = UnityEngine.Random.Range(0, bossPrefabList.Count - 1);
            monster[0] = Instantiate(bossPrefabList[prefabIndex], monsterSpawnPoint.position, Quaternion.identity);
            monster[0].GetComponent<Stats>().boss = true;
            level.requiredKills = 1;
        }
        else
        {
            int prefabIndex = UnityEngine.Random.Range(0, monsterPrefabList.Count - 1);
            monster[0] = Instantiate(monsterPrefabList[prefabIndex], monsterSpawnPoint.position, Quaternion.identity);
            monster[0].GetComponent<Stats>().boss = false;
            level.requiredKills = 10;

        }
        var stats = monster[0].GetComponent<Stats>();
        stats.healthBar = healthBar;
        stats.monsterScript = this;
        stats.level = level;
        healthBar.isDead = false;
        stats.Init();        
    }

    public IEnumerator respawnMonster()
    {
        level.killCount++;
        bool coinsMade = false;
        monster[0].GetComponent<Monster>().Die();
        
        if (coinsMade == false)
        {
            int range = Random.Range(5, 8);
            if ( level.level < range)
            {
                range = level.level;
            }
            for (int i = 0; i < range; i++)
            {
                Vector3 vec = monsterSpawnPoint.position;
                vec.y += 0.5f;
                Instantiate(coinPrefab, vec, Quaternion.identity);
            }
            coinsMade = true;
        }
        
        
        yield return new WaitForSeconds(1.1f);
        moneyScript.addCoins(monster[0].GetComponent<Stats>().coins * multiplier);
        Destroy(monster[0]);
        spawnMonster();
    }

}





