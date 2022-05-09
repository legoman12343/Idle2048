using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

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
    // Start is called before the first frame update
    void Start()
    {
        ProgressMode = true;
        requiredKills = 10;
        levelMax = 9;
        killCount = 9;
        level = 9;
        levelCountCurrent.text = level.ToString();
        levelCountNext.text = (level + 1).ToString();
        killSlider.value = killCount;
    }

    // Update is called once per frame
    public void LevelUpdate()
    {
        killSlider.value = killCount;
        if (ProgressMode == true)
        {
            if (killCount == requiredKills || (level % 10 == 0 && killCount == 1))
            {
                if (level == levelMax) levelMax++;

                level++;

                levelCountCurrent.text = level.ToString();
                levelCountNext.text = (level + 1).ToString();

                checkButtons();
            }
        }
    }

    void checkButtons()
    {
        if (level == 1) backButton.SetActive(false);
        else backButton.SetActive(true);
        if (level == levelMax) forwardsButton.SetActive(false);
        else forwardsButton.SetActive(true);
    }

    public void decreaseLevel()
    {
        level--;
        levelCountCurrent.text = level.ToString();
        levelCountNext.text = (level + 1).ToString();
        killCount = 10;
        killSlider.value = killCount;
        ProgressMode = false;
        progressModeCancel.SetActive(true);
        forwardsButton.SetActive(true);
        StartCoroutine (MonsterScript.DecreaseLevel());
        checkButtons();
    }

    public void increaseLevel()
    {
        level++;
        levelCountCurrent.text = level.ToString();
        levelCountNext.text = (level + 1).ToString();
        if (level != levelMax) killCount = 10;
        else killCount = 0;
        if (level == levelMax)
        {
            ProgressMode = true;
            progressModeCancel.SetActive(false);
        }
        killSlider.value = killCount;
        StartCoroutine (MonsterScript.IncreaseLevel());
        checkButtons();
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

    public int getMonsterHealth()
    {
        return level * 10;
    }

    public int getMonsterCoins()
    {
        return level;
    }
}
