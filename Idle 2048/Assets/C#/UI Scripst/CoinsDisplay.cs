using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Numerics;

public class CoinsDisplay : MonoBehaviour
{

    public TextMeshProUGUI CoinsDisplayTXT;
    public BigInteger Coins = new BigInteger();
    public BigInteger CoinsTemp = new BigInteger();
    public List<BigInteger> prices = new List<BigInteger>();
    public List<BigInteger> damageValues = new List<BigInteger>();
    public List<Image> colours;
    public List<BigInteger> pricesUpgrades = new List<BigInteger>();
    public List<Image> coloursUpgrades;
    public Color red;
    public Color green;
    public NotificationAnimation upgradeAnimation;
    public Ascension ascensionScript;
    public Damage damage;
    public FormatNumber fn;

    // Start is called before the first frame update
    public void Start()
    {
        reset();
    }

    public void reset()
    {
        while (damageValues.Count > 0) damageValues.RemoveAt(0);
        while (prices.Count > 0) prices.RemoveAt(0);
        while (pricesUpgrades.Count > 0) pricesUpgrades.RemoveAt(0);
        damageValues.Add(1);
        damageValues.Add(7);
        damageValues.Add(25);
        damageValues.Add(75);
        damageValues.Add(250);
        damageValues.Add(1000);
        damageValues.Add(4000);
        damageValues.Add(11000);
        damageValues.Add(48000);
        damageValues.Add(190000);
        damageValues.Add(800000);
        damageValues.Add(3700000);
        damageValues.Add(17000000);
        damageValues.Add(70000000);
        damageValues.Add(460000000);
        damageValues.Add(3100000000);
        damageValues.Add(20000000000);
        damageValues.Add(135000000000);
        damageValues.Add(820000000000);

        prices.Add(5);
        prices.Add(50);
        prices.Add(250);
        prices.Add(1000);
        prices.Add(4000);
        prices.Add(20000);
        prices.Add(100000);
        prices.Add(400000);
        prices.Add(2500000);
        prices.Add(15000000);
        prices.Add(100000000);
        prices.Add(800000000);
        prices.Add(6500000000);
        prices.Add(50000000000);
        prices.Add(450000000000);
        prices.Add(4000000000000);
        prices.Add(36000000000000);
        prices.Add(320000000000000);
        prices.Add(2700000000000000);
        prices.Add(24000000000000000);

        pricesUpgrades.Add(100);
        pricesUpgrades.Add(100);
        pricesUpgrades.Add(100);
        pricesUpgrades.Add(100);
        pricesUpgrades.Add(100);
        pricesUpgrades.Add(100);
        pricesUpgrades.Add(100);
        pricesUpgrades.Add(100);
        pricesUpgrades.Add(100);
        pricesUpgrades.Add(100);
        pricesUpgrades.Add(100);
        pricesUpgrades.Add(100);
        pricesUpgrades.Add(100);
        pricesUpgrades.Add(100);
        pricesUpgrades.Add(100);
        pricesUpgrades.Add(100);
        pricesUpgrades.Add(100);
        pricesUpgrades.Add(100);
        pricesUpgrades.Add(100);
        pricesUpgrades.Add(100);
        pricesUpgrades.Add(100);
        pricesUpgrades.Add(100);
        pricesUpgrades.Add(100);
        pricesUpgrades.Add(100);
        pricesUpgrades.Add(100);
        pricesUpgrades.Add(100);
        pricesUpgrades.Add(100);
        pricesUpgrades.Add(100);
        pricesUpgrades.Add(100);
        pricesUpgrades.Add(100);
        pricesUpgrades.Add(100);
        pricesUpgrades.Add(100);
        pricesUpgrades.Add(100);
        pricesUpgrades.Add(100);
        pricesUpgrades.Add(100);
        pricesUpgrades.Add(100);
        pricesUpgrades.Add(100);
        pricesUpgrades.Add(100);
        pricesUpgrades.Add(100);
        pricesUpgrades.Add(100);
        pricesUpgrades.Add(100);
        pricesUpgrades.Add(100);
        pricesUpgrades.Add(100);
        pricesUpgrades.Add(100);
        pricesUpgrades.Add(100);
        pricesUpgrades.Add(100);
        pricesUpgrades.Add(100);
        pricesUpgrades.Add(100);
        pricesUpgrades.Add(100);
        pricesUpgrades.Add(100);
        pricesUpgrades.Add(100);
        pricesUpgrades.Add(100);
        pricesUpgrades.Add(100);
        pricesUpgrades.Add(100);
        pricesUpgrades.Add(100);
        pricesUpgrades.Add(100);
        pricesUpgrades.Add(100);
        pricesUpgrades.Add(100);
        pricesUpgrades.Add(100);
        pricesUpgrades.Add(100);
        pricesUpgrades.Add(100);
        pricesUpgrades.Add(100);
        pricesUpgrades.Add(100);
        pricesUpgrades.Add(100);
        pricesUpgrades.Add(100);
        pricesUpgrades.Add(100);
        pricesUpgrades.Add(100);
        pricesUpgrades.Add(100);
        pricesUpgrades.Add(100);
        pricesUpgrades.Add(100);
        pricesUpgrades.Add(100);
        pricesUpgrades.Add(100);
        pricesUpgrades.Add(100);
        pricesUpgrades.Add(100);
        pricesUpgrades.Add(100);
        pricesUpgrades.Add(100);
        pricesUpgrades.Add(100);
        pricesUpgrades.Add(100);
        pricesUpgrades.Add(100);
        pricesUpgrades.Add(100);
        pricesUpgrades.Add(100);
        pricesUpgrades.Add(100);
        pricesUpgrades.Add(100);
        pricesUpgrades.Add(100);
        pricesUpgrades.Add(100);
        pricesUpgrades.Add(100);
        pricesUpgrades.Add(100);
        pricesUpgrades.Add(100);
        pricesUpgrades.Add(100);
        pricesUpgrades.Add(100);
        pricesUpgrades.Add(100);
        pricesUpgrades.Add(100);
        pricesUpgrades.Add(100);
        pricesUpgrades.Add(100);
        pricesUpgrades.Add(100);
        pricesUpgrades.Add(100);
        pricesUpgrades.Add(100);
        pricesUpgrades.Add(100);
        pricesUpgrades.Add(100);
        pricesUpgrades.Add(100);
        pricesUpgrades.Add(100);
        pricesUpgrades.Add(100);
        pricesUpgrades.Add(100);
        pricesUpgrades.Add(100);
        pricesUpgrades.Add(100);
        pricesUpgrades.Add(100);
        pricesUpgrades.Add(100);
        pricesUpgrades.Add(100);
        pricesUpgrades.Add(100);
        pricesUpgrades.Add(100);
        pricesUpgrades.Add(100);
        pricesUpgrades.Add(100);
        pricesUpgrades.Add(100);
        pricesUpgrades.Add(100);
        pricesUpgrades.Add(100);
        pricesUpgrades.Add(100);
        pricesUpgrades.Add(100);
        pricesUpgrades.Add(100);
        pricesUpgrades.Add(100);
        pricesUpgrades.Add(100);
        pricesUpgrades.Add(100);
        pricesUpgrades.Add(100);
        pricesUpgrades.Add(100);
        pricesUpgrades.Add(100);

        Coins = 0;
        string coinsTXT = fn.formatNumberBigNumber(Coins, true);
        CoinsDisplayTXT.text = coinsTXT;
        StartCoroutine(updateButtons());
    }

