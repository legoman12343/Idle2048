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
    private long dpsValue;
    public Damage damage;
    private long increment;

    void Start()
    {
        ItemOwned = 0;
        increment = (long)1.1;
        dpsValue = 1;
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
            Debug.Log(dpsValue);
            damage.addDPS(dpsValue);

            dpsValue = dpsValue * increment;
        }
    }
}
