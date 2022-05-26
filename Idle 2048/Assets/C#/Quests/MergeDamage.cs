using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Numerics;

public class MergeDamage : MonoBehaviour
{

    public progressbar bar;
    private BigInteger Count;
    private BigInteger Target;
    private bool Completed;
    public NotificationAnimation notificationAnimation;


    public void init(BigInteger target, NotificationAnimation na)
    {
        bar.state = 0;
        Count = 0;
        Target = target;
        bar.tab.SetActive(true);
        bar.sliderParent.SetActive(true);
        bar.slider.maxValue = 100;
        bar.slider.value = 0;
        bar.button.SetActive(false);
        bar.text.text = Count.ToString() + " of " + Target.ToString();
        bar.title.text = "Do " + target + " Merge Damage";
        bar.description.text = "To complete this quest, do " + target.ToString() + " damage by merging tiles.";
        Completed = false;
    }

    public bool update(BigInteger n)
    {
        Count += n;
        bar.slider.value = (float)(Count / Target) * 100;
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

    public void claimMergeDamage()
    {
        notificationAnimation.stopAnimation();
        //reward
        Destroy(gameObject);
    }
}
