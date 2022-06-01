using System.Collections;
using System.Collections.Generic;
using System;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using System.Numerics;
using QUEST;
using Vector3 = UnityEngine.Vector3;

public class CraftOrbs : MonoBehaviour
{
    public progressbar bar;
    private int Count;
    private int Target;
    private bool Completed;
    public NotificationAnimation notificationAnimation;
    public QuestManager qm;
    private int questNumber;


    public void init(int target, NotificationAnimation na, int questID)
    {
        questNumber = questID;
        notificationAnimation = na;
        bar.state = 0;
        Count = 0;
        Target = target;
        bar.tab.SetActive(true);
        bar.sliderParent.SetActive(true);
        bar.slider.maxValue = 100;
        bar.slider.value = 0;
        bar.button.SetActive(false);
        bar.text.text = Count.ToString() + " of " + Target.ToString();
        bar.title.text = "Craft " + target + "Infusion Orbs";
        bar.description.text = "To complete this quest, craft " + target + " infusion orbs using the alter in the 'Gear' section";
        Vector3 v = bar.tab.GetComponent<Transform>().position;
        v = new Vector3(v.x, v.y, 0);
        Completed = false;
    }

    public void update(int n)
    {
        Count += n;
        float temp = (float)((Count * 100) / Target);
        bar.slider.value = temp;
        bar.text.text = Count.ToString() + " of " + Target.ToString();
        if (Target <= Count && bar.state == 0 && !Completed)
        {
            bar.sliderParent.SetActive(false);
            bar.button.SetActive(true);
            bar.state = 1;
            notificationAnimation.startAnimation();
            Completed = true;
        }
    }

    public void claimCraftOrbs()
    {
        qm.claimQuest(questNumber);
    }
}

