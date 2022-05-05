using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchievementsAndOptionsForExtra : MonoBehaviour
{

    public GameObject optionsTab;
    public GameObject achievementsTab;

    public void openOptions()
    {
        if (optionsTab.active)
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
        if (achievementsTab.active)
        {
            achievementsTab.SetActive(false);
        }
        else
        {
            achievementsTab.SetActive(true);
        }
    }


}
