using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Damage : MonoBehaviour
{
    public TextMeshProUGUI dpsCounter;
    public long dps;
    // Start is called before the first frame update
    void Start()
    {
        dps = 10000000;
        chageDPS();
    }

    // Update is called once per frame
    void chageDPS()
    {
        string t = FormatNumber(dps);
        dpsCounter.text = t;
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

    public void addDPS(long n)
    {
        Debug.Log(n);
        dps += n;
        chageDPS();
    }
}
