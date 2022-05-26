using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class Infuse : MonoBehaviour
{

    public int infuseCoins;
    public int infuseBits;

    public Text textInfuse;
    public Text textBits;
    public GameObject mainWindow;
    public GameObject infuseWindow;

    public Damage damage;

    private bool open;

    public FormatNumber fn;
    public int bitUpperBound;
    public int bitLowerBound;

    void Start()
    {
        bitUpperBound = 3;
        bitLowerBound = 1;
        infuseBits = 0;
        infuseCoins = 0;
        open = false;
    }

    public void craftInfuseCoin()
    {
        if (infuseBits > 9)
        {
            infuseCoins ++;
            textInfuse.text = fn.formatNumber(infuseCoins);
            textBits.text = fn.formatNumber(infuseBits);
        }
    }

    public void clickInfuse()
    {
        if(open)
        {
            mainWindow.SetActive(true);
            infuseWindow.SetActive(false);
        }
        else
        {
            mainWindow.SetActive(false);
            infuseWindow.SetActive(true);
        }
    }

    public void buyInfuse(int index)
    {
        if (infuseCoins > 0)
        {
            damage.itemInfuse[index] += 1;
            infuseCoins--;
            textInfuse.text = fn.formatNumber(infuseCoins);
        }
    }

    public void sellInfuse(int index)
    {
        damage.itemInfuse[index] -= 1;
        infuseBits += Random.Range(bitLowerBound, bitUpperBound + 1);
        textInfuse.text = fn.formatNumber(infuseCoins);
    }

}
