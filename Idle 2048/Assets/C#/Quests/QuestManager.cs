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
using QUEST;

public class QuestManager : MonoBehaviour
{
    public int questID = 1;
    [SerializeField] private List<quest> prefabs = new List<quest>();
    public Transform parent;
    private List<quest> quests = new List<quest>();
    public NotificationAnimation na;
    private int notifiactionAmount;
    public Gems gems;
    public Infuse infuse;

    void Start()
    {
        createHighScore(100,RewardTypes.gems, 5);
        createKillBoss(5,RewardTypes.gems, 5);
        createKillDucks(5,RewardTypes.gems, 5);
        createKillMonsters(5,RewardTypes.gems, 5);
        createMergeDamage(300,RewardTypes.gems, 5);
        createOpenCrate(2,RewardTypes.gems, 5);
        createUnlockGear(1, RewardTypes.gems,5, Gear.starterSword);
        createGetGearLevel(5, RewardTypes.gems,5, Gear.starterSword);
        createSpendOrbs(2, RewardTypes.gems,5);
        createCraftOrbs(2, RewardTypes.gems,5);
        createCompleteLevel(1, RewardTypes.gems,5);
        createFindScraps(1, RewardTypes.gems, 5);
        createUseAbilities(3, RewardTypes.gems, 5);
    }


    public void createKillMonsters(int x, RewardTypes type, int rewardValue)
    {
        quest newQuest = new quest();
        newQuest.obj = Instantiate(prefabs[0].obj, Vector3.zero, Quaternion.identity, parent);
        newQuest.type = QuestType.killMonster;
        newQuest.completed = false;
        newQuest.questID = questID;
        newQuest.reward = type;
        newQuest.rewardValue = rewardValue;
        var script = newQuest.obj.GetComponent<KillMonstersQuest>();
        script.qm = this;
        script.init(x,na,questID);
        questID++;
        quests.Add(newQuest);
    }

    public void createKillBoss(int x, RewardTypes type, int rewardValue)
    {
        quest newQuest = new quest();
        newQuest.obj = Instantiate(prefabs[1].obj, Vector3.zero, Quaternion.identity, parent);
        newQuest.type = QuestType.killBoss;
        newQuest.completed = false;
        newQuest.questID = questID;
        newQuest.reward = type;
        newQuest.rewardValue = rewardValue;
        var script = newQuest.obj.GetComponent<KillBosses>();
        script.qm = this;
        script.init(x, na, questID);
        questID++;
        quests.Add(newQuest);
    }

    public void createMergeDamage(BigInteger x, RewardTypes type, int rewardValue)
    {
        quest newQuest = new quest();
        newQuest.obj = Instantiate(prefabs[2].obj, Vector3.zero, Quaternion.identity, parent);
        newQuest.type = QuestType.mergeDamage;
        newQuest.completed = false;
        newQuest.questID = questID;
        newQuest.reward = type;
        newQuest.rewardValue = rewardValue;
        var script = newQuest.obj.GetComponent<MergeDamage>();
        script.qm = this;
        script.init(x, na, questID);
        questID++;
        quests.Add(newQuest);
    }

    public void createHighScore(BigInteger x, RewardTypes type, int rewardValue)
    {
        quest newQuest = new quest();
        newQuest.obj = Instantiate(prefabs[3].obj, Vector3.zero, Quaternion.identity, parent);
        newQuest.type = QuestType.highScore;
        newQuest.completed = false;
        newQuest.questID = questID;
        newQuest.reward = type;
        newQuest.rewardValue = rewardValue;
        var script = newQuest.obj.GetComponent<HighTile>();
        script.qm = this;
        script.init(x, na, questID);
        questID++;
        quests.Add(newQuest);
    }

    public void createOpenCrate(int x, RewardTypes type, int rewardValue)
    {
        quest newQuest = new quest();
        newQuest.obj = Instantiate(prefabs[4].obj, Vector3.zero, Quaternion.identity, parent);
        newQuest.type = QuestType.openCrate;
        newQuest.completed = false;
        newQuest.questID = questID;
        newQuest.reward = type;
        newQuest.rewardValue = rewardValue;
        var script = newQuest.obj.GetComponent<OpenCrates>();
        script.qm = this;
        script.init(x, na, questID);
        questID++;
        quests.Add(newQuest);
    }

    public void createKillDucks(int x, RewardTypes type, int rewardValue)
    {
        quest newQuest = new quest();
        newQuest.obj = Instantiate(prefabs[5].obj, Vector3.zero, Quaternion.identity, parent);
        newQuest.type = QuestType.killDucks;
        newQuest.completed = false;
        newQuest.questID = questID;
        newQuest.reward = type;
        newQuest.rewardValue = rewardValue;
        var script = newQuest.obj.GetComponent<KillDucks>();
        script.qm = this;
        script.init(x, na, questID);
        questID++;
        quests.Add(newQuest);
    }

