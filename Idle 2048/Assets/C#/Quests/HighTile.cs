using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Numerics;
using QUEST;

public class HighTile : MonoBehaviour
{
    public progressbar bar;
    private BigInteger Count;
    private BigInteger Target;
    private bool Completed;
    public NotificationAnimation notificationAnimation;
    public QuestManager qm;
    private int questNumber;

    public void init(BigInteger target, NotificationAnimation na, int questID)
    {
        questNumber = questID;
        notificationAnimation = na;
        bar.state = 0;
        Count = 0;
        Target = target;
        bar.tab.SetActive(true);
        bar.slider.maxValue = 100;
        bar.slider.value = 0;
        bar.button.SetActive(false);
        bar.text.text = Count.ToString() + " of " + Target.ToString();
        bar.title.text = "Get a Tile Of Value " + target;
        bar.description.text = "For this quest, you need to get a tile with value " + target.ToString();
        Completed = false;
    }

    public void update(BigInteger n)
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

    public void claimTileLevel()
    {
        qm.claimQuest(questNumber);
    }
}