    public void addCoins(int n)
    {
        Coins += n;
        string coinsTXT = fn.formatNumberBigNumber(Coins,true);
        CoinsDisplayTXT.text = coinsTXT;
        if (Coins >= ((10 ^ 12) * (((ascensionScript.ascensionCoinsHave + 1) ^ 3) - (ascensionScript.ascensionCoinsHave ^ 3)))) ascensionScript.ascensionCoinsHave++;
        StartCoroutine(updateButtons());
    }

    public void addCoins(float n)
    {
        CoinsTemp = Coins;
        
        n *= 100;
        CoinsTemp *= 100;
        BigInteger bigIntFromDouble = new BigInteger(n);
        CoinsTemp += bigIntFromDouble;
        CoinsTemp /= 10000;
        
        Coins = CoinsTemp;
        string coinsTXT = fn.formatNumberBigNumber(Coins,true);
        CoinsDisplayTXT.text = coinsTXT;
        if (Coins >= ((10 ^ 12) * (((ascensionScript.ascensionCoinsHave + 1) ^ 3) - (ascensionScript.ascensionCoinsHave ^ 3)))) ascensionScript.ascensionCoinsHave++;
        StartCoroutine(updateButtons());
    }

    public void addCoins(BigInteger n)
    {
        Coins += n;
        string coinsTXT = fn.formatNumberBigNumber(Coins, true);
        CoinsDisplayTXT.text = coinsTXT;
        if (Coins >= ((10 ^ 12) * (((ascensionScript.ascensionCoinsHave + 1) ^ 3) - (ascensionScript.ascensionCoinsHave ^ 3)))) ascensionScript.ascensionCoinsHave++;
        StartCoroutine(updateButtons());
    }

    public IEnumerator updateButtons()
    {
        bool check = false;
        for (int i = 0; i < prices.Count-1; i++)
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

        for (int i = 0; i < pricesUpgrades.Count-1; i++)
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

        yield return null;
    }

}