    public void createUnlockGear (int x, RewardTypes type, int rewardValue, Gear Gtype)
    {
        quest newQuest = new quest();
        newQuest.obj = Instantiate(prefabs[6].obj, Vector3.zero, Quaternion.identity, parent);
        newQuest.type = QuestType.unlockGear;
        newQuest.completed = false;
        newQuest.questID = questID;
        newQuest.reward = type;
        newQuest.rewardValue = rewardValue;
        var script = newQuest.obj.GetComponent<UnlockGear>();
        script.qm = this;
        script.init(x, na, questID, Gtype);
        questID++;
        quests.Add(newQuest);
    }

    public void createGetGearLevel(int x, RewardTypes type, int rewardValue, Gear Gtype)
    {
        quest newQuest = new quest();
        newQuest.obj = Instantiate(prefabs[7].obj, Vector3.zero, Quaternion.identity, parent);
        newQuest.type = QuestType.getGearToLevel;
        newQuest.completed = false;
        newQuest.questID = questID;
        newQuest.reward = type;
        newQuest.rewardValue = rewardValue;
        var script = newQuest.obj.GetComponent<GetGearLevel>();
        script.qm = this;
        script.init(x, na, questID, Gtype);
        questID++;
        quests.Add(newQuest);
    }

    public void createSpendOrbs(int x, RewardTypes type, int rewardValue)
    {
        quest newQuest = new quest();
        newQuest.obj = Instantiate(prefabs[8].obj, Vector3.zero, Quaternion.identity, parent);
        newQuest.type = QuestType.spendOrbs;
        newQuest.completed = false;
        newQuest.questID = questID;
        newQuest.reward = type;
        newQuest.rewardValue = rewardValue;
        var script = newQuest.obj.GetComponent<SpendOrbs>();
        script.qm = this;
        script.init(x, na, questID);
        questID++;
        quests.Add(newQuest);
    }

    public void createCraftOrbs(int x, RewardTypes type, int rewardValue)
    {
        quest newQuest = new quest();
        newQuest.obj = Instantiate(prefabs[9].obj, Vector3.zero, Quaternion.identity, parent);
        newQuest.type = QuestType.craftOrbs;
        newQuest.completed = false;
        newQuest.questID = questID;
        newQuest.reward = type;
        newQuest.rewardValue = rewardValue;
        var script = newQuest.obj.GetComponent<CraftOrbs>();
        script.qm = this;
        script.init(x, na, questID);
        questID++;
        quests.Add(newQuest);
    }

    public void createCompleteLevel(int x, RewardTypes type, int rewardValue)
    {
        quest newQuest = new quest();
        newQuest.obj = Instantiate(prefabs[10].obj, Vector3.zero, Quaternion.identity, parent);
        newQuest.type = QuestType.completeLevels;
        newQuest.completed = false;
        newQuest.questID = questID;
        newQuest.reward = type;
        newQuest.rewardValue = rewardValue;
        var script = newQuest.obj.GetComponent<CompleteLevel>();
        script.qm = this;
        script.init(x, na, questID);
        questID++;
        quests.Add(newQuest);
    }

    public void createFindScraps(int x, RewardTypes type, int rewardValue)
    {
        quest newQuest = new quest();
        newQuest.obj = Instantiate(prefabs[11].obj, Vector3.zero, Quaternion.identity, parent);
        newQuest.type = QuestType.findScraps;
        newQuest.completed = false;
        newQuest.questID = questID;
        newQuest.reward = type;
        newQuest.rewardValue = rewardValue;
        var script = newQuest.obj.GetComponent<FindFragments>();
        script.qm = this;
        script.init(x, na, questID);
        questID++;
        quests.Add(newQuest);
    }

    public void createUseAbilities(int x, RewardTypes type, int rewardValue)
    {
        quest newQuest = new quest();
        newQuest.obj = Instantiate(prefabs[12].obj, Vector3.zero, Quaternion.identity, parent);
        newQuest.type = QuestType.ability;
        newQuest.completed = false;
        newQuest.questID = questID;
        newQuest.reward = type;
        newQuest.rewardValue = rewardValue;
        var script = newQuest.obj.GetComponent<UseAbilities>();
        script.qm = this;
        script.init(x, na, questID);
        questID++;
        quests.Add(newQuest);
    }

    public void update(QuestType t, int x, Gear gear)
    {
        foreach (quest item in quests)
        {
            if (item.type == QuestType.unlockGear)
            {
                item.obj.GetComponent<UnlockGear>().update(x, gear);
            } else if (item.type == QuestType.getGearToLevel)
            {
                item.obj.GetComponent<GetGearLevel>().update(x, gear);
            }
        }
    }


