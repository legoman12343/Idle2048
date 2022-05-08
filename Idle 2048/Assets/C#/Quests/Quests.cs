using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Quests : MonoBehaviour
{
    public List<Image> buttons;
    public List<progressbar> progressbars;
    private int monsterKillCount;
    private int monsterKillTarget;

    void Start()
    {
        monsterKillCount = 0;
        monsterKillTarget = 100;        
    }



    public void updateKillMonstersQuest(int n)
    {
        monsterKillCount += n;
        progressbar bar = progressbars[0];
        bar.slider.value = monsterKillCount;
        if(monsterKillTarget <= monsterKillCount && bar.state == 0)
        {
            bar.slider.GetComponent<GameObject>().SetActive(false);
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

public struct progressbar
{
    public GameObject tab;
    public GameObject button;
    public Slider slider;
    public int state;
}