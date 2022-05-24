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
    public LevelController levelController;

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
        if (gems >= 20)
        {
            calculateMoney(1);
            gems -= 20;
        }
    }

    public void timeSkip2()
    {
        if (gems >= 200)
        {
            calculateMoney(12);
            gems -= 200;
        }
    }

    public void timeSkip3()
    {
        if (gems >= 375)
        {
            calculateMoney(24);
            gems -= 375;
        }
    }

    public void timeSkip4()
    {
        if (gems >= 600)
        {
            calculateMoney(48);
            gems -= 600;
        }
    }

    public void InstantAscension50()
    {
        if (gems >= 400)
        {
            Debug.Log("Instant Ascension 50");
            gems -= 400;
        }
    }

    public void InstantAscension100()
    {
        if (gems >= 400)
        {
            Debug.Log("Instant Ascension 100");
            gems -= 400;
        }
    }

    public void InfusePoints3()
    {
        if (gems >= 600)
        {
            Debug.Log("Infuse Points 3");
            gems -= 600;
        }
    }

    public void background1()
    {
        if (gems >= 600)
        {
            Debug.Log("background1 preview");
        }
    }


    public void doubleCoins()
    {
        if (gems >= 400)
        {
            levelController.permMultiplierCoins = 15;
            gems -= 400;
        }
    }


    //INSERT FUNC
    public void doubleDPS()
    {
        if (gems >= 400)
        {
            Debug.Log("Double DPS");
            gems -= 400;
        }
    }

    public void calculateMoney(int time)
    {
        BigInteger health = level.getMonsterHealth();
        BigInteger dps = damage.getDPS();
        BigInteger money = ((time * 60 * 60) / (health / dps)) * level.getMonsterCoins();
        
        moneyScript.addCoins(money);
    }

}
