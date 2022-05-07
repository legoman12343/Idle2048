using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelController : MonoBehaviour
{
    public TextMeshProUGUI levelCount;
    public TextMeshProUGUI killCountText;
    public int level;
    public int killCount;
    public int requiredKills;
    // Start is called before the first frame update
    void Start()
    {
        requiredKills = 10;
        killCount = 0;
        level = 9;
        levelCount.text = level.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        killCountText.text = killCount.ToString() + "/" + requiredKills.ToString();
        if (killCount == requiredKills)
        {
            level++;
            levelCount.text = level.ToString();
            killCount = 0;
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
