using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CoinsDisplay : MonoBehaviour
{

    public TextMeshProUGUI CoinsDisplayTXT;
    public float Coins;
    public List<int> prices;
    public List<Image> colours;
    public List<int> pricesUpgrades;
    public List<Image> coloursUpgrades;
    public Color red;
    public Color green;

    // Start is called before the first frame update
    void Start()
    {
        Coins = 0;
        string coinsTXT = FormatNumber(Coins);
        CoinsDisplayTXT.text = coinsTXT;
        updateButtons();
    }

    // Update is called once per frame

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

    public void addCoins(int n)
    {
        Coins += n;
        string coinsTXT = FormatNumber(Coins);
        CoinsDisplayTXT.text = coinsTXT;
        updateButtons();
    }

    public void addCoins(float n)
    {
        Coins += n;
        string coinsTXT = FormatNumber(Coins);
        CoinsDisplayTXT.text = coinsTXT;
        updateButtons();
    }

    public void updateButtons()
    {
        for (int i = 0; i < prices.Count; i++)
        {
            if(Coins >= prices[i])
                colours[i].color = green;
            else
                colours[i].color = red;
        }

        for (int i = 0; i < pricesUpgrades.Count; i++)
        {
            if (Coins >= pricesUpgrades[i])
                coloursUpgrades[i].color = green;
            else
                coloursUpgrades[i].color = red;
        }
    }

}

