using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Numerics;

public class Gems : MonoBehaviour
{
    public int gems;
    public TextMeshProUGUI gemText;
    public FormatNumber fn;
    public LevelController level;
    public Damage damage;
    public CoinsDisplay moneyScript;

    void Start()
    {
        gems = 0;
        gemText.text = fn.formatNumber(gems,false);
    }


    public void addGems(int n)
    {
        gems += n;
        gemText.text = fn.formatNumber(gems, false);
    }

    public void timeSkip1()
    {
        calculateMoney(1);
    }

    public void timeSkip2()
    {
        calculateMoney(10);
    }

    public void timeSkip3()
    {
        calculateMoney(24);
    }

    public void calculateMoney(int time)
    {
        BigInteger health = level.getMonsterHealth();
       // health /= 10000;
        BigInteger dps = damage.getDPS();
       // dps /= 10000;
        BigInteger money = ((time * 60 * 60) / (health / dps)) * level.getMonsterCoins();
        
        moneyScript.addCoins(money/100);
    }

}
