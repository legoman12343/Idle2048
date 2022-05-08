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
    public TextMeshProUGUI ItemDisplayTXT;
    public Text priceText;
    public Text DPStext;
    public int ItemOwned;
    public float dpsValue;
    public Damage damage;
    private float DPSincrement;
    private float priceIncrement;
    public int itemNumber;
    private bool bought;
    public GameManager gm;

    void Start()
    {
        bought = false;
        ItemOwned = 0;
        priceIncrement = 1.05f;
        DPSincrement = 1.02f;
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
            dpsValue *= DPSincrement;
            string firstItemTXT = ItemOwned.ToString();
            //ItemDisplayTXT.text = firstItemTXT;
            /*
            if (dpsValue.ToString().Contains("."))
            {
                temp = (int)Math.Ceiling(dpsValue);
                dpsValue = (float)temp;
            } */
            
            price *= priceIncrement;
            if (price.ToString().Contains("."))
            {
                temp = (int)Math.Ceiling(price);
                price = (float)temp;
            } 
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
    }

    public void buyCrate()
    {
        if(bought == false && coinsDisplay.Coins >= price)
        {
            coinsDisplay.addCoins(-price);
            priceText.text = "Bought";
            bought = true;
            gm.crateChance = 0.05f;
        }        
    }

    public void mergeTileLevel()
    {
        if (coinsDisplay.Coins >= price)
        {
            coinsDisplay.addCoins(-price);
            price *= 100000;
            updatePrice();
            gm.mergeUpgradeChance += 0.1f;
        }
    }
}
