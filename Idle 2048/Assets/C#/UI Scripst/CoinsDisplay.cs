using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CoinsDisplay : MonoBehaviour
{

    public TextMeshProUGUI CoinsDisplayTXT;
    public int Coins;

    // Start is called before the first frame update
    void Start()
    {
        Coins = 100_000_000;
    }

    // Update is called once per frame
    void Update()
    {
        string coinsTXT = FormatNumber(Coins);
        CoinsDisplayTXT.text = coinsTXT;
        Coins += 10;
    }

    string FormatNumber(long num)
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

        return num.ToString("#,0");
    }
}
