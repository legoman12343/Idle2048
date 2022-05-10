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
    public Sprite Complete;
    public Sprite notComplete;
    public GameObject levelCountNextOb;
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
        levelCountCurrent.text = level.ToString();
        levelCountNext.text = (level + 1).ToString();
        if (ProgressMode == true)
        {
            if (killCount == requiredKills)
            {
                if (level == levelMax) levelMax++;

                level++;

                UpdateStuff();
            }
        }
    }

    void UpdateStuff()
    {
        if (level == 1) backButton.SetActive(false);
        else backButton.SetActive(true);
        if (level == levelMax) forwardsButton.SetActive(false);
        else forwardsButton.SetActive(true);
        if (level < levelMax) levelCountNextOb.GetComponent<Image>().sprite = Complete;
        else levelCountNextOb.GetComponent<Image>().sprite = notComplete;
        levelCountCurrent.text = level.ToString();
        levelCountNext.text = (level + 1).ToString();
    }

    public void decreaseLevel()
    {
        level--;  
        killCount = 10;
        killSlider.value = killCount;
        ProgressMode = false;
        progressModeCancel.SetActive(true);
        forwardsButton.SetActive(true);
        StartCoroutine (MonsterScript.DecreaseLevel());
        UpdateStuff();
    }

    public void increaseLevel()
    {
        level++;
        if (level != levelMax) killCount = 10;
        else killCount = 0;
        if (level == levelMax)
        {
            ProgressMode = true;
            progressModeCancel.SetActive(false);
        }
        killSlider.value = killCount;
        StartCoroutine (MonsterScript.IncreaseLevel());
        UpdateStuff();
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
        if (level <= 140)
        {
            double temp = Convert.ToDouble(level);
            return (int)Math.Ceiling((10.00 *( temp - 1.00 + Math.Pow(1.55, temp - 1.00))));
        }
        else
        {
            double temp = Convert.ToDouble(level);
            return (int)Math.Ceiling((10.00 * (139.00 + Math.Pow(1.55, 139.00) * Math.Pow(1.145, (temp - 140.00)))));
        }
    }

    public int getMonsterCoins()
    {
        int temp = (int)Math.Ceiling(Convert.ToDouble(getMonsterHealth() / 15));
        if(temp > 0)
        {
            return temp;
        }
        return 1;
        
    }
}
