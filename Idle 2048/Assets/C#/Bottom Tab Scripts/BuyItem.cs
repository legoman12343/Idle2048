using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BuyItem : MonoBehaviour
{
    public int price;
    public CoinsDisplay coinsDisplay;
    public Ascension ascension;
    public TextMeshProUGUI ItemDisplayTXT;
    public int ItemOwned;
    public int giveAscensionCoins;

    void start()
    {
        ItemOwned = 0;
    }

    public void buyItem()
    {
        if (coinsDisplay.Coins >= price)
        {
            coinsDisplay.Coins -= price;
            ItemOwned++;
            ascension.ascensionCoinsGive += giveAscensionCoins;
            string firstItemTXT = ItemOwned.ToString();
            ItemDisplayTXT.text = firstItemTXT;
        }
    }
}
