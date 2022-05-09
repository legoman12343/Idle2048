using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class Quests : MonoBehaviour
{
    [SerializeField] public List<progressbar> progressbars;
    private int monsterKillCount;
    private int monsterKillTarget;
    private int bossKillCount;
    private int bossKillTarget;
    private int mergeDamage;
    private int mergeDamageTarget;
    private int tileLevel;
    private int tileLevelTarget;
    private int crateCount;
    private int crateTarget;

    void Start()
    {
        initKillMonsters();
        initKillBoss();
        initMergeDamage();
        initTileLevel();
        initOpenCrates();
    }

    private void initOpenCrates()
    {
        crateCount = 0;
        crateTarget = 20;
        progressbars[4].slider.maxValue = crateTarget;
        progressbars[4].slider.value = 0;
        progressbars[4].button.SetActive(false);
        progressbars[4].text.text = crateCount.ToString() + " of " + crateTarget.ToString();
    }

    public void updateOpenCrates(int n)
    {
        crateCount = n;
        progressbar bar = progressbars[4];
        bar.slider.value = crateCount;
        bar.text.text = crateCount.ToString() + " of " + crateTarget.ToString();
        if (crateTarget <= crateCount && bar.state == 0)
        {
            bar.sliderParent.SetActive(false);
            bar.button.SetActive(true);
            bar.state = 1;

        }
    }

    public void claimOpenCrates()
    {
        //unlock upgrade
        progressbars[4].tab.SetActive(false);
    }

    private void initTileLevel()
    {
        tileLevel = 0;
        tileLevelTarget = 10;
        progressbars[3].slider.maxValue = tileLevelTarget;
        progressbars[3].slider.value = 0;
        progressbars[3].button.SetActive(false);
        progressbars[3].text.text = tileLevel.ToString() + " of " + tileLevelTarget.ToString();
    }

    public void updateTileLevel(int n)
    {
        if (tileLevel < n)
        {
            tileLevel = n;
            progressbar bar = progressbars[3];
            bar.slider.value = tileLevel;
            bar.text.text = tileLevel.ToString() + " of " + tileLevelTarget.ToString();
            if (tileLevelTarget <= tileLevel && bar.state == 0)
            {
                bar.sliderParent.SetActive(false);
                bar.button.SetActive(true);
                bar.state = 1;
            }
        }
    }

    public void claimTileLevel()
    {
        //unlock upgrade
        progressbars[3].tab.SetActive(false);
    }

    private void initMergeDamage()
    {
        mergeDamage = 0;
        mergeDamageTarget = 1000;
        progressbars[2].slider.maxValue = mergeDamageTarget;
        progressbars[2].slider.value = 0;
        progressbars[2].button.SetActive(false);
        progressbars[2].text.text = mergeDamage.ToString() + " of " + mergeDamageTarget.ToString();
    }

    public void updateMergeDamage(int n)
    {
        mergeDamage += n;
        progressbar bar = progressbars[2];
        bar.slider.value = mergeDamage;
        bar.text.text = mergeDamage.ToString() + " of " + mergeDamageTarget.ToString();
        if (mergeDamageTarget <= mergeDamage && bar.state == 0)
        {
            bar.sliderParent.SetActive(false);
            bar.button.SetActive(true);
            bar.state = 1;
        }
    }

    public void claimMergeDamage()
    {
        //unlock upgrade
        progressbars[2].tab.SetActive(false);
    }

        private void initKillBoss()
    {
        bossKillCount = 0;
        bossKillTarget = 5;
        progressbars[1].slider.maxValue = bossKillTarget;
        progressbars[1].slider.value = 0;
        progressbars[1].button.SetActive(false);
        progressbars[1].text.text = bossKillCount.ToString() + " of " + bossKillTarget.ToString();
    }

    public void updateKillBossQuest(int n)
    {
        bossKillCount += n;
        progressbar bar = progressbars[1];
        bar.slider.value = bossKillCount;
        bar.text.text = bossKillCount.ToString() + " of " + bossKillTarget.ToString();
        if (bossKillTarget <= bossKillCount && bar.state == 0)
        {
            bar.sliderParent.SetActive(false);
            bar.button.SetActive(true);
            bar.state = 1;
        }
    }

    public void claimKillBoss()
    {
        //unlock upgrade
        progressbars[1].tab.SetActive(false);
    }

    private void initKillMonsters()
    {
        monsterKillCount = 0;
        monsterKillTarget = 100;
        progressbars[0].slider.maxValue = monsterKillTarget;
        progressbars[0].slider.value = 0;
        progressbars[0].button.SetActive(false);
        progressbars[0].text.text = monsterKillCount.ToString() + " of " + monsterKillTarget.ToString();
    }

    public void updateKillMonstersQuest(int n)
    {
        monsterKillCount += n;
        progressbar bar = progressbars[0];
        bar.slider.value = monsterKillCount;
        bar.text.text = monsterKillCount.ToString() + " of " + monsterKillTarget.ToString();
        if(monsterKillTarget <= monsterKillCount && bar.state == 0)
        {
            bar.sliderParent.SetActive(false);
            bar.button.SetActive(true);
            bar.state = 1;
        }
    }

    public void claimKillMonsters()
    {
        //unlock upgrade
        progressbars[0].tab.SetActive(false);
    }
}

[Serializable]
public struct progressbar
{
    public Text text;
    public GameObject sliderParent;
    public GameObject tab;
    public GameObject button;
    public Slider slider;
    public int state;
}