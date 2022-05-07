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
    public Ascension ascension;
    public TextMeshProUGUI ItemDisplayTXT;
    public Text priceText;
    public Text DPStext;
    public int ItemOwned;
    public int giveAscensionCoins;
    public float dpsValue;
    public Damage damage;
    private float increment;
    public int itemNumber;

    void Start()
    {
        ItemOwned = 0;
        increment = 1.05f;
        updatePrice();
    }

    public void buyItem()
    {
        if (coinsDisplay.Coins >= price)
        {
            int temp;
            damage.setDPS((dpsValue + ItemOwned) * increment, itemNumber);
            coinsDisplay.addCoins(-price);
            ItemOwned++;
            ascension.ascensionCoinsGive += giveAscensionCoins;
            string firstItemTXT = ItemOwned.ToString();
            ItemDisplayTXT.text = firstItemTXT;
            if (dpsValue.ToString().Contains("."))
            {
                temp = (int)Math.Ceiling(dpsValue);
                dpsValue = (float)temp;
            }
            
            price *= increment;
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
        return num.ToString("0.#");
    }

    public void updatePrice()
    {
        priceText.text = FormatNumber(price) + " Coins";
        DPStext.text = FormatNumber(dpsValue);
    }
}
