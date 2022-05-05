using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Ascension : MonoBehaviour
{

    public int ascensionCoinsGive;
    public int ascensionCoinsHave;
    public TextMeshProUGUI ascensionCoinsGiveTXT;
    public TextMeshProUGUI ascensionCoinsHaveTXT;
    public TextMeshProUGUI timesAscendedTXT;
    int timesAscended;

    public TextMeshProUGUI firstBuyLineAmountOwned;
    public TextMeshProUGUI secondBuyLineAmountOwned;
    public TextMeshProUGUI thirdBuyLineAmountOwned;
    public TextMeshProUGUI fourthBuyLineAmountOwned;
    public TextMeshProUGUI fifthBuyLineAmountOwned;
    public TextMeshProUGUI sixthBuyLineAmountOwned;

    void start()
    {
        ascensionCoinsGive = 0;
        ascensionCoinsHave = 0;
        timesAscended = 0;
    }

    void FixedUpdate()
    {
        //keeps how many ascension coins you can get from ascending updated with amount
        string ACToGiveTXT = ascensionCoinsGive.ToString();
        ascensionCoinsGiveTXT.text = ACToGiveTXT;
    }

    public void buyAscension()
    {
        if (ascensionCoinsGive != 0)
        {
            //adds to how many times ascended
            timesAscended++;
            string TCTXT = timesAscended.ToString();
            timesAscendedTXT.text = TCTXT;
            //resets coins
            gameObject.GetComponent<CoinsDisplay>().Coins = 0;
            //adds ascension coins to total and displays them / resets amount adding on
            ascensionCoinsHave += ascensionCoinsGive;
            string ACTXT = ascensionCoinsHave.ToString();
            ascensionCoinsHaveTXT.text = ACTXT;
            ascensionCoinsGive = 0;

            //Resets all bought items in the upgrades tab to 0
            firstBuyLineAmountOwned.text = "0";
            secondBuyLineAmountOwned.text = "0";
            thirdBuyLineAmountOwned.text = "0";
            fourthBuyLineAmountOwned.text = "0";
            fifthBuyLineAmountOwned.text = "0";
            sixthBuyLineAmountOwned.text = "0";
        }
    }
}
