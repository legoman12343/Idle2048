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
    // Start is called before the first frame update
    void Start()
    {
        killCount = 0;
        level = 1;
        levelCount.text = level.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        killCountText.text = killCount.ToString() + "/10";
        if (killCount == 10)
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
}
