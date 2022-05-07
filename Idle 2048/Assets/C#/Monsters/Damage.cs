using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Damage : MonoBehaviour
{
    public TextMeshProUGUI dpsCounter;
    public List<float> itemDamage;
    // Start is called before the first frame update
    void Start()
    {
        chageDPS();
    }

    // Update is called once per frame
    void chageDPS()
    {
        string t = FormatNumber(getDPS());
        dpsCounter.text = t;
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

        return num.ToString("0.#");
    }

    public void addDPS(float n, int index)
    {
        itemDamage[index] += n;
        chageDPS();
    }

    public void setDPS(float n, int index)
    {
        itemDamage[index] = n;
        chageDPS();
    }

    public float getDPS()
    {
        float total = 1f;
        foreach(int i in itemDamage)
            total += i;
        return (float)total;
    }
}
