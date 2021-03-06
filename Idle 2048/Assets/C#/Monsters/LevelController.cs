using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Numerics;
using QUEST;

public class LevelController : MonoBehaviour
{
    public TextMeshProUGUI levelCountCurrent;
    public TextMeshProUGUI levelCountNext;
    public int level;
    public int levelMax;
    public int killCount;
    public int requiredKills;
    public bool ProgressMode;
    public GameObject forwardsButton;
    public GameObject backButton;
    public GameObject progressModeCancel;
    public MonsterPrefabStuff MonsterScript;
    public Slider killSlider;
    public Sprite Complete;
    public Sprite notComplete;
    public GameObject levelCountNextOb;
    public int permMultiplierCoins;
    public QuestManager qm;

    // Start is called before the first frame update
    void Start()
    {
        permMultiplierCoins = 10;
        ProgressMode = true;
        requiredKills = 10;
        levelMax = 1;
        killCount = 0;
        level = 1;
        levelCountCurrent.text = level.ToString();
        levelCountNext.text = (level + 1).ToString();
        killSlider.value = killCount;
    }

    // Update is called once per frame
    public void LevelUpdate()
    {
        killSlider.value = killCount;
        levelCountCurrent.text = level.ToString();
        levelCountNext.text = (level + 1).ToString();
        if (ProgressMode == true)
        {
            if (killCount == requiredKills)
            {
                if (level == levelMax) { levelMax++; qm.update(QuestType.completeLevels, levelMax); }

                level++;

                UpdateStuff();
            }
        }
    }

    public void reset()
    {
        ProgressMode = true;
        level = 1;
        levelMax = 1;
        killCount = 0;
        requiredKills = 10;
        killSlider.value = killCount;
        levelCountCurrent.text = level.ToString();
        levelCountNext.text = (level + 1).ToString();
        UpdateStuff();
        MonsterScript.spawnMonster();
    }

    void UpdateStuff()
    {
        if (level == 1) backButton.SetActive(false);
        else backButton.SetActive(true);
        if (level == levelMax) forwardsButton.SetActive(false);
        else forwardsButton.SetActive(true);
        if (level < levelMax) levelCountNextOb.GetComponent<Image>().sprite = Complete;
        else levelCountNextOb.GetComponent<Image>().sprite = notComplete;
    }

    public void decreaseLevel()
    {
        level--;
        if (level % 10 == 0) killCount = 1;
        else killCount = 10;
        killSlider.value = killCount;
        ProgressMode = false;
        progressModeCancel.SetActive(true);
        forwardsButton.SetActive(true);
        MonsterScript.DecreaseLevel();
        UpdateStuff();
        levelCountCurrent.text = level.ToString();
        levelCountNext.text = (level + 1).ToString();
    }

    public void increaseLevel()
    {
        level++;
        if (level != levelMax && level % 10 == 0) killCount = 1;
        else if (level != levelMax && level % 10 != 0) killCount = 10;
        else killCount = 0;
        if (level == levelMax)
        {
            ProgressMode = true;
            progressModeCancel.SetActive(false);
        }
        killSlider.value = killCount;
        MonsterScript.IncreaseLevel();
        UpdateStuff();
        levelCountCurrent.text = level.ToString();
        levelCountNext.text = (level + 1).ToString();
    }

    public void progressModeToggle()
    {
        if (ProgressMode)
        {
            ProgressMode = false;
            progressModeCancel.SetActive(true);
        }
        else
        {
            ProgressMode = true;
            progressModeCancel.SetActive(false);
        }
    }

    public BigInteger getMonsterHealth()
    {
        if (level <= 140)
        {
            double temp = Convert.ToDouble(level);
            return (int)Math.Ceiling((10.00 *( temp - 1.00 + Math.Pow(1.55, temp - 1.00))));
        }
        else
        {
            double temp = Convert.ToDouble(level);
            return new BigInteger(Math.Ceiling((10.00 * (139.00 + Math.Pow(1.55, 139.00) * Math.Pow(1.145, (temp - 140.00))))));
        }
    }

    public BigInteger getMonsterCoins()
    {
        BigInteger temp = ((getMonsterHealth() / 15) * permMultiplierCoins)/10;
        if(temp > 0)
        {
            return temp;
        }
        return 1;
        
    }
}
