using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
using Assets.FantasyMonsters.Scripts;

public class MonsterPrefabStuff : MonoBehaviour
{
    public List<GameObject> prefabList = new List<GameObject>();
    public LevelController level;
    public Transform monsterSpawnPoint;
    private GameObject[] monster;
    public HealthBarScript healthBar;

    void Start()
    {
        monster = new GameObject[1];
        spawnMonster();
    }

    public void spawnMonster()
    {
        int prefabIndex = UnityEngine.Random.Range(0, prefabList.Count - 1);
        monster[0] = Instantiate(prefabList[prefabIndex],monsterSpawnPoint.position, Quaternion.identity);
        var stats = monster[0].GetComponent<Stats>();
        stats.healthBar = healthBar;
        stats.monsterScript = this;
        stats.Init();
        monster[0].GetComponent<Stats>().totalHealth = level.getMonsterHealth();
    }

    public IEnumerator respawnMonster()
    {
        monster[0].GetComponent<Monster>().Die();
        yield return new WaitForSeconds(0.8f);
        Destroy(monster[0]);
        spawnMonster();
    }

}





