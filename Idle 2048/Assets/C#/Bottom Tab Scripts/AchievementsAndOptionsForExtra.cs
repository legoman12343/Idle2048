using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchievementsAndOptionsForExtra : MonoBehaviour
{

    public GameObject optionsTab;
    public GameObject achievementsTab;

    public void openOptions()
    {
        if (optionsTab.activeSelf)
        {
            optionsTab.SetActive(false);
        }
        else
        {
            optionsTab.SetActive(true);
        }
    }

    public void openAchievements()
    {
        if (achievementsTab.activeSelf)
        {
            achievementsTab.SetActive(false);
        }
        else
        {
            achievementsTab.SetActive(true);
        }
    }


}
