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
        levelMax = 1;
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

                levelCount.text = level.ToString();

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
        levelCount.text = level.ToString();
        killCount = 10;
        killCountText.text = killCount.ToString() + "/" + requiredKills.ToString();
        ProgressMode = false;
        forwardsButton.SetActive(true);
        StartCoroutine (MonsterScript.DecreaseLevel());
        checkButtons();
    }

    public void increaseLevel()
    {
        level++;
        levelCount.text = level.ToString();
        if (level != levelMax) killCount = 10;
        else killCount = 0;
        ProgressMode = false;
        killCountText.text = killCount.ToString() + "/" + requiredKills.ToString();
        StartCoroutine (MonsterScript.IncreaseLevel());
        checkButtons();
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
