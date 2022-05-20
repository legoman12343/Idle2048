using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CoinsDisplay : MonoBehaviour
{

    public TextMeshProUGUI CoinsDisplayTXT;
    public float Coins;
    public List<int> prices;
    public List<Image> colours;
    public List<int> pricesUpgrades;
    public List<Image> coloursUpgrades;
    public Color red;
    public Color green;
    public NotificationAnimation upgradeAnimation;
    public Damage damage;
    public FormatNumber fn;

    // Start is called before the first frame update
    void Start()
    {
        Coins = 0;
        string coinsTXT = fn.formatNumber(Coins,true);
        CoinsDisplayTXT.text = coinsTXT;
        updateButtons();
    }


    public void addCoins(int n)
    {
        Coins += n;
        string coinsTXT = fn.formatNumber(Coins,true);
        CoinsDisplayTXT.text = coinsTXT;
        updateButtons();
    }

    public void addCoins(float n)
    {
        Coins += n;
        string coinsTXT = fn.formatNumber(Coins,true);
        CoinsDisplayTXT.text = coinsTXT;
        updateButtons();
    }

    public void updateButtons()
    {
        bool check = false;
        for (int i = 0; i < prices.Count; i++)
        {
            if (Coins >= prices[i])
            {
                colours[i].color = green;
                if (damage.itemDamage[i] == 0)
                {
                    check = true;
                }
            }
            
            else
                colours[i].color = red;
        }

        for (int i = 0; i < pricesUpgrades.Count; i++)
        {
            if (Coins >= pricesUpgrades[i])
            {
                coloursUpgrades[i].color = green;
                check = true;
            }
            else
                coloursUpgrades[i].color = red;
        }

        if (check)
            upgradeAnimation.startAnimation();
        else
            upgradeAnimation.stopAnimation();
    }

}

