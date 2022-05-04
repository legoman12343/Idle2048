using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopButtonPopUp : MonoBehaviour
{
    public GameObject UpgradeTab;
    public GameObject AscensionTab;
    public GameObject SpecialCurrencyTab;
    public GameObject ExtraAreaTab;
    int activeShopTab;

    void Start()
    {
        activeShopTab = 1;
    }

    void changeShopTab()
    {
        if (activeShopTab == 1)
        {
            UpgradeTab.SetActive(true);
            AscensionTab.SetActive(false);
            SpecialCurrencyTab.SetActive(false);
            ExtraAreaTab.SetActive(false);
        }
        else if (activeShopTab == 2)
        {
            UpgradeTab.SetActive(false);
            AscensionTab.SetActive(true);
            SpecialCurrencyTab.SetActive(false);
            ExtraAreaTab.SetActive(false);
        }
        else if (activeShopTab == 3)
        {
            UpgradeTab.SetActive(false);
            AscensionTab.SetActive(false);
            SpecialCurrencyTab.SetActive(true);
            ExtraAreaTab.SetActive(false);
        }
        else if (activeShopTab == 4)
        {
            UpgradeTab.SetActive(false);
            AscensionTab.SetActive(false);
            SpecialCurrencyTab.SetActive(false);
            ExtraAreaTab.SetActive(true);
        }
    }

    public void OpenUpgradeTab()
    {
        activeShopTab = 1;
        changeShopTab();
    }

    public void OpenAscensionTab()
    {
        activeShopTab = 2;
        changeShopTab();
    }

    public void OpenSpecialCurrencyTab()
    {
        activeShopTab = 3;
        changeShopTab();
    }

    public void OpenExtrasTab()
    {
        activeShopTab = 4;
        changeShopTab();
    }
}