    public void update(QuestType t, int x)
    {
        foreach (quest item in quests)
        {
            if (item.type == t)
            {
                bool check = false;
                switch (t)
                {
                    case QuestType.openCrate:
                        item.obj.GetComponent<OpenCrates>().update(x);
                        break;
                    case QuestType.killMonster:
                        item.obj.GetComponent<KillMonstersQuest>().update(x);
                        break;
                    case QuestType.killBoss:
                        item.obj.GetComponent<KillBosses>().update(x);
                        break;
                    case QuestType.mergeDamage:
                        item.obj.GetComponent<MergeDamage>().update(x);
                        break;
                    case QuestType.highScore:
                        item.obj.GetComponent<HighTile>().update(x);
                        break;
                    case QuestType.killDucks:
                        item.obj.GetComponent<KillDucks>().update(x);
                        break;
                    case QuestType.spendOrbs:
                        item.obj.GetComponent<SpendOrbs>().update(x);
                        break;
                    case QuestType.craftOrbs:
                        item.obj.GetComponent<CraftOrbs>().update(x);
                        break;
                    case QuestType.completeLevels:
                        item.obj.GetComponent<CompleteLevel>().update(x);
                        break;
                    case QuestType.findScraps:
                        item.obj.GetComponent<FindFragments>().update(x);
                        break;
                    case QuestType.ability:
                        item.obj.GetComponent<UseAbilities>().update(x);
                        break;

                }
            }
        }
    }

    public void update(QuestType t, BigInteger x)
    {
        foreach (var item in quests)
        {
            if (item.type == t)
            {
                switch (t)
                {
                    case QuestType.mergeDamage:
                        item.obj.GetComponent<MergeDamage>().update(x);
                        break;
                    case QuestType.highScore:
                        item.obj.GetComponent<HighTile>().update(x);
                        break;
                }
            }
        }
    }

    public void claimQuest(int id)
    {
        quest q = new quest();
        foreach (quest item in quests)
        {
           if (item.questID == id)
            {
                switch(item.reward)
                {
                    case RewardTypes.upgrade:
                        //upgrade unlock
                        break;
                    case RewardTypes.gems:
                        gems.addGems(item.rewardValue);
                        break;
                    case RewardTypes.scraps:
                        for (int i = 0; i < item.rewardValue; i++) { infuse.increaseScraps(); }
                        break;
                    case RewardTypes.timeSkip:
                        gems.calculateMoney(item.rewardValue);
                        break;
                }
                Destroy(item.obj);
                q = item;
            }

        }
        quests.Remove(q);
    }

    public string getString(Gear type)
    {
        switch (type)
        {
            case Gear.starterSword:
                return "Starter Sword";
                break;
            case Gear.begginerBoots:
                return "Begginer Boots";
                break;
            case Gear.roughRing:
                return "Rough Ring";
                break;
            case Gear.ancientAxe:
                return "Ancient Axe";
                break;
            case Gear.briskBand:
                return "Brisk Band";
                break;
            case Gear.chthonicChestplate:
                return "Chthonic Chestplate";
                break;
            case Gear.cuddlyClub:
                return "Cuddly Club";
                break;
            case Gear.nobleNecklace:
                return "Noble Necklace";
                break;
            case Gear.squiresSword:
                return "Squire's Sword";
                break;
            case Gear.advancedAxe:
                return "Advanced Axe";
                break;
            case Gear.gloriusGloves:
                return "Glorius Gloves";
                break;
            case Gear.brashBow:
                return "Brash Bow";
                break;
            case Gear.neptunesNecklace:
                return "Neptune's Necklace";
                break;
            case Gear.shinyShield:
                return "Shiny Shield";
                break;
            case Gear.sacredSword:
                return "Sacred Sword";
                break;
            case Gear.chaoticCrossbow:
                return "Chaotic Crossbow";
                break;
            case Gear.rampantRing:
                return "Rampant Ring";
                break;
            case Gear.sorcerersStaff:
                return "Sorcerer's Staff";
                break;
            case Gear.corruptedCape:
                return "Corrupted Cape";
                break;
        }
        return "";
    }
}


namespace QUEST
{

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
    public enum RewardTypes
    {
        upgrade,
        gems,
        scraps,
        timeSkip
    }



    [Serializable]
    public struct quest
    {
        public QuestType type;
        public GameObject obj;
        public bool completed;
        public RewardTypes reward;
        public int rewardValue;
        public int questID;
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

    [Serializable]
    public enum Gear
    {
        starterSword,
        begginerBoots,
        roughRing,
        ancientAxe,
        briskBand,
        chthonicChestplate,
        cuddlyClub,
        nobleNecklace,
        squiresSword,
        advancedAxe,
        gloriusGloves,
        brashBow,
        neptunesNecklace,
        shinyShield,
        sacredSword,
        chaoticCrossbow,
        corruptedCape,
        rampantRing,
        sorcerersStaff
    }
}