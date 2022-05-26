using System.Collections;
using System.Collections.Generic;
using System;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Numerics;
using Vector3 = UnityEngine.Vector3;
using Vector2 = UnityEngine.Vector2;
using Quaternion = UnityEngine.Quaternion;

public class QuestManager : MonoBehaviour
{

    [SerializeField] private List<quest> prefabs = new List<quest>();
    public Transform parent;
    private List<quest> quests = new List<quest>();
    public NotificationAnimation na;

    void Start()
    {
        createHighScore(10);
        createKillBoss(5);
        createKillDucks(5);
        createKillMonsters(5);
        createMergeDamage(300);
        createOpenCrate(2);
    }


    public void createKillMonsters(int x)
    {
        quest newQuest = new quest();
        newQuest.obj = Instantiate(prefabs[0].obj, Vector3.zero, Quaternion.identity, parent);
        newQuest.type = QuestType.killMonster;
        newQuest.obj.GetComponent<KillMonstersQuest>().init(x,na);
        quests.Add(newQuest);
    }

    public void createKillBoss(int x)
    {
        quest newQuest = new quest();
        newQuest.obj = Instantiate(prefabs[1].obj, Vector3.zero, Quaternion.identity, parent);
        newQuest.type = QuestType.killBoss;
        newQuest.obj.GetComponent<KillBosses>().init(x, na);
        quests.Add(newQuest);
    }

    public void createMergeDamage(BigInteger x)
    {
        quest newQuest = new quest();
        newQuest.obj = Instantiate(prefabs[2].obj, Vector3.zero, Quaternion.identity, parent);
        newQuest.type = QuestType.mergeDamage;
        newQuest.obj.GetComponent<MergeDamage>().init(x, na);
        quests.Add(newQuest);
    }

    public void createHighScore(BigInteger x)
    {
        quest newQuest = new quest();
        newQuest.obj = Instantiate(prefabs[3].obj, Vector3.zero, Quaternion.identity, parent);
        newQuest.type = QuestType.highScore;
        newQuest.obj.GetComponent<HighTile>().init(x, na);
        quests.Add(newQuest);
    }

    public void createOpenCrate(int x)
    {
        quest newQuest = new quest();
        newQuest.obj = Instantiate(prefabs[4].obj, Vector3.zero, Quaternion.identity, parent);
        newQuest.type = QuestType.openCrate;
        newQuest.obj.GetComponent<OpenCrates>().init(x, na);
        quests.Add(newQuest);
    }

    public void createKillDucks(int x)
    {
        quest newQuest = new quest();
        newQuest.obj = Instantiate(prefabs[5].obj, Vector3.zero, Quaternion.identity, parent);
        newQuest.type = QuestType.killDucks;
        newQuest.obj.GetComponent<KillDucks>().init(x, na);
        quests.Add(newQuest);
    }


    public void updateList(QuestType t, int x)
    {
        List<quest> temp = new List<quest>(quests);
        foreach (quest item in quests)
        {
            if(item.type == t)
            {
                bool check = false;
                switch(t)
                {
                    case QuestType.openCrate:
                        check = item.obj.GetComponent<OpenCrates>().update(x);
                        break;
                    case QuestType.killMonster:
                        check = item.obj.GetComponent<KillMonstersQuest>().update(x);
                        break;
                    case QuestType.killBoss:
                        check = item.obj.GetComponent<KillBosses>().update(x);
                        break;
                    case QuestType.mergeDamage:
                        check = item.obj.GetComponent<MergeDamage>().update(x);
                        break;
                    case QuestType.highScore:
                        check = item.obj.GetComponent<HighTile>().update(x);
                        break;
                    case QuestType.killDucks:
                        check = item.obj.GetComponent<KillDucks>().update(x);
                        break;
                        /*
                    case QuestType.killMonster:
                        check = item.obj.GetComponent<KillMonsterQuest>().update(x);
                        break;
                    case QuestType.killMonster:
                        check = item.obj.GetComponent<KillMonsterQuest>().update(x);
                        break;
                    case QuestType.killMonster:
                        check = item.obj.GetComponent<KillMonsterQuest>().update(x);
                        break;
                    case QuestType.killMonster:
                        check = item.obj.GetComponent<KillMonsterQuest>().update(x);
                        break;
                    case QuestType.killMonster:
                        check = item.obj.GetComponent<KillMonsterQuest>().update(x);
                        break;
                    case QuestType.killMonster:
                        check = item.obj.GetComponent<KillMonsterQuest>().update(x);
                        break; */

                }

                if (check) temp.Add(item);
            }
        }

        foreach (quest item in temp)
        {
            quests.Remove(item);
        }
    }

    public void updateList(QuestType t, BigInteger x)
    {
        List<quest> temp = new List<quest>(quests);
        foreach (var item in quests)
        {
            if (item.type == t)
            {
                bool check = false;
                switch (t)
                {
                    case QuestType.mergeDamage:
                        check = item.obj.GetComponent<MergeDamage>().update(x);
                        break;
                    case QuestType.highScore:
                        check = item.obj.GetComponent<HighTile>().update(x);
                        break;
                        /*
                    case QuestType.killMonster:
                        check = item.obj.GetComponent<KillMonsterQuest>().update(x);
                        break;
                    case QuestType.killMonster:
                        check = item.obj.GetComponent<KillMonsterQuest>().update(x);
                        break;
                    case QuestType.killMonster:
                        check = item.obj.GetComponent<KillMonsterQuest>().update(x);
                        break;
                    case QuestType.killMonster:
                        check = item.obj.GetComponent<KillMonsterQuest>().update(x);
                        break;
                    case QuestType.killMonster:
                        check = item.obj.GetComponent<KillMonsterQuest>().update(x);
                        break;
                    case QuestType.killMonster:
                        check = item.obj.GetComponent<KillMonsterQuest>().update(x);
                        break; */

                }

                if (check) temp.Add(item);
            }
        }
        foreach (quest item in temp)
        {
            quests.Remove(item);
        }
    }
}




[Serializable]
public enum QuestType
{
    killMonster,
    killBoss,
    mergeDamage,
    highScore,
    openCrate,
    killDucks,
    unlockGear,
    getGearToLevel,
    spendOrbs,
    craftOrbs,
    completeLevels,
    findScraps,
    ability
}
[Serializable]
public struct quest
{
    public QuestType type;
    public GameObject obj;
}

[Serializable]
public struct progressbar
{
    public Text text;
    public Text description;
    public Text title;
    public GameObject sliderParent;
    public GameObject tab;
    public GameObject button;
    public Slider slider;
    public int state;
}