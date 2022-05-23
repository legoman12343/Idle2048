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
        else updatePrice();
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
            Debug.Log(a);
            price = (a* originalPrice)/100;

            if(upgrade)
                updatePriceUpgrades();
            else
                updatePrice();
        }
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

    public void buyAbility1()
    {
        if (coinsDisplay.Coins >= price)
        {
            coinsDisplay.addCoins(-price);
            coinsDisplay.pricesUpgrades[upgradeNum - 1] = price;
            ability1.buyAbility1();
            panel.SetActive(false);
        }
    }

    public void buyAbility2()
    {
        if (coinsDisplay.Coins >= price)
        {
            coinsDisplay.addCoins(-price);
            coinsDisplay.pricesUpgrades[upgradeNum - 1] = price;
            ability2.buyAbility2();
            panel.SetActive(false);
        }
    }

    public void buyAbility3()
    {
        if (coinsDisplay.Coins >= price)
        {
            coinsDisplay.addCoins(-price);
            coinsDisplay.pricesUpgrades[upgradeNum - 1] = price;
            ability3.buyAbility3();
            panel.SetActive(false);
        }
    }
    //-------------------------------------------------------//
    //--------------------item upgrades----------------------//
    //-------------------------------------------------------//
    public void buyI1U1()
    {
        if (coinsDisplay.Coins >= price)
        {
            coinsDisplay.addCoins(-price);
            coinsDisplay.pricesUpgrades[upgradeNum - 1] = price;
            damage.itemMultipliers[0] *= 2;
            panel.SetActive(false);
        }
    }

    public void buyI1U2()
    {
        if (coinsDisplay.Coins >= price)
        {
            coinsDisplay.addCoins(-price);
            coinsDisplay.pricesUpgrades[upgradeNum - 1] = price;
            damage.itemMultipliers[0] *= 2;
            panel.SetActive(false);
        }
    }

    public void buyI1U3()
    {
        if (coinsDisplay.Coins >= price)
        {
            coinsDisplay.addCoins(-price);
            coinsDisplay.pricesUpgrades[upgradeNum - 1] = price;
            damage.itemMultipliers[0] *= 2;
            panel.SetActive(false);
        }
    }

    

    public void buyI1U4()
    {
        if (coinsDisplay.Coins >= price)
        {
            coinsDisplay.addCoins(-price);
            coinsDisplay.pricesUpgrades[upgradeNum - 1] = price;
            damage.itemMultipliers[0] *= 2;
            panel.SetActive(false);
        }
    }

    public void buyI1U5()
    {
        if (coinsDisplay.Coins >= price)
        {
            coinsDisplay.addCoins(-price);
            coinsDisplay.pricesUpgrades[upgradeNum - 1] = price;
            damage.itemMultipliers[0] *= 2;
            panel.SetActive(false);
        }
    }

    public void buyI1U6()
    {
        if (coinsDisplay.Coins >= price)
        {
            coinsDisplay.addCoins(-price);
            coinsDisplay.pricesUpgrades[upgradeNum - 1] = price;
            damage.itemMultipliers[0] *= 2;
            panel.SetActive(false);
        }
    }

    public void buyI2U1()
    {
        if (coinsDisplay.Coins >= price)
        {
            coinsDisplay.addCoins(-price);
            coinsDisplay.pricesUpgrades[upgradeNum - 1] = price;
            damage.itemMultipliers[1] *= 2;
            panel.SetActive(false);
        }
    }

    public void buyI2U2()
    {
        if (coinsDisplay.Coins >= price)
        {
            coinsDisplay.addCoins(-price);
            coinsDisplay.pricesUpgrades[upgradeNum - 1] = price;
            damage.itemMultipliers[1] *= 2;
            panel.SetActive(false);
        }
    }

    public void buyI2U3()
    {
        if (coinsDisplay.Coins >= price)
        {
            coinsDisplay.addCoins(-price);
            coinsDisplay.pricesUpgrades[upgradeNum - 1] = price;
            damage.itemMultipliers[1] *= 2;
            panel.SetActive(false);
        }
    }

    public void buyI2U4()
    {
        if (coinsDisplay.Coins >= price)
        {
            coinsDisplay.addCoins(-price);
            coinsDisplay.pricesUpgrades[upgradeNum - 1] = price;
            damage.itemMultipliers[1] *= 2;
            panel.SetActive(false);
        }
    }

    public void buyI2U6()
    {
        if (coinsDisplay.Coins >= price)
        {
            coinsDisplay.addCoins(-price);
            coinsDisplay.pricesUpgrades[upgradeNum - 1] = price;
            damage.itemMultipliers[1] *= 2;
            panel.SetActive(false);
        }
    }

    public void buyI2U5()
    {
        if (coinsDisplay.Coins >= price)
        {
            coinsDisplay.addCoins(-price);
            coinsDisplay.pricesUpgrades[upgradeNum - 1] = price;
            damage.itemMultipliers[1] *= 2;
            panel.SetActive(false);
        }
    }

    public void buyI3U1()
    {
        if (coinsDisplay.Coins >= price)
        {
            coinsDisplay.addCoins(-price);
            coinsDisplay.pricesUpgrades[upgradeNum - 1] = price;
            damage.itemMultipliers[2] *= 2;
            panel.SetActive(false);
        }
    }

    public void buyI3U2()
    {
        if (coinsDisplay.Coins >= price)
        {
            coinsDisplay.addCoins(-price);
            coinsDisplay.pricesUpgrades[upgradeNum - 1] = price;
            damage.itemMultipliers[2] *= 2;
            panel.SetActive(false);
        }
    }

    public void buyI3U3()
    {
        if (coinsDisplay.Coins >= price)
        {
            coinsDisplay.addCoins(-price);
            coinsDisplay.pricesUpgrades[upgradeNum - 1] = price;
            damage.itemMultipliers[2] *= 2;
            panel.SetActive(false);
        }
    }

    public void buyI3U4()
    {
        if (coinsDisplay.Coins >= price)
        {
            coinsDisplay.addCoins(-price);
            coinsDisplay.pricesUpgrades[upgradeNum - 1] = price;
            damage.itemMultipliers[2] *= 2;
            panel.SetActive(false);
        }
    }

    public void buyI3U5()
    {
        if (coinsDisplay.Coins >= price)
        {
            coinsDisplay.addCoins(-price);
            coinsDisplay.pricesUpgrades[upgradeNum - 1] = price;
            damage.itemMultipliers[2] *= 2;
            panel.SetActive(false);
        }
    }

    public void buyI3U6()
    {
        if (coinsDisplay.Coins >= price)
        {
            coinsDisplay.addCoins(-price);
            coinsDisplay.pricesUpgrades[upgradeNum - 1] = price;
            damage.itemMultipliers[2] *= 2;
            panel.SetActive(false);
        }
    }

    public void buyI4U1()
    {
        if (coinsDisplay.Coins >= price)
        {
            coinsDisplay.addCoins(-price);
            coinsDisplay.pricesUpgrades[upgradeNum - 1] = price;
            damage.itemMultipliers[3] *= 2;
            panel.SetActive(false);
        }
    }

    public void buyI4U2()
    {
        if (coinsDisplay.Coins >= price)
        {
            coinsDisplay.addCoins(-price);
            coinsDisplay.pricesUpgrades[upgradeNum - 1] = price;
            damage.itemMultipliers[3] *= 2;
            panel.SetActive(false);
        }
    }

    public void buyI4U3()
    {
        if (coinsDisplay.Coins >= price)
        {
            coinsDisplay.addCoins(-price);
            coinsDisplay.pricesUpgrades[upgradeNum - 1] = price;
            damage.itemMultipliers[3] *= 2;
            panel.SetActive(false);
        }
    }

    public void buyI4U4()
    {
        if (coinsDisplay.Coins >= price)
        {
            coinsDisplay.addCoins(-price);
            coinsDisplay.pricesUpgrades[upgradeNum - 1] = price;
            damage.itemMultipliers[3] *= 2;
            panel.SetActive(false);
        }
    }

    public void buyI4U5()
    {
        if (coinsDisplay.Coins >= price)
        {
            coinsDisplay.addCoins(-price);
            coinsDisplay.pricesUpgrades[upgradeNum - 1] = price;
            damage.itemMultipliers[3] *= 2;
            panel.SetActive(false);
        }
    }

    public void buyI4U6()
    {
        if (coinsDisplay.Coins >= price)
        {
            coinsDisplay.addCoins(-price);
            coinsDisplay.pricesUpgrades[upgradeNum - 1] = price;
            damage.itemMultipliers[3] *= 2;
            panel.SetActive(false);
        }
    }

    public void buyI5U1()
    {
        if (coinsDisplay.Coins >= price)
        {
            coinsDisplay.addCoins(-price);
            coinsDisplay.pricesUpgrades[upgradeNum - 1] = price;
            damage.itemMultipliers[4] *= 2;
            panel.SetActive(false);
        }
    }

    public void buyI5U2()
    {
        if (coinsDisplay.Coins >= price)
        {
            coinsDisplay.addCoins(-price);
            coinsDisplay.pricesUpgrades[upgradeNum - 1] = price;
            damage.itemMultipliers[4] *= 2;
            panel.SetActive(false);
        }
    }

    public void buyI5U3()
    {
        if (coinsDisplay.Coins >= price)
        {
            coinsDisplay.addCoins(-price);
            coinsDisplay.pricesUpgrades[upgradeNum - 1] = price;
            damage.itemMultipliers[4] *= 2;
            panel.SetActive(false);
        }
    }

    public void buyI5U4()
    {
        if (coinsDisplay.Coins >= price)
        {
            coinsDisplay.addCoins(-price);
            coinsDisplay.pricesUpgrades[upgradeNum - 1] = price;
            damage.itemMultipliers[4] *= 2;
            panel.SetActive(false);
        }
    }

    public void buyI5U5()
    {
        if (coinsDisplay.Coins >= price)
        {
            coinsDisplay.addCoins(-price);
            coinsDisplay.pricesUpgrades[upgradeNum - 1] = price;
            damage.itemMultipliers[4] *= 2;
            panel.SetActive(false);
        }
    }

    public void buyI5U6()
    {
        if (coinsDisplay.Coins >= price)
        {
            coinsDisplay.addCoins(-price);
            coinsDisplay.pricesUpgrades[upgradeNum - 1] = price;
            damage.itemMultipliers[4] *= 2;
            panel.SetActive(false);
        }
    }

    public void buyI6U1()
    {
        if (coinsDisplay.Coins >= price)
        {
            coinsDisplay.addCoins(-price);
            coinsDisplay.pricesUpgrades[upgradeNum - 1] = price;
            damage.itemMultipliers[5] *= 2;
            panel.SetActive(false);
        }
    }

    public void buyI6U2()
    {
        if (coinsDisplay.Coins >= price)
        {
            coinsDisplay.addCoins(-price);
            coinsDisplay.pricesUpgrades[upgradeNum - 1] = price;
            damage.itemMultipliers[5] *= 2;
            panel.SetActive(false);
        }
    }

    public void buyI6U3()
    {
        if (coinsDisplay.Coins >= price)
        {
            coinsDisplay.addCoins(-price);
            coinsDisplay.pricesUpgrades[upgradeNum - 1] = price;
            damage.itemMultipliers[5] *= 2;
            panel.SetActive(false);
        }
    }

    public void buyI6U4()
    {
        if (coinsDisplay.Coins >= price)
        {
            coinsDisplay.addCoins(-price);
            coinsDisplay.pricesUpgrades[upgradeNum - 1] = price;
            damage.itemMultipliers[5] *= 2;
            panel.SetActive(false);
        }
    }

    public void buyI6U5()
    {
        if (coinsDisplay.Coins >= price)
        {
            coinsDisplay.addCoins(-price);
            coinsDisplay.pricesUpgrades[upgradeNum - 1] = price;
            damage.itemMultipliers[5] *= 2;
            panel.SetActive(false);
        }
    }

    public void buyI6U6()
    {
        if (coinsDisplay.Coins >= price)
        {
            coinsDisplay.addCoins(-price);
            coinsDisplay.pricesUpgrades[upgradeNum - 1] = price;
            damage.itemMultipliers[5] *= 2;
            panel.SetActive(false);
        }
    }

    public void buyI7U1()
    {
        if (coinsDisplay.Coins >= price)
        {
            coinsDisplay.addCoins(-price);
            coinsDisplay.pricesUpgrades[upgradeNum - 1] = price;
            damage.itemMultipliers[6] *= 2;
            panel.SetActive(false);
        }
    }

    public void buyI7U2()
    {
        if (coinsDisplay.Coins >= price)
        {
            coinsDisplay.addCoins(-price);
            coinsDisplay.pricesUpgrades[upgradeNum - 1] = price;
            damage.itemMultipliers[6] *= 2;
            panel.SetActive(false);
        }
    }

    public void buyI7U3()
    {
        if (coinsDisplay.Coins >= price)
        {
            coinsDisplay.addCoins(-price);
            coinsDisplay.pricesUpgrades[upgradeNum - 1] = price;
            damage.itemMultipliers[6] *= 2;
            panel.SetActive(false);
        }
    }

    public void buyI7U4()
    {
        if (coinsDisplay.Coins >= price)
        {
            coinsDisplay.addCoins(-price);
            coinsDisplay.pricesUpgrades[upgradeNum - 1] = price;
            damage.itemMultipliers[6] *= 2;
            panel.SetActive(false);
        }
    }
    public void buyI7U5()
    {
        if (coinsDisplay.Coins >= price)
        {
            coinsDisplay.addCoins(-price);
            coinsDisplay.pricesUpgrades[upgradeNum - 1] = price;
            damage.itemMultipliers[6] *= 2;
            panel.SetActive(false);
        }
    }

    public void buyI7U6()
    {
        if (coinsDisplay.Coins >= price)
        {
            coinsDisplay.addCoins(-price);
            coinsDisplay.pricesUpgrades[upgradeNum - 1] = price;
            damage.itemMultipliers[6] *= 2;
            panel.SetActive(false);
        }
    }


    public void buyI8U1()
    {
        if (coinsDisplay.Coins >= price)
        {
            coinsDisplay.addCoins(-price);
            coinsDisplay.pricesUpgrades[upgradeNum - 1] = price;
            damage.itemMultipliers[7] *= 2;
            panel.SetActive(false);
        }
    }

    public void buyI8U2()
    {
        if (coinsDisplay.Coins >= price)
        {
            coinsDisplay.addCoins(-price);
            coinsDisplay.pricesUpgrades[upgradeNum - 1] = price;
            damage.itemMultipliers[7] *= 2;
            panel.SetActive(false);
        }
    }

    public void buyI8U3()
    {
        if (coinsDisplay.Coins >= price)
        {
            coinsDisplay.addCoins(-price);
            coinsDisplay.pricesUpgrades[upgradeNum - 1] = price;
            damage.itemMultipliers[7] *= 2;
            panel.SetActive(false);
        }
    }

    public void buyI8U4()
    {
        if (coinsDisplay.Coins >= price)
        {
            coinsDisplay.addCoins(-price);
            coinsDisplay.pricesUpgrades[upgradeNum - 1] = price;
            damage.itemMultipliers[7] *= 2;
            panel.SetActive(false);
        }
    }

    public void buyI8U5()
    {
        if (coinsDisplay.Coins >= price)
        {
            coinsDisplay.addCoins(-price);
            coinsDisplay.pricesUpgrades[upgradeNum - 1] = price;
            damage.itemMultipliers[7] *= 2;
            panel.SetActive(false);
        }
    }

    public void buyI8U6()
    {
        if (coinsDisplay.Coins >= price)
        {
            coinsDisplay.addCoins(-price);
            coinsDisplay.pricesUpgrades[upgradeNum - 1] = price;
            damage.itemMultipliers[7] *= 2;
            panel.SetActive(false);
        }
    }

    public void buyI9U1()
    {
        if (coinsDisplay.Coins >= price)
        {
            coinsDisplay.addCoins(-price);
            coinsDisplay.pricesUpgrades[upgradeNum - 1] = price;
            damage.itemMultipliers[8] *= 2;
            panel.SetActive(false);
        }
    }

    public void buyI9U2()
    {
        if (coinsDisplay.Coins >= price)
        {
            coinsDisplay.addCoins(-price);
            coinsDisplay.pricesUpgrades[upgradeNum - 1] = price;
            damage.itemMultipliers[8] *= 2;
            panel.SetActive(false);
        }
    }

    public void buyI9U3()
    {
        if (coinsDisplay.Coins >= price)
        {
            coinsDisplay.addCoins(-price);
            coinsDisplay.pricesUpgrades[upgradeNum - 1] = price;
            damage.itemMultipliers[8] *= 2;
            panel.SetActive(false);
        }
    }

    public void buyI9U4()
    {
        if (coinsDisplay.Coins >= price)
        {
            coinsDisplay.addCoins(-price);
            coinsDisplay.pricesUpgrades[upgradeNum - 1] = price;
            damage.itemMultipliers[8] *= 2;
            panel.SetActive(false);
        }
    }

    public void buyI9U5()
    {
        if (coinsDisplay.Coins >= price)
        {
            coinsDisplay.addCoins(-price);
            coinsDisplay.pricesUpgrades[upgradeNum - 1] = price;
            damage.itemMultipliers[8] *= 2;
            panel.SetActive(false);
        }
    }

    public void buyI9U6()
    {
        if (coinsDisplay.Coins >= price)
        {
            coinsDisplay.addCoins(-price);
            coinsDisplay.pricesUpgrades[upgradeNum - 1] = price;
            damage.itemMultipliers[8] *= 2;
            panel.SetActive(false);
        }
    }

    public void buyI10U1()
    {
        if (coinsDisplay.Coins >= price)
        {
            coinsDisplay.addCoins(-price);
            coinsDisplay.pricesUpgrades[upgradeNum - 1] = price;
            damage.itemMultipliers[9] *= 2;
            panel.SetActive(false);
        }
    }

    public void buyI10U2()
    {
        if (coinsDisplay.Coins >= price)
        {
            coinsDisplay.addCoins(-price);
            coinsDisplay.pricesUpgrades[upgradeNum - 1] = price;
            damage.itemMultipliers[9] *= 2;
            panel.SetActive(false);
        }
    }

    public void buyI10U3()
    {
        if (coinsDisplay.Coins >= price)
        {
            coinsDisplay.addCoins(-price);
            coinsDisplay.pricesUpgrades[upgradeNum - 1] = price;
            damage.itemMultipliers[9] *= 2;
            panel.SetActive(false);
        }
    }

    public void buyI10U4()
    {
        if (coinsDisplay.Coins >= price)
        {
            coinsDisplay.addCoins(-price);
            coinsDisplay.pricesUpgrades[upgradeNum - 1] = price;
            damage.itemMultipliers[9] *= 2;
            panel.SetActive(false);
        }
    }

    public void buyI10U5()
    {
        if (coinsDisplay.Coins >= price)
        {
            coinsDisplay.addCoins(-price);
            coinsDisplay.pricesUpgrades[upgradeNum - 1] = price;
            damage.itemMultipliers[9] *= 2;
            panel.SetActive(false);
        }
    }

    public void buyI10U6()
    {
        if (coinsDisplay.Coins >= price)
        {
            coinsDisplay.addCoins(-price);
            coinsDisplay.pricesUpgrades[upgradeNum - 1] = price;
            damage.itemMultipliers[9] *= 2;
            panel.SetActive(false);
        }
    }

    public void buyI11U1()
    {
        if (coinsDisplay.Coins >= price)
        {
            coinsDisplay.addCoins(-price);
            coinsDisplay.pricesUpgrades[upgradeNum - 1] = price;
            damage.itemMultipliers[10] *= 2;
            panel.SetActive(false);
        }
    }

    public void buyI11U2()
    {
        if (coinsDisplay.Coins >= price)
        {
            coinsDisplay.addCoins(-price);
            coinsDisplay.pricesUpgrades[upgradeNum - 1] = price;
            damage.itemMultipliers[10] *= 2;
            panel.SetActive(false);
        }
    }

    public void buyI11U3()
    {
        if (coinsDisplay.Coins >= price)
        {
            coinsDisplay.addCoins(-price);
            coinsDisplay.pricesUpgrades[upgradeNum - 1] = price;
            damage.itemMultipliers[10] *= 2;
            panel.SetActive(false);
        }
    }

    public void buyI11U4()
    {
        if (coinsDisplay.Coins >= price)
        {
            coinsDisplay.addCoins(-price);
            coinsDisplay.pricesUpgrades[upgradeNum - 1] = price;
            damage.itemMultipliers[10] *= 2;
            panel.SetActive(false);
        }
    }

    public void buyI11U5()
    {
        if (coinsDisplay.Coins >= price)
        {
            coinsDisplay.addCoins(-price);
            coinsDisplay.pricesUpgrades[upgradeNum - 1] = price;
            damage.itemMultipliers[10] *= 2;
            panel.SetActive(false);
        }
    }

    public void buyI11U6()
    {
        if (coinsDisplay.Coins >= price)
        {
            coinsDisplay.addCoins(-price);
            coinsDisplay.pricesUpgrades[upgradeNum - 1] = price;
            damage.itemMultipliers[10] *= 2;
            panel.SetActive(false);
        }
    }

    public void buyI12U1()
    {
        if (coinsDisplay.Coins >= price)
        {
            coinsDisplay.addCoins(-price);
            coinsDisplay.pricesUpgrades[upgradeNum - 1] = price;
            damage.itemMultipliers[11] *= 2;
            panel.SetActive(false);
        }
    }

    public void buyI12U2()
    {
        if (coinsDisplay.Coins >= price)
        {
            coinsDisplay.addCoins(-price);
            coinsDisplay.pricesUpgrades[upgradeNum - 1] = price;
            damage.itemMultipliers[11] *= 2;
            panel.SetActive(false);
        }
    }

    public void buyI12U3()
    {
        if (coinsDisplay.Coins >= price)
        {
            coinsDisplay.addCoins(-price);
            coinsDisplay.pricesUpgrades[upgradeNum - 1] = price;
            damage.itemMultipliers[11] *= 2;
            panel.SetActive(false);
        }
    }

    public void buyI12U4()
    {
        if (coinsDisplay.Coins >= price)
        {
            coinsDisplay.addCoins(-price);
            coinsDisplay.pricesUpgrades[upgradeNum - 1] = price;
            damage.itemMultipliers[11] *= 2;
            panel.SetActive(false);
        }
    }

    public void buyI12U5()
    {
        if (coinsDisplay.Coins >= price)
        {
            coinsDisplay.addCoins(-price);
            coinsDisplay.pricesUpgrades[upgradeNum - 1] = price;
            damage.itemMultipliers[11] *= 2;
            panel.SetActive(false);
        }
    }

    public void buyI12U6()
    {
        if (coinsDisplay.Coins >= price)
        {
            coinsDisplay.addCoins(-price);
            coinsDisplay.pricesUpgrades[upgradeNum - 1] = price;
            damage.itemMultipliers[11] *= 2;
            panel.SetActive(false);
        }
    }

    public void buyI13U1()
    {
        if (coinsDisplay.Coins >= price)
        {
            coinsDisplay.addCoins(-price);
            coinsDisplay.pricesUpgrades[upgradeNum - 1] = price;
            damage.itemMultipliers[12] *= 2;
            panel.SetActive(false);
        }
    }

    public void buyI13U2()
    {
        if (coinsDisplay.Coins >= price)
        {
            coinsDisplay.addCoins(-price);
            coinsDisplay.pricesUpgrades[upgradeNum - 1] = price;
            damage.itemMultipliers[12] *= 2;
            panel.SetActive(false);
        }
    }

    public void buyI13U3()
    {
        if (coinsDisplay.Coins >= price)
        {
            coinsDisplay.addCoins(-price);
            coinsDisplay.pricesUpgrades[upgradeNum - 1] = price;
            damage.itemMultipliers[12] *= 2;
            panel.SetActive(false);
        }
    }

    public void buyI13U4()
    {
        if (coinsDisplay.Coins >= price)
        {
            coinsDisplay.addCoins(-price);
            coinsDisplay.pricesUpgrades[upgradeNum - 1] = price;
            damage.itemMultipliers[12] *= 2;
            panel.SetActive(false);
        }
    }

    public void buyI13U5()
    {
        if (coinsDisplay.Coins >= price)
        {
            coinsDisplay.addCoins(-price);
            coinsDisplay.pricesUpgrades[upgradeNum - 1] = price;
            damage.itemMultipliers[12] *= 2;
            panel.SetActive(false);
        }
    }

    public void buyI13U6()
    {
        if (coinsDisplay.Coins >= price)
        {
            coinsDisplay.addCoins(-price);
            coinsDisplay.pricesUpgrades[upgradeNum - 1] = price;
            damage.itemMultipliers[12] *= 2;
            panel.SetActive(false);
        }
    }

    public void buyI14U1()
    {
        if (coinsDisplay.Coins >= price)
        {
            coinsDisplay.addCoins(-price);
            coinsDisplay.pricesUpgrades[upgradeNum - 1] = price;
            damage.itemMultipliers[13] *= 2;
            panel.SetActive(false);
        }
    }

    public void buyI14U2()
    {
        if (coinsDisplay.Coins >= price)
        {
            coinsDisplay.addCoins(-price);
            coinsDisplay.pricesUpgrades[upgradeNum - 1] = price;
            damage.itemMultipliers[13] *= 2;
            panel.SetActive(false);
        }
    }

    public void buyI14U3()
    {
        if (coinsDisplay.Coins >= price)
        {
            coinsDisplay.addCoins(-price);
            coinsDisplay.pricesUpgrades[upgradeNum - 1] = price;
            damage.itemMultipliers[13] *= 2;
            panel.SetActive(false);
        }
    }

    public void buyI14U4()
    {
        if (coinsDisplay.Coins >= price)
        {
            coinsDisplay.addCoins(-price);
            coinsDisplay.pricesUpgrades[upgradeNum - 1] = price;
            damage.itemMultipliers[13] *= 2;
            panel.SetActive(false);
        }
    }

    public void buyI14U5()
    {
        if (coinsDisplay.Coins >= price)
        {
            coinsDisplay.addCoins(-price);
            coinsDisplay.pricesUpgrades[upgradeNum - 1] = price;
            damage.itemMultipliers[13] *= 2;
            panel.SetActive(false);
        }
    }

    public void buyI14U6()
    {
        if (coinsDisplay.Coins >= price)
        {
            coinsDisplay.addCoins(-price);
            coinsDisplay.pricesUpgrades[upgradeNum - 1] = price;
            damage.itemMultipliers[13] *= 2;
            panel.SetActive(false);
        }
    }

    public void buyI15U1()
    {
        if (coinsDisplay.Coins >= price)
        {
            coinsDisplay.addCoins(-price);
            coinsDisplay.pricesUpgrades[upgradeNum - 1] = price;
            damage.itemMultipliers[14] *= 2;
            panel.SetActive(false);
        }
    }

    public void buyI15U2()
    {
        if (coinsDisplay.Coins >= price)
        {
            coinsDisplay.addCoins(-price);
            coinsDisplay.pricesUpgrades[upgradeNum - 1] = price;
            damage.itemMultipliers[14] *= 2;
            panel.SetActive(false);
        }
    }

    public void buyI15U3()
    {
        if (coinsDisplay.Coins >= price)
        {
            coinsDisplay.addCoins(-price);
            coinsDisplay.pricesUpgrades[upgradeNum - 1] = price;
            damage.itemMultipliers[14] *= 2;
            panel.SetActive(false);
        }
    }

    public void buyI15U4()
    {
        if (coinsDisplay.Coins >= price)
        {
            coinsDisplay.addCoins(-price);
            coinsDisplay.pricesUpgrades[upgradeNum - 1] = price;
            damage.itemMultipliers[14] *= 2;
            panel.SetActive(false);
        }
    }

    public void buyI15U5()
    {
        if (coinsDisplay.Coins >= price)
        {
            coinsDisplay.addCoins(-price);
            coinsDisplay.pricesUpgrades[upgradeNum - 1] = price;
            damage.itemMultipliers[14] *= 2;
            panel.SetActive(false);
        }
    }

    public void buyI15U6()
    {
        if (coinsDisplay.Coins >= price)
        {
            coinsDisplay.addCoins(-price);
            coinsDisplay.pricesUpgrades[upgradeNum - 1] = price;
            damage.itemMultipliers[14] *= 2;
            panel.SetActive(false);
        }
    }

    public void buyI16U1()
    {
        if (coinsDisplay.Coins >= price)
        {
            coinsDisplay.addCoins(-price);
            coinsDisplay.pricesUpgrades[upgradeNum - 1] = price;
            damage.itemMultipliers[15] *= 2;
            panel.SetActive(false);
        }
    }

    public void buyI16U2()
    {
        if (coinsDisplay.Coins >= price)
        {
            coinsDisplay.addCoins(-price);
            coinsDisplay.pricesUpgrades[upgradeNum - 1] = price;
            damage.itemMultipliers[15] *= 2;
            panel.SetActive(false);
        }
    }

    public void buyI16U3()
    {
        if (coinsDisplay.Coins >= price)
        {
            coinsDisplay.addCoins(-price);
            coinsDisplay.pricesUpgrades[upgradeNum - 1] = price;
            damage.itemMultipliers[15] *= 2;
            panel.SetActive(false);
        }
    }

    public void buyI16U4()
    {
        if (coinsDisplay.Coins >= price)
        {
            coinsDisplay.addCoins(-price);
            coinsDisplay.pricesUpgrades[upgradeNum - 1] = price;
            damage.itemMultipliers[15] *= 2;
            panel.SetActive(false);
        }
    }

    public void buyI16U5()
    {
        if (coinsDisplay.Coins >= price)
        {
            coinsDisplay.addCoins(-price);
            coinsDisplay.pricesUpgrades[upgradeNum - 1] = price;
            damage.itemMultipliers[15] *= 2;
            panel.SetActive(false);
        }
    }

    public void buyI16U6()
    {
        if (coinsDisplay.Coins >= price)
        {
            coinsDisplay.addCoins(-price);
            coinsDisplay.pricesUpgrades[upgradeNum - 1] = price;
            damage.itemMultipliers[15] *= 2;
            panel.SetActive(false);
        }
    }


    public void buyI17U1()
    {
        if (coinsDisplay.Coins >= price)
        {
            coinsDisplay.addCoins(-price);
            coinsDisplay.pricesUpgrades[upgradeNum - 1] = price;
            damage.itemMultipliers[16] *= 2;
            panel.SetActive(false);
        }
    }

    public void buyI17U2()
    {
        if (coinsDisplay.Coins >= price)
        {
            coinsDisplay.addCoins(-price);
            coinsDisplay.pricesUpgrades[upgradeNum - 1] = price;
            damage.itemMultipliers[16] *= 2;
            panel.SetActive(false);
        }
    }

    public void buyI17U3()
    {
        if (coinsDisplay.Coins >= price)
        {
            coinsDisplay.addCoins(-price);
            coinsDisplay.pricesUpgrades[upgradeNum - 1] = price;
            damage.itemMultipliers[16] *= 2;
            panel.SetActive(false);
        }
    }

    public void buyI17U4()
    {
        if (coinsDisplay.Coins >= price)
        {
            coinsDisplay.addCoins(-price);
            coinsDisplay.pricesUpgrades[upgradeNum - 1] = price;
            damage.itemMultipliers[16] *= 2;
            panel.SetActive(false);
        }
    }

    public void buyI17U5()
    {
        if (coinsDisplay.Coins >= price)
        {
            coinsDisplay.addCoins(-price);
            coinsDisplay.pricesUpgrades[upgradeNum - 1] = price;
            damage.itemMultipliers[16] *= 2;
            panel.SetActive(false);
        }
    }

    public void buyI17U6()
    {
        if (coinsDisplay.Coins >= price)
        {
            coinsDisplay.addCoins(-price);
            coinsDisplay.pricesUpgrades[upgradeNum - 1] = price;
            damage.itemMultipliers[16] *= 2;
            panel.SetActive(false);
        }
    }

    public void buyI18U1()
    {
        if (coinsDisplay.Coins >= price)
        {
            coinsDisplay.addCoins(-price);
            coinsDisplay.pricesUpgrades[upgradeNum - 1] = price;
            damage.itemMultipliers[17] *= 2;
            panel.SetActive(false);
        }
    }

    public void buyI18U2()
    {
        if (coinsDisplay.Coins >= price)
        {
            coinsDisplay.addCoins(-price);
            coinsDisplay.pricesUpgrades[upgradeNum - 1] = price;
            damage.itemMultipliers[17] *= 2;
            panel.SetActive(false);
        }
    }

    public void buyI18U3()
    {
        if (coinsDisplay.Coins >= price)
        {
            coinsDisplay.addCoins(-price);
            coinsDisplay.pricesUpgrades[upgradeNum - 1] = price;
            damage.itemMultipliers[17] *= 2;
            panel.SetActive(false);
        }
    }

    public void buyI18U4()
    {
        if (coinsDisplay.Coins >= price)
        {
            coinsDisplay.addCoins(-price);
            coinsDisplay.pricesUpgrades[upgradeNum - 1] = price;
            damage.itemMultipliers[17] *= 2;
            panel.SetActive(false);
        }
    }

    public void buyI18U5()
    {
        if (coinsDisplay.Coins >= price)
        {
            coinsDisplay.addCoins(-price);
            coinsDisplay.pricesUpgrades[upgradeNum - 1] = price;
            damage.itemMultipliers[17] *= 2;
            panel.SetActive(false);
        }
    }

    public void buyI18U6()
    {
        if (coinsDisplay.Coins >= price)
        {
            coinsDisplay.addCoins(-price);
            coinsDisplay.pricesUpgrades[upgradeNum - 1] = price;
            damage.itemMultipliers[17] *= 2;
            panel.SetActive(false);
        }
    }

    public void buyI19U1()
    {
        if (coinsDisplay.Coins >= price)
        {
            coinsDisplay.addCoins(-price);
            coinsDisplay.pricesUpgrades[upgradeNum - 1] = price;
            damage.itemMultipliers[18] *= 2;
            panel.SetActive(false);
        }
    }

    public void buyI19U2()
    {
        if (coinsDisplay.Coins >= price)
        {
            coinsDisplay.addCoins(-price);
            coinsDisplay.pricesUpgrades[upgradeNum - 1] = price;
            damage.itemMultipliers[18] *= 2;
            panel.SetActive(false);
        }
    }

    public void buyI19U3()
    {
        if (coinsDisplay.Coins >= price)
        {
            coinsDisplay.addCoins(-price);
            coinsDisplay.pricesUpgrades[upgradeNum - 1] = price;
            damage.itemMultipliers[18] *= 2;
            panel.SetActive(false);
        }
    }

    public void buyI19U4()
    {
        if (coinsDisplay.Coins >= price)
        {
            coinsDisplay.addCoins(-price);
            coinsDisplay.pricesUpgrades[upgradeNum - 1] = price;
            damage.itemMultipliers[18] *= 2;
            panel.SetActive(false);
        }
    }

    public void buyI19U5()
    {
        if (coinsDisplay.Coins >= price)
        {
            coinsDisplay.addCoins(-price);
            coinsDisplay.pricesUpgrades[upgradeNum - 1] = price;
            damage.itemMultipliers[18] *= 2;
            panel.SetActive(false);
        }
    }

    public void buyI19U6()
    {
        if (coinsDisplay.Coins >= price)
        {
            coinsDisplay.addCoins(-price);
            coinsDisplay.pricesUpgrades[upgradeNum - 1] = price;
            damage.itemMultipliers[18] *= 2;
            panel.SetActive(false);
        }
    }

}
