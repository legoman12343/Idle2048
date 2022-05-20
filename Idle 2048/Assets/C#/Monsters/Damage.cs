using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Damage : MonoBehaviour
{
    public FormatNumber fn;
    public TextMeshProUGUI dpsCounter;
    public List<float> itemDamage;
    public List<float> itemMultipliers;
    public float multiplier;
    public float ASmultiplier;
    [SerializeField] public List<GameObject> gearUpgrades;
    // Start is called before the first frame update
    void Start()
    {
        ASmultiplier = 1f;
        multiplier = 1f;
        for (int i = 0; i < itemDamage.Count; i++)
        {
            itemMultipliers.Add(1f);
        }
        changeDPS();
    }

    // Update is called once per frame
    void changeDPS()
    {
        string t = fn.formatNumber(getDPS(),true);
        dpsCounter.text = t;
    }

    
    public void changeItemMultiplier(int i, float n)
    {
        itemMultipliers[i] += n;
        changeDPS();
    }

    public void changeASMulitplier(float n)
    {
        ASmultiplier += n;
        changeDPS();
    }

    public void changeMultiplier(float n)
    {
        multiplier += n;
        changeDPS();
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

        for (int i = 0; i < itemDamage.Count; i++)
        {
            total += itemDamage[i] * itemMultipliers[0];
        }
        return total * multiplier * ASmultiplier;
    }
}
