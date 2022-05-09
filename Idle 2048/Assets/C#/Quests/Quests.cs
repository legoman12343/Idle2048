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

    void Start()
    {
        initKillMonsters();
    }

    private void initKillMonsters()
    {
        monsterKillCount = 0;
        monsterKillTarget = 2;
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