using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;
using DG.Tweening;
using QUEST;

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
    public GameObject buyButton;
    public GameObject sellButton;
    public Transform craftOrbObj;
    public List<Transform> infuseBitPosition = new List<Transform>();
    public List<GameObject> infusePhase = new List<GameObject>();
    public List<GameObject> buyPhase = new List<GameObject>();
    public List<GameObject> infuseBitsImg = new List<GameObject>();
    public List<Text> amountOwned = new List<Text>();
    public List<Text> bonusAmount = new List<Text>();
    public List<Text> gearNames = new List<Text>();

    private Color32 Gold = new Color32(225, 155, 0, 255);
    private Color32 White = new Color32(225, 225, 225, 255);
    private Color32 Grey = new Color32(149, 149, 149, 255);
    private Color32 Red = new Color32(219, 66, 66, 255);
    private Color32 Green = new Color32(83, 190, 99, 255);

    public Damage damage;

    private bool open;
    private bool sell;

    public FormatNumber fn;
    public int bitUpperBound;
    public int bitLowerBound;

    public QuestManager qm;

    void Start()
    {
        sell = false;
        bitUpperBound = 3;
        bitLowerBound = 1;
        infuseBits = 100;
        infuseCoins = 100;
        open = false;
        infoOpen = false;
        textInfuse.text = fn.formatNumber(infuseCoins);
        textBits.text = fn.formatNumber(infuseBits);
    }

    public void craftInfuseCoin()
    {
        if (infuseBits > 9)
        {
            qm.update(QuestType.craftOrbs,1);
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

    public void toggleBuy()
    {
        if (sell)
        {
            sell = false;
            buyButton.GetComponent<Image>().color = Green;
            sellButton.GetComponent<Image>().color = Grey;
        }
        else
        {
            sell = true;
            buyButton.GetComponent<Image>().color = Grey;
            sellButton.GetComponent<Image>().color = Red;
        }
    }

    public void toggleSell()
    {
        if (!sell)
        {
            sell = true;
            buyButton.GetComponent<Image>().color = Grey;
            sellButton.GetComponent<Image>().color = Red;
        }
        else
        {
            sell = false;
            buyButton.GetComponent<Image>().color = Green;
            sellButton.GetComponent<Image>().color = Grey;
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
            buyButton.SetActive(false);
            sellButton.SetActive(false);
            for (int x = 0; x < infusePhase.Count; x++) infusePhase[x].SetActive(false);
            for (int x = 0; x < buyPhase.Count; x++) buyPhase[x].SetActive(true);
        }
        else
        {
            open = true;
            UpgradeTitle.SetActive(false);
            GearTitle.SetActive(false);
            infuseTitle.SetActive(true);
            buyButton.SetActive(true);
            sellButton.SetActive(true);
            for (int x = 0; x < infusePhase.Count; x++) infusePhase[x].SetActive(true);
            for (int x = 0; x < buyPhase.Count; x++) buyPhase[x].SetActive(false);
        }
    }

    public void increaseScraps()
    {
        infuseBits++;
        qm.update(QuestType.findScraps, 1);
        textBits.text = fn.formatNumber(infuseBits);
        for (int x = 0; x < infuseBits; x++) { infuseBitsImg[x].SetActive(true); if (x == 8) x = infuseBits; }
    }

    public void craftOrb()
    {
        StartCoroutine(craftOrbCo());
    }

    public IEnumerator craftOrbCo()
    {
        if (infuseBits > 8)
        {
            infuseBits -= 9;
            infuseCoins += 1;
            textBits.text = fn.formatNumber(infuseBits);
            textInfuse.text = fn.formatNumber(infuseCoins);
            yield return null;
            //Animate Here//
            for (int x = 0; x < infuseBitsImg.Count; x++) infuseBitsImg[x].transform.DOMove(craftOrbObj.position, 2f);
            for (int x = 0; x < infuseBitsImg.Count; x++) infuseBitsImg[x].SetActive(false);
            for (int x = 0; x < infuseBits; x++) { infuseBitsImg[x].SetActive(true); if (x == 8) x = infuseBits; }
        }
    }

    public void buyInfuse(int index)
    {
        if(sell)
        {
            if (damage.itemInfuse[index] > 1)
            {
                damage.itemInfuse[index] -= 1;
                infuseBits += Random.Range(bitLowerBound, bitUpperBound + 1);
                textBits.text = fn.formatNumber(infuseBits);
                amountOwned[index].text = "X" + fn.formatNumber(damage.itemInfuse[index] - 1);
                bonusAmount[index].text = "(+" + fn.formatNumber((damage.itemInfuse[index] - 1) * 100) + "%)";
                if (damage.itemInfuse[index] == 1) gearNames[index].color = White;
            }
        }
        else
        {
            if (infuseCoins > 0)
            {
                qm.update(QuestType.spendOrbs, 1);
                damage.itemInfuse[index] += 1;
                infuseCoins--;
                textInfuse.text = fn.formatNumber(infuseCoins);
                amountOwned[index].text = "X" + fn.formatNumber(damage.itemInfuse[index] - 1);
                bonusAmount[index].text = "(+" + fn.formatNumber((damage.itemInfuse[index] - 1) * 100) + "%)";
                gearNames[index].color = Gold;
            }
        }
       
    }
}
