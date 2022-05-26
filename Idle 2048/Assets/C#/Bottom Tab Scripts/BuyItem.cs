using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Numerics;

public class BuyItem : MonoBehaviour
{
    public BigInteger price = new BigInteger();
    public BigInteger originalPrice = new BigInteger();
    public CoinsDisplay coinsDisplay;
    public Text ItemDisplayTXT;
    public Text priceText;
    public Text DPStext;
    public int ItemOwned;
    public BigInteger dpsValue;
    public Damage damage;
    private float priceIncrement;
    public int itemNumber;
    private bool bought;
    public GameManager gm;
    public int upgradeNum;
    public bool upgrade;
    public GameObject panel;
    public BigInteger baseDamage;
    public float multiplier;
    public AdManager ads;
    public NotificationAnimation upgradeAnimation;
    public Ability1 ability1;
    public Ability2 ability2;
    public Ability3 ability3;
    public FormatNumber fn;
    private float crateChanceStart;

    void Start()
    {
        StartCoroutine(StartCo());
    }

    private IEnumerator StartCo()
    {
        yield return new WaitForSeconds(0.5f);
        if (upgrade)
        {
            price = coinsDisplay.pricesUpgrades[upgradeNum - 1];
        }
        else
        {
            dpsValue = coinsDisplay.damageValues[itemNumber];
            price = coinsDisplay.prices[itemNumber];
        }
        originalPrice = price;
        multiplier = 1f;
        baseDamage = dpsValue;
        bought = false;
        ItemOwned = 0;
        if (!upgrade) ItemDisplayTXT.text = "X " + ItemOwned.ToString();

        priceIncrement = 1.07f;

        if (upgrade) updatePriceUpgrades();
        else updatePriceStart();
    }

    public void updateDiscount(float d)
    {
        d = (1 - d)*10;
        BigInteger bigIntFromDouble = new BigInteger(d);
        price *= bigIntFromDouble;
        price /= 10;

        if (upgrade)
            updatePriceUpgrades();
        else
            updatePrice();
    }

    public void reset()
    {
        price = originalPrice;
        ItemOwned = 0;
        dpsValue = baseDamage;
        bought = false;
        if (!upgrade) ItemDisplayTXT.text = "X " + ItemOwned.ToString();
        if (upgrade) updatePriceUpgrades();
        else updatePriceStart();
    }

    public void buyItem()
    {
        if (coinsDisplay.Coins >= price)
        {
            damage.addDPS(dpsValue, itemNumber);
            coinsDisplay.addCoins(-price);
            ItemOwned++;
            if(ItemOwned == 10)
            {
                damage.gearUpgrades[((itemNumber+1) * 4) - 4].SetActive(true);
            }else if (ItemOwned == 25)
            {
                damage.gearUpgrades[((itemNumber+1) * 4) - 3].SetActive(true);
            }
            else if (ItemOwned == 50)
            {
                damage.gearUpgrades[((itemNumber+1) * 4) - 2].SetActive(true);
            }
            else if (ItemOwned == 100)
            {
                damage.gearUpgrades[((itemNumber+1) * 4) - 1].SetActive(true);
            }

            BigInteger m = new BigInteger(multiplier * 100);
            dpsValue = (baseDamage * ItemOwned * m)/100;
            ItemDisplayTXT.text = "X " + ItemOwned.ToString();

            BigInteger a = new BigInteger(100*(Math.Pow(priceIncrement , ItemOwned - 1)));
            price = (a* originalPrice)/100;

            if(upgrade)
                updatePriceUpgrades();
            else
                updatePrice();
        }
    }

    public void updatePriceStart()
    {
        priceText.text = fn.formatNumberBigNumber(price, false) + " Coins";
        DPStext.text = "(" + fn.formatNumberBigNumber(dpsValue, false) + ")";
        coinsDisplay.prices[itemNumber] = price;
    }

    public void updatePrice()
    {
        priceText.text = fn.formatNumberBigNumber(price, false) + " Coins";
        DPStext.text = fn.formatNumberBigNumber(dpsValue,false);
        coinsDisplay.prices[itemNumber] = price;
    }

    public void updatePriceUpgrades()
    {
        priceText.text = fn.formatNumberBigNumber(price,false) + " Coins";
        coinsDisplay.pricesUpgrades[upgradeNum - 1] = price;
    }

    public void buyCrate()
    {
        if(bought == false && coinsDisplay.Coins >= price)
        {
            coinsDisplay.addCoins(-price);
            priceText.text = "Bought";
            bought = true;
            crateChanceStart += 0.01f;
            gm.crateChance = crateChanceStart;
            StartCoroutine(ads.showCrateAd());
            panel.SetActive(false);
        }        
    }

    public void upCrateChance(float chance)
    {
        if (bought) gm.crateChance += chance;
        else crateChanceStart += chance;
    }

    public void mergeTileLevel()
    {
        if (coinsDisplay.Coins >= price)
        {
            coinsDisplay.addCoins(-price);
            coinsDisplay.pricesUpgrades[upgradeNum - 1] = price;
            price *= 100000;
            updatePriceUpgrades();
            gm.mergeUpgradeChance += 0.1f;
        }
    }

    public void automationUpgrade()
    {
        if (coinsDisplay.Coins >= price)
        {
            coinsDisplay.addCoins(-price);
            coinsDisplay.pricesUpgrades[upgradeNum - 1] = price;
            bought = true;
            gm.randomShift = true;
            gm.showButton();
            gm.randomShiftTimer = 3f;
            panel.SetActive(false);
        }
    }

    public void IncreaseDPS()
    {
        if (coinsDisplay.Coins >= price)
        {
            coinsDisplay.addCoins(-price);
            coinsDisplay.pricesUpgrades[upgradeNum - 1] = price;
            bought = true;
            damage.changeMultiplier(0.1f);
            panel.SetActive(false);
        }
    }

    public void swordMultiplier()
    {
        if (coinsDisplay.Coins >= price)
        {
            coinsDisplay.addCoins(-price);
            coinsDisplay.pricesUpgrades[upgradeNum - 1] = price;
            bought = true;
            damage.changeItemMultiplier(0,1f);
            panel.SetActive(false);
        }
    }

    public void instantCrate()
    {
        if (coinsDisplay.Coins >= price)
        {
            coinsDisplay.addCoins(-price);
            coinsDisplay.pricesUpgrades[upgradeNum - 1] = price;
            bought = true;
            gm.instantCrateChance = 0.1f;
            panel.SetActive(false);
        }
    }

    public void buyAbility(int x)
    {
        if (coinsDisplay.Coins >= price)
        {
            coinsDisplay.addCoins(-price);
            coinsDisplay.pricesUpgrades[upgradeNum - 1] = price;
            switch(x)
            {
                case 1:
                    ability1.buyAbility1();
                    break;
                case 2:
                    ability2.buyAbility2();
                    break;
                case 3:
                    ability3.buyAbility3();
                    break;
            }
            panel.SetActive(false);
        }
    }


    public void buyGearUpgrade(int x)
    {
        if (coinsDisplay.Coins >= price)
        {
            coinsDisplay.addCoins(-price);
            coinsDisplay.pricesUpgrades[upgradeNum - 1] = price;
            damage.itemMultipliers[x] += 1;
            panel.SetActive(false);
        }
    }
}
