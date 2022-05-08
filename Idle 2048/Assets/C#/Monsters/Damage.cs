using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Damage : MonoBehaviour
{
    public TextMeshProUGUI dpsCounter;
    public List<float> itemDamage;
    public int multiplier;
    // Start is called before the first frame update
    void Start()
    {
        multiplier = 1;
        changeDPS();
    }

    // Update is called once per frame
    void changeDPS()
    {
        string t = FormatNumber(getDPS());
        dpsCounter.text = t;
    }

    public void changeMultiplier(int n)
    {
        multiplier += n;
        changeDPS();
        Debug.Log(multiplier);
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

    public void addDPS(float n, int index)
    {
        itemDamage[index] += n;
        changeDPS();
    }

    public void setDPS(float n, int index)
    {
        itemDamage[index] = n;
        changeDPS();
    }

    public float getDPS()
    {
        float total = 1f;
        foreach(float i in itemDamage)
            total += i;
        return total * multiplier;
    }
}
