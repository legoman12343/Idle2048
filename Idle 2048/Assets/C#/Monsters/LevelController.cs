using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelController : MonoBehaviour
{
    public TextMeshProUGUI levelCount;
    public TextMeshProUGUI killCountText;
    public int level;
    public int levelMax;
    public int killCount;
    public int requiredKills;
    public bool ProgressMode;
    public GameObject forwardsButton;
    public GameObject backButton;
    public MonsterPrefabStuff MonsterScript;
    // Start is called before the first frame update
    void Start()
    {
        ProgressMode = true;
        requiredKills = 10;
        killCount = 0;
        level = 1;
        levelCount.text = level.ToString();
        killCountText.text = killCount.ToString() + "/" + requiredKills.ToString();
    }

    // Update is called once per frame
    public void LevelUpdate()
    {
        killCountText.text = killCount.ToString() + "/" + requiredKills.ToString();
        if (ProgressMode == true)
        {
            if (killCount == requiredKills)
            {
                if (level == levelMax) levelMax++;

                level++;

                if (level == levelMax) forwardsButton.SetActive(false);

                levelCount.text = level.ToString();

                if (level == levelMax) killCount = 0;
            }
        }
    }

    public void progressionMode()
    {
        if (ProgressMode) ProgressMode = false;
        else ProgressMode = true;
    }

    public void decreaseLevel()
    {
        level--;
        killCount = 10;
        ProgressMode = false;
        forwardsButton.SetActive(true);
        if (level == 1) backButton.SetActive(false);
        else backButton.SetActive(true);
        MonsterScript.DecreaseLevel();
    }

    public void increaseLevel()
    {
        level++;
        killCount = 10;
        MonsterScript.respawnMonster();
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
