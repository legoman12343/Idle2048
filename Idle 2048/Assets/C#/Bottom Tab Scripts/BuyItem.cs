using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BuyItem : MonoBehaviour
{
    public float price;
    public CoinsDisplay coinsDisplay;
    public Text ItemDisplayTXT;
    public Text priceText;
    public Text DPStext;
    public int ItemOwned;
    public float dpsValue;
    public Damage damage;
    private float priceIncrement;
    public int itemNumber;
    private bool bought;
    public GameManager gm;
    public int upgradeNum;
    public bool upgrade;
    public GameObject panel;
    public float baseDamage;
    public float multiplier;
    public AdManager ads;
    public NotificationAnimation upgradeAnimation;
    public Ability1 ability1;
    public Ability2 ability2;
    public Ability3 ability3;
    float originalPrice;
    float discount = 1.0f;
    public FormatNumber fn;

    void Start()
    {
        originalPrice = price;
        multiplier = 1f;
        baseDamage = dpsValue;
        bought = false;
        ItemOwned = 0;
        if(!upgrade)
        ItemDisplayTXT.text = "X " + ItemOwned.ToString();
        priceIncrement = 1.05f;
        if (upgrade)
            updatePriceUpgrades();
        else
        updatePrice();

    }

    public void updateDiscount(float d)
    {
        discount += d;
        price = originalPrice * discount;
    }

    public void buyItem()
    {
        if (coinsDisplay.Coins >= price)
        {
            int temp;
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

            dpsValue = baseDamage * ItemOwned * multiplier;
            ItemDisplayTXT.text = "X " + ItemOwned.ToString();
            
            price *= priceIncrement;
            if (price.ToString().Contains("."))
            {
                temp = (int)Math.Ceiling(price);
                price = (float)temp;
            } 
            if(upgrade)
                updatePriceUpgrades();
            else
                updatePrice();
        }
    }

    public void updatePrice()
    {
        priceText.text = fn.formatNumber(price, false).ToString() + " Coins";
        DPStext.text = fn.formatNumber(dpsValue,false).ToString();
        coinsDisplay.prices[upgradeNum-1] = (int)price;
    }

    public void updatePriceUpgrades()
    {
        priceText.text = fn.formatNumber(price,false) + " Coins";
        coinsDisplay.pricesUpgrades[upgradeNum - 1] = (int)price;
    }

    public void buyCrate()
    {
        if(bought == false && coinsDisplay.Coins >= price)
        {
            coinsDisplay.addCoins(-price);
            priceText.text = "Bought";
            bought = true;
            gm.crateChance = 0.05f;
            int index = coinsDisplay.pricesUpgrades.FindIndex(x => x == price);
            coinsDisplay.pricesUpgrades.RemoveAt(index);
            coinsDisplay.coloursUpgrades.RemoveAt(index);
            StartCoroutine(ads.showCrateAd());
            panel.SetActive(false);
        }        
    }

    

    public void mergeTileLevel()
    {
        if (coinsDisplay.Coins >= price)
        {
            coinsDisplay.addCoins(-price);
            int index = coinsDisplay.pricesUpgrades.FindIndex(x => x == price);
            coinsDisplay.pricesUpgrades.RemoveAt(index);
            coinsDisplay.coloursUpgrades.RemoveAt(index);
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
            int index = coinsDisplay.pricesUpgrades.FindIndex(x => x == price);
            coinsDisplay.pricesUpgrades.RemoveAt(index);
            coinsDisplay.coloursUpgrades.RemoveAt(index);
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
            int index = coinsDisplay.pricesUpgrades.FindIndex(x => x == price);
            coinsDisplay.pricesUpgrades.RemoveAt(index);
            coinsDisplay.coloursUpgrades.RemoveAt(index);
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
            int index = coinsDisplay.pricesUpgrades.FindIndex(x => x == price);
            coinsDisplay.pricesUpgrades.RemoveAt(index);
            coinsDisplay.coloursUpgrades.RemoveAt(index);
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
            int index = coinsDisplay.pricesUpgrades.FindIndex(x => x == price);
            coinsDisplay.pricesUpgrades.RemoveAt(index);
            coinsDisplay.coloursUpgrades.RemoveAt(index);
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
            int index = coinsDisplay.pricesUpgrades.FindIndex(x => x == price);
            coinsDisplay.pricesUpgrades.RemoveAt(index);
            coinsDisplay.coloursUpgrades.RemoveAt(index);
            ability1.buyAbility1();
            panel.SetActive(false);
        }
    }

    public void buyAbility2()
    {
        if (coinsDisplay.Coins >= price)
        {
            coinsDisplay.addCoins(-price);
            int index = coinsDisplay.pricesUpgrades.FindIndex(x => x == price);
            coinsDisplay.pricesUpgrades.RemoveAt(index);
            coinsDisplay.coloursUpgrades.RemoveAt(index);
            ability2.buyAbility2();
            panel.SetActive(false);
        }
    }

    public void buyAbility3()
    {
        if (coinsDisplay.Coins >= price)
        {
            coinsDisplay.addCoins(-price);
            int index = coinsDisplay.pricesUpgrades.FindIndex(x => x == price);
            coinsDisplay.pricesUpgrades.RemoveAt(index);
            coinsDisplay.coloursUpgrades.RemoveAt(index);
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
            int index = coinsDisplay.pricesUpgrades.FindIndex(x => x == price);
            coinsDisplay.pricesUpgrades.RemoveAt(index);
            coinsDisplay.coloursUpgrades.RemoveAt(index);
            damage.itemMultipliers[0] *= 2;
            panel.SetActive(false);
        }
    }

    public void buyI1U2()
    {
        if (coinsDisplay.Coins >= price)
        {
            coinsDisplay.addCoins(-price);
            int index = coinsDisplay.pricesUpgrades.FindIndex(x => x == price);
            coinsDisplay.pricesUpgrades.RemoveAt(index);
            coinsDisplay.coloursUpgrades.RemoveAt(index);
            damage.itemMultipliers[0] *= 2;
            panel.SetActive(false);
        }
    }

    public void buyI1U3()
    {
        if (coinsDisplay.Coins >= price)
        {
            coinsDisplay.addCoins(-price);
            int index = coinsDisplay.pricesUpgrades.FindIndex(x => x == price);
            coinsDisplay.pricesUpgrades.RemoveAt(index);
            coinsDisplay.coloursUpgrades.RemoveAt(index);
            damage.itemMultipliers[0] *= 2;
            panel.SetActive(false);
        }
    }

    public void buyI1U4()
    {
        if (coinsDisplay.Coins >= price)
        {
            coinsDisplay.addCoins(-price);
            int index = coinsDisplay.pricesUpgrades.FindIndex(x => x == price);
            coinsDisplay.pricesUpgrades.RemoveAt(index);
            coinsDisplay.coloursUpgrades.RemoveAt(index);
            damage.itemMultipliers[0] *= 2;
            panel.SetActive(false);
        }
    }

    public void buyI2U1()
    {
        if (coinsDisplay.Coins >= price)
        {
            coinsDisplay.addCoins(-price);
            int index = coinsDisplay.pricesUpgrades.FindIndex(x => x == price);
            coinsDisplay.pricesUpgrades.RemoveAt(index);
            coinsDisplay.coloursUpgrades.RemoveAt(index);
            damage.itemMultipliers[1] *= 2;
            panel.SetActive(false);
        }
    }

    public void buyI2U2()
    {
        if (coinsDisplay.Coins >= price)
        {
            coinsDisplay.addCoins(-price);
            int index = coinsDisplay.pricesUpgrades.FindIndex(x => x == price);
            coinsDisplay.pricesUpgrades.RemoveAt(index);
            coinsDisplay.coloursUpgrades.RemoveAt(index);
            damage.itemMultipliers[1] *= 2;
            panel.SetActive(false);
        }
    }

    public void buyI2U3()
    {
        if (coinsDisplay.Coins >= price)
        {
            coinsDisplay.addCoins(-price);
            int index = coinsDisplay.pricesUpgrades.FindIndex(x => x == price);
            coinsDisplay.pricesUpgrades.RemoveAt(index);
            coinsDisplay.coloursUpgrades.RemoveAt(index);
            damage.itemMultipliers[1] *= 2;
            panel.SetActive(false);
        }
    }

    public void buyI2U4()
    {
        if (coinsDisplay.Coins >= price)
        {
            coinsDisplay.addCoins(-price);
            int index = coinsDisplay.pricesUpgrades.FindIndex(x => x == price);
            coinsDisplay.pricesUpgrades.RemoveAt(index);
            coinsDisplay.coloursUpgrades.RemoveAt(index);
            damage.itemMultipliers[1] *= 2;
            panel.SetActive(false);
        }
    }

    public void buyI3U1()
    {
        if (coinsDisplay.Coins >= price)
        {
            coinsDisplay.addCoins(-price);
            int index = coinsDisplay.pricesUpgrades.FindIndex(x => x == price);
            coinsDisplay.pricesUpgrades.RemoveAt(index);
            coinsDisplay.coloursUpgrades.RemoveAt(index);
            damage.itemMultipliers[2] *= 2;
            panel.SetActive(false);
        }
    }

    public void buyI3U2()
    {
        if (coinsDisplay.Coins >= price)
        {
            coinsDisplay.addCoins(-price);
            int index = coinsDisplay.pricesUpgrades.FindIndex(x => x == price);
            coinsDisplay.pricesUpgrades.RemoveAt(index);
            coinsDisplay.coloursUpgrades.RemoveAt(index);
            damage.itemMultipliers[2] *= 2;
            panel.SetActive(false);
        }
    }

    public void buyI3U3()
    {
        if (coinsDisplay.Coins >= price)
        {
            coinsDisplay.addCoins(-price);
            int index = coinsDisplay.pricesUpgrades.FindIndex(x => x == price);
            coinsDisplay.pricesUpgrades.RemoveAt(index);
            coinsDisplay.coloursUpgrades.RemoveAt(index);
            damage.itemMultipliers[2] *= 2;
            panel.SetActive(false);
        }
    }

    public void buyI3U4()
    {
        if (coinsDisplay.Coins >= price)
        {
            coinsDisplay.addCoins(-price);
            int index = coinsDisplay.pricesUpgrades.FindIndex(x => x == price);
            coinsDisplay.pricesUpgrades.RemoveAt(index);
            coinsDisplay.coloursUpgrades.RemoveAt(index);
            damage.itemMultipliers[2] *= 2;
            panel.SetActive(false);
        }
    }

    public void buyI4U1()
    {
        if (coinsDisplay.Coins >= price)
        {
            coinsDisplay.addCoins(-price);
            int index = coinsDisplay.pricesUpgrades.FindIndex(x => x == price);
            coinsDisplay.pricesUpgrades.RemoveAt(index);
            coinsDisplay.coloursUpgrades.RemoveAt(index);
            damage.itemMultipliers[3] *= 2;
            panel.SetActive(false);
        }
    }

    public void buyI4U2()
    {
        if (coinsDisplay.Coins >= price)
        {
            coinsDisplay.addCoins(-price);
            int index = coinsDisplay.pricesUpgrades.FindIndex(x => x == price);
            coinsDisplay.pricesUpgrades.RemoveAt(index);
            coinsDisplay.coloursUpgrades.RemoveAt(index);
            damage.itemMultipliers[3] *= 2;
            panel.SetActive(false);
        }
    }

    public void buyI4U3()
    {
        if (coinsDisplay.Coins >= price)
        {
            coinsDisplay.addCoins(-price);
            int index = coinsDisplay.pricesUpgrades.FindIndex(x => x == price);
            coinsDisplay.pricesUpgrades.RemoveAt(index);
            coinsDisplay.coloursUpgrades.RemoveAt(index);
            damage.itemMultipliers[3] *= 2;
            panel.SetActive(false);
        }
    }

    public void buyI4U4()
    {
        if (coinsDisplay.Coins >= price)
        {
            coinsDisplay.addCoins(-price);
            int index = coinsDisplay.pricesUpgrades.FindIndex(x => x == price);
            coinsDisplay.pricesUpgrades.RemoveAt(index);
            coinsDisplay.coloursUpgrades.RemoveAt(index);
            damage.itemMultipliers[3] *= 2;
            panel.SetActive(false);
        }
    }

    public void buyI5U1()
    {
        if (coinsDisplay.Coins >= price)
        {
            coinsDisplay.addCoins(-price);
            int index = coinsDisplay.pricesUpgrades.FindIndex(x => x == price);
            coinsDisplay.pricesUpgrades.RemoveAt(index);
            coinsDisplay.coloursUpgrades.RemoveAt(index);
            damage.itemMultipliers[4] *= 2;
            panel.SetActive(false);
        }
    }

    public void buyI5U2()
    {
        if (coinsDisplay.Coins >= price)
        {
            coinsDisplay.addCoins(-price);
            int index = coinsDisplay.pricesUpgrades.FindIndex(x => x == price);
            coinsDisplay.pricesUpgrades.RemoveAt(index);
            coinsDisplay.coloursUpgrades.RemoveAt(index);
            damage.itemMultipliers[4] *= 2;
            panel.SetActive(false);
        }
    }

    public void buyI5U3()
    {
        if (coinsDisplay.Coins >= price)
        {
            coinsDisplay.addCoins(-price);
            int index = coinsDisplay.pricesUpgrades.FindIndex(x => x == price);
            coinsDisplay.pricesUpgrades.RemoveAt(index);
            coinsDisplay.coloursUpgrades.RemoveAt(index);
            damage.itemMultipliers[4] *= 2;
            panel.SetActive(false);
        }
    }

    public void buyI5U4()
    {
        if (coinsDisplay.Coins >= price)
        {
            coinsDisplay.addCoins(-price);
            int index = coinsDisplay.pricesUpgrades.FindIndex(x => x == price);
            coinsDisplay.pricesUpgrades.RemoveAt(index);
            coinsDisplay.coloursUpgrades.RemoveAt(index);
            damage.itemMultipliers[4] *= 2;
            panel.SetActive(false);
        }
    }

    public void buyI6U1()
    {
        if (coinsDisplay.Coins >= price)
        {
            coinsDisplay.addCoins(-price);
            int index = coinsDisplay.pricesUpgrades.FindIndex(x => x == price);
            coinsDisplay.pricesUpgrades.RemoveAt(index);
            coinsDisplay.coloursUpgrades.RemoveAt(index);
            damage.itemMultipliers[5] *= 2;
            panel.SetActive(false);
        }
    }

    public void buyI6U2()
    {
        if (coinsDisplay.Coins >= price)
        {
            coinsDisplay.addCoins(-price);
            int index = coinsDisplay.pricesUpgrades.FindIndex(x => x == price);
            coinsDisplay.pricesUpgrades.RemoveAt(index);
            coinsDisplay.coloursUpgrades.RemoveAt(index);
            damage.itemMultipliers[5] *= 2;
            panel.SetActive(false);
        }
    }

    public void buyI6U3()
    {
        if (coinsDisplay.Coins >= price)
        {
            coinsDisplay.addCoins(-price);
            int index = coinsDisplay.pricesUpgrades.FindIndex(x => x == price);
            coinsDisplay.pricesUpgrades.RemoveAt(index);
            coinsDisplay.coloursUpgrades.RemoveAt(index);
            damage.itemMultipliers[5] *= 2;
            panel.SetActive(false);
        }
    }

    public void buyI6U4()
    {
        if (coinsDisplay.Coins >= price)
        {
            coinsDisplay.addCoins(-price);
            int index = coinsDisplay.pricesUpgrades.FindIndex(x => x == price);
            coinsDisplay.pricesUpgrades.RemoveAt(index);
            coinsDisplay.coloursUpgrades.RemoveAt(index);
            damage.itemMultipliers[5] *= 2;
            panel.SetActive(false);
        }
    }

    public void buyI7U1()
    {
        if (coinsDisplay.Coins >= price)
        {
            coinsDisplay.addCoins(-price);
            int index = coinsDisplay.pricesUpgrades.FindIndex(x => x == price);
            coinsDisplay.pricesUpgrades.RemoveAt(index);
            coinsDisplay.coloursUpgrades.RemoveAt(index);
            damage.itemMultipliers[6] *= 2;
            panel.SetActive(false);
        }
    }

    public void buyI7U2()
    {
        if (coinsDisplay.Coins >= price)
        {
            coinsDisplay.addCoins(-price);
            int index = coinsDisplay.pricesUpgrades.FindIndex(x => x == price);
            coinsDisplay.pricesUpgrades.RemoveAt(index);
            coinsDisplay.coloursUpgrades.RemoveAt(index);
            damage.itemMultipliers[6] *= 2;
            panel.SetActive(false);
        }
    }

    public void buyI7U3()
    {
        if (coinsDisplay.Coins >= price)
        {
            coinsDisplay.addCoins(-price);
            int index = coinsDisplay.pricesUpgrades.FindIndex(x => x == price);
            coinsDisplay.pricesUpgrades.RemoveAt(index);
            coinsDisplay.coloursUpgrades.RemoveAt(index);
            damage.itemMultipliers[6] *= 2;
            panel.SetActive(false);
        }
    }

    public void buyI7U4()
    {
        if (coinsDisplay.Coins >= price)
        {
            coinsDisplay.addCoins(-price);
            int index = coinsDisplay.pricesUpgrades.FindIndex(x => x == price);
            coinsDisplay.pricesUpgrades.RemoveAt(index);
            coinsDisplay.coloursUpgrades.RemoveAt(index);
            damage.itemMultipliers[6] *= 2;
            panel.SetActive(false);
        }
    }

    public void buyI8U1()
    {
        if (coinsDisplay.Coins >= price)
        {
            coinsDisplay.addCoins(-price);
            int index = coinsDisplay.pricesUpgrades.FindIndex(x => x == price);
            coinsDisplay.pricesUpgrades.RemoveAt(index);
            coinsDisplay.coloursUpgrades.RemoveAt(index);
            damage.itemMultipliers[7] *= 2;
            panel.SetActive(false);
        }
    }

    public void buyI8U2()
    {
        if (coinsDisplay.Coins >= price)
        {
            coinsDisplay.addCoins(-price);
            int index = coinsDisplay.pricesUpgrades.FindIndex(x => x == price);
            coinsDisplay.pricesUpgrades.RemoveAt(index);
            coinsDisplay.coloursUpgrades.RemoveAt(index);
            damage.itemMultipliers[7] *= 2;
            panel.SetActive(false);
        }
    }

    public void buyI8U3()
    {
        if (coinsDisplay.Coins >= price)
        {
            coinsDisplay.addCoins(-price);
            int index = coinsDisplay.pricesUpgrades.FindIndex(x => x == price);
            coinsDisplay.pricesUpgrades.RemoveAt(index);
            coinsDisplay.coloursUpgrades.RemoveAt(index);
            damage.itemMultipliers[7] *= 2;
            panel.SetActive(false);
        }
    }

    public void buyI8U4()
    {
        if (coinsDisplay.Coins >= price)
        {
            coinsDisplay.addCoins(-price);
            int index = coinsDisplay.pricesUpgrades.FindIndex(x => x == price);
            coinsDisplay.pricesUpgrades.RemoveAt(index);
            coinsDisplay.coloursUpgrades.RemoveAt(index);
            damage.itemMultipliers[7] *= 2;
            panel.SetActive(false);
        }
    }

    public void buyI9U1()
    {
        if (coinsDisplay.Coins >= price)
        {
            coinsDisplay.addCoins(-price);
            int index = coinsDisplay.pricesUpgrades.FindIndex(x => x == price);
            coinsDisplay.pricesUpgrades.RemoveAt(index);
            coinsDisplay.coloursUpgrades.RemoveAt(index);
            damage.itemMultipliers[8] *= 2;
            panel.SetActive(false);
        }
    }

    public void buyI9U2()
    {
        if (coinsDisplay.Coins >= price)
        {
            coinsDisplay.addCoins(-price);
            int index = coinsDisplay.pricesUpgrades.FindIndex(x => x == price);
            coinsDisplay.pricesUpgrades.RemoveAt(index);
            coinsDisplay.coloursUpgrades.RemoveAt(index);
            damage.itemMultipliers[8] *= 2;
            panel.SetActive(false);
        }
    }

    public void buyI9U3()
    {
        if (coinsDisplay.Coins >= price)
        {
            coinsDisplay.addCoins(-price);
            int index = coinsDisplay.pricesUpgrades.FindIndex(x => x == price);
            coinsDisplay.pricesUpgrades.RemoveAt(index);
            coinsDisplay.coloursUpgrades.RemoveAt(index);
            damage.itemMultipliers[8] *= 2;
            panel.SetActive(false);
        }
    }

    public void buyI9U4()
    {
        if (coinsDisplay.Coins >= price)
        {
            coinsDisplay.addCoins(-price);
            int index = coinsDisplay.pricesUpgrades.FindIndex(x => x == price);
            coinsDisplay.pricesUpgrades.RemoveAt(index);
            coinsDisplay.coloursUpgrades.RemoveAt(index);
            damage.itemMultipliers[8] *= 2;
            panel.SetActive(false);
        }
    }

    public void buyI10U1()
    {
        if (coinsDisplay.Coins >= price)
        {
            coinsDisplay.addCoins(-price);
            int index = coinsDisplay.pricesUpgrades.FindIndex(x => x == price);
            coinsDisplay.pricesUpgrades.RemoveAt(index);
            coinsDisplay.coloursUpgrades.RemoveAt(index);
            damage.itemMultipliers[9] *= 2;
            panel.SetActive(false);
        }
    }

    public void buyI10U2()
    {
        if (coinsDisplay.Coins >= price)
        {
            coinsDisplay.addCoins(-price);
            int index = coinsDisplay.pricesUpgrades.FindIndex(x => x == price);
            coinsDisplay.pricesUpgrades.RemoveAt(index);
            coinsDisplay.coloursUpgrades.RemoveAt(index);
            damage.itemMultipliers[9] *= 2;
            panel.SetActive(false);
        }
    }

    public void buyI10U3()
    {
        if (coinsDisplay.Coins >= price)
        {
            coinsDisplay.addCoins(-price);
            int index = coinsDisplay.pricesUpgrades.FindIndex(x => x == price);
            coinsDisplay.pricesUpgrades.RemoveAt(index);
            coinsDisplay.coloursUpgrades.RemoveAt(index);
            damage.itemMultipliers[9] *= 2;
            panel.SetActive(false);
        }
    }

    public void buyI10U4()
    {
        if (coinsDisplay.Coins >= price)
        {
            coinsDisplay.addCoins(-price);
            int index = coinsDisplay.pricesUpgrades.FindIndex(x => x == price);
            coinsDisplay.pricesUpgrades.RemoveAt(index);
            coinsDisplay.coloursUpgrades.RemoveAt(index);
            damage.itemMultipliers[9] *= 2;
            panel.SetActive(false);
        }
    }

    public void buyI11U1()
    {
        if (coinsDisplay.Coins >= price)
        {
            coinsDisplay.addCoins(-price);
            int index = coinsDisplay.pricesUpgrades.FindIndex(x => x == price);
            coinsDisplay.pricesUpgrades.RemoveAt(index);
            coinsDisplay.coloursUpgrades.RemoveAt(index);
            damage.itemMultipliers[10] *= 2;
            panel.SetActive(false);
        }
    }

    public void buyI11U2()
    {
        if (coinsDisplay.Coins >= price)
        {
            coinsDisplay.addCoins(-price);
            int index = coinsDisplay.pricesUpgrades.FindIndex(x => x == price);
            coinsDisplay.pricesUpgrades.RemoveAt(index);
            coinsDisplay.coloursUpgrades.RemoveAt(index);
            damage.itemMultipliers[10] *= 2;
            panel.SetActive(false);
        }
    }

    public void buyI11U3()
    {
        if (coinsDisplay.Coins >= price)
        {
            coinsDisplay.addCoins(-price);
            int index = coinsDisplay.pricesUpgrades.FindIndex(x => x == price);
            coinsDisplay.pricesUpgrades.RemoveAt(index);
            coinsDisplay.coloursUpgrades.RemoveAt(index);
            damage.itemMultipliers[10] *= 2;
            panel.SetActive(false);
        }
    }

    public void buyI11U4()
    {
        if (coinsDisplay.Coins >= price)
        {
            coinsDisplay.addCoins(-price);
            int index = coinsDisplay.pricesUpgrades.FindIndex(x => x == price);
            coinsDisplay.pricesUpgrades.RemoveAt(index);
            coinsDisplay.coloursUpgrades.RemoveAt(index);
            damage.itemMultipliers[10] *= 2;
            panel.SetActive(false);
        }
    }

    public void buyI12U1()
    {
        if (coinsDisplay.Coins >= price)
        {
            coinsDisplay.addCoins(-price);
            int index = coinsDisplay.pricesUpgrades.FindIndex(x => x == price);
            coinsDisplay.pricesUpgrades.RemoveAt(index);
            coinsDisplay.coloursUpgrades.RemoveAt(index);
            damage.itemMultipliers[11] *= 2;
            panel.SetActive(false);
        }
    }

    public void buyI12U2()
    {
        if (coinsDisplay.Coins >= price)
        {
            coinsDisplay.addCoins(-price);
            int index = coinsDisplay.pricesUpgrades.FindIndex(x => x == price);
            coinsDisplay.pricesUpgrades.RemoveAt(index);
            coinsDisplay.coloursUpgrades.RemoveAt(index);
            damage.itemMultipliers[11] *= 2;
            panel.SetActive(false);
        }
    }

    public void buyI12U3()
    {
        if (coinsDisplay.Coins >= price)
        {
            coinsDisplay.addCoins(-price);
            int index = coinsDisplay.pricesUpgrades.FindIndex(x => x == price);
            coinsDisplay.pricesUpgrades.RemoveAt(index);
            coinsDisplay.coloursUpgrades.RemoveAt(index);
            damage.itemMultipliers[11] *= 2;
            panel.SetActive(false);
        }
    }

    public void buyI12U4()
    {
        if (coinsDisplay.Coins >= price)
        {
            coinsDisplay.addCoins(-price);
            int index = coinsDisplay.pricesUpgrades.FindIndex(x => x == price);
            coinsDisplay.pricesUpgrades.RemoveAt(index);
            coinsDisplay.coloursUpgrades.RemoveAt(index);
            damage.itemMultipliers[11] *= 2;
            panel.SetActive(false);
        }
    }




}
