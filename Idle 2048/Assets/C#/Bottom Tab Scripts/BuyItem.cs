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

    void Start()
    {
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

    public void buyItem()
    {
        if (coinsDisplay.Coins >= price)
        {
            int temp;
            damage.addDPS(dpsValue, itemNumber);
            coinsDisplay.addCoins(-price);
            ItemOwned++;
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
    string FormatNumber(float num)
    {
        if (num >= 100000000)
        {
            return (num / 1000000D).ToString("0.#M");
        }
        if (num >= 1000000)
        {
            return (num / 1000000D).ToString("0.##M");
        }
        if (num >= 100000)
        {
            return (num / 1000D).ToString("0.#k");
        }
        if (num >= 10000)
        {
            return (num / 1000D).ToString("0.##k");
        }
        if (num >= 1000)
        {
            return num.ToString("#,0");
        }
        return num.ToString("0.##");
    }

    public void updatePrice()
    {
        priceText.text = FormatNumber(price) + " Coins";
        DPStext.text = FormatNumber(dpsValue);
        coinsDisplay.prices[upgradeNum-1] = (int)price;
    }

    public void updatePriceUpgrades()
    {
        priceText.text = FormatNumber(price) + " Coins";
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


}
