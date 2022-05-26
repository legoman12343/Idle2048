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

    public GameObject GearPanel;
    public GameObject InfoPanel;
    private bool infoOpen;

    public GameObject UpgradeTitle;
    public GameObject GearTitle;
    public GameObject infuseTitle;
    public List<GameObject> infusePhase = new List<GameObject>();
    public List<GameObject> buyPhase = new List<GameObject>();

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
        infoOpen = false;
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

    public void clickInfo()
    {
        if (infoOpen)
        {
            infoOpen = false;
            GearPanel.SetActive(true);
            InfoPanel.SetActive(false);
        }
        else
        {
            infoOpen = true;
            GearPanel.SetActive(false);
            InfoPanel.SetActive(true);
        }
    }

    public void clickInfuse()
    {
        if(open)
        {
            open = false;
            UpgradeTitle.SetActive(true);
            GearTitle.SetActive(true);
            infuseTitle.SetActive(false);
            for (int x = 0; x < infusePhase.Count; x++) infusePhase[x].SetActive(false);
            for (int x = 0; x < buyPhase.Count; x++) buyPhase[x].SetActive(true);
        }
        else
        {
            open = true;
            UpgradeTitle.SetActive(false);
            GearTitle.SetActive(false);
            infuseTitle.SetActive(true);
            for (int x = 0; x < infusePhase.Count; x++) infusePhase[x].SetActive(true);
            for (int x = 0; x < buyPhase.Count; x++) buyPhase[x].SetActive(false);
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
