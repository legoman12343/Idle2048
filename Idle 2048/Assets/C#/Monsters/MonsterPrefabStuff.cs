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
    //coin splash
    public GameObject coinPrefab;
    public CoinsDisplay moneyScript;
    public int multiplier;

    void Start()
    {
        monster = new GameObject[1];
        spawnMonster();
        //coin multiplier for crates
        multiplier = 1;
    }

    public void spawnMonster()
    {
        //spawn boss
        if(level.level % 10 == 0 && level.level > 9)
        {
            int prefabIndex = UnityEngine.Random.Range(0, bossPrefabList.Count - 1);
            monster[0] = Instantiate(bossPrefabList[prefabIndex], monsterSpawnPoint.position, Quaternion.identity);
            monster[0].GetComponent<Stats>().boss = true;
            level.requiredKills = 1;
        }
        else
        {//spawn normal monster
            int prefabIndex = UnityEngine.Random.Range(0, monsterPrefabList.Count - 1);
            monster[0] = Instantiate(monsterPrefabList[prefabIndex], monsterSpawnPoint.position, Quaternion.identity);
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
    }
    //coroutine for death
    public IEnumerator respawnMonster()
    {
        
        level.killCount++;
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
                Vector3 vec = monsterSpawnPoint.position;
                vec.y += 0.5f;
                Instantiate(coinPrefab, vec, Quaternion.identity);
            }
            coinsMade = true;
        }
        //add coins to total
        moneyScript.addCoins(monster[0].GetComponent<Stats>().coins * multiplier);
        //wait
        yield return new WaitForSeconds(1.1f);
        //destroy obj
        Destroy(monster[0]);
        spawnMonster();
    }

}





