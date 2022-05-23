using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Numerics;
using System;

public class Damage : MonoBehaviour
{
    public FormatNumber fn;
    public TextMeshProUGUI dpsCounter;
    public List<BigInteger> itemDamage = new List<BigInteger>();
    public List<float> itemMultipliers = new List<float>();
    public float multiplier;
    public float ASmultiplier;
    [SerializeField] public List<GameObject> gearUpgrades;
    // Start is called before the first frame update
    void Start()
    {
        ASmultiplier = 1f;
        multiplier = 1f;
        for (int i = 0; i < 19; i++)
        {
            itemDamage.Add(0);
        }
        for (int i = 0; i < itemDamage.Count; i++)
        {
            itemMultipliers.Add(1f);
        }
        changeDPS();
    }

    // Update is called once per frame

    void changeDPS()
    {
        string t = fn.formatNumberBigNumber(getDPS(), true);
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

    public void addDPS(BigInteger n, int index)
    {
        itemDamage[index] += n;
        changeDPS();
    }

    public void setDPS(BigInteger n, int index)
    {
        itemDamage[index] = n;
        changeDPS();
    }

    public BigInteger getDPS()
    {
        BigInteger total = 1;
        foreach(BigInteger i in itemDamage)
            total += i;

        for (int i = 0; i < itemDamage.Count; i++)
        {
            BigInteger m = new BigInteger(itemMultipliers[i]);
            m *= 100;
            total += (itemDamage[i] * m)/100;
        }
        BigInteger asm = new BigInteger(ASmultiplier);
        asm *= 100;
        BigInteger mu = new BigInteger(multiplier);
        mu *= 100;
        return (total * mu * asm)/10000;
    }
}
