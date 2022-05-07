using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CoinsDisplay : MonoBehaviour
{

    public TextMeshProUGUI CoinsDisplayTXT;
    public float Coins;

    // Start is called before the first frame update
    void Start()
    {
        Coins = 100000;
        string coinsTXT = FormatNumber(Coins);
        CoinsDisplayTXT.text = coinsTXT;
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
    }

    public void addCoins(float n)
    {
        Coins += n;
        string coinsTXT = FormatNumber(Coins);
        CoinsDisplayTXT.text = coinsTXT;
    }
}
