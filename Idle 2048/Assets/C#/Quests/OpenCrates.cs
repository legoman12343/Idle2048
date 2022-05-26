using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Numerics;

public class OpenCrates : MonoBehaviour
{

    public progressbar bar;
    private int Count;
    private int Target;
    private bool Completed;
    public NotificationAnimation notificationAnimation;


    public void init(int target, NotificationAnimation na)
    {
        bar.state = 0;
        Count = 0;
        Target = target;
        bar.tab.SetActive(true);
        bar.sliderParent.SetActive(true);
        bar.slider.maxValue = Target;
        bar.slider.value = 0;
        bar.button.SetActive(false);
        bar.text.text = Count.ToString() + " of " + Target.ToString();
        bar.title.text = "Destroy " + target + " Crates";
        bar.description.text = "In order to complete this quest, you must smash " + target.ToString() + " crates";
        Completed = false;
    }

    public bool update(int n)
    {
        Count = n;
        bar.slider.value = Count;
        bar.text.text = Count.ToString() + " of " + Target.ToString();
        if (Target <= Count && bar.state == 0 && !Completed)
        {
            bar.sliderParent.SetActive(false);
            bar.button.SetActive(true);
            bar.state = 1;
            notificationAnimation.startAnimation();
            Completed = true;
            return true;
        }
        return false;
    }

    public void claimOpenCrates()
    {
        notificationAnimation.stopAnimation();
        //reward
        Destroy(gameObject);
    }
}
