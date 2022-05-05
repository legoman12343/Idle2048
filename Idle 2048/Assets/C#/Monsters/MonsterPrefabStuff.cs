using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;


public class MonsterPrefabStuff : MonoBehaviour
{
    public List<GameObject> prefabList = new List<GameObject>();
    public LevelController level;

    // Update is called once per frame
    void Update()
    {
        int prefabIndex = UnityEngine.Random.Range(0, prefabList.Count - 1);
        var monster = Instantiate(prefabList[prefabIndex]);
    }

    public void spawnMonster()
    {
        int health = level.getMonsterHealth();
    }
}
    




