using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;


public class MonsterPrefabStuff : MonoBehaviour
{
    public List<GameObject> prefabList = new List<GameObject>();
    public LevelController level;
    public Transform monsterSpawnPoint;

    void Start()
    {
        spawnMonster();
    }

    public void spawnMonster()
    {
        int prefabIndex = UnityEngine.Random.Range(0, prefabList.Count - 1);
        var monster = Instantiate(prefabList[prefabIndex],monsterSpawnPoint.position, Quaternion.identity);
        monster.GetComponent<Stats>().totalHealth = level.getMonsterHealth();
    }
}
    




