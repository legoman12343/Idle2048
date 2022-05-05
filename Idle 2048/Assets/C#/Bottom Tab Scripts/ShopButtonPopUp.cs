using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopButtonPopUp : MonoBehaviour
{
    public GameObject UpgradeTab;
    public GameObject AscensionTab;
    public GameObject SpecialCurrencyTab;
    public GameObject ExtraAreaTab;
    public GameObject optionsTab;
    public GameObject achievementsTab;
    int activeShopTab;

  
    void changeShopTab()
    {
        if (activeShopTab == 1)
        {
            if (UpgradeTab.active)
            {
                UpgradeTab.SetActive(false);
            }
            else
            {
                UpgradeTab.SetActive(true);
            }
            AscensionTab.SetActive(false);
            SpecialCurrencyTab.SetActive(false);
            if (optionsTab.active)
            {
                optionsTab.SetActive(false);
            }
            if (achievementsTab.active)
            {
                achievementsTab.SetActive(false);
            }
            ExtraAreaTab.SetActive(false);
        }
        else if (activeShopTab == 2)
        {
            if (AscensionTab.active)
            {
                AscensionTab.SetActive(false);
            }
            else
            {
                AscensionTab.SetActive(true);
            }
            UpgradeTab.SetActive(false);
            SpecialCurrencyTab.SetActive(false);
            if (optionsTab.active)
            {
                optionsTab.SetActive(false);
            }
            if (achievementsTab.active)
            {
                achievementsTab.SetActive(false);
            }
            ExtraAreaTab.SetActive(false);
        }
        else if (activeShopTab == 3)
        {
            if (SpecialCurrencyTab.active)
            {
                SpecialCurrencyTab.SetActive(false);
            }
            else
            {
                SpecialCurrencyTab.SetActive(true);
            }
            UpgradeTab.SetActive(false);
            AscensionTab.SetActive(false);
            if (optionsTab.active)
            {
                optionsTab.SetActive(false);
            }
            if (achievementsTab.active)
            {
                achievementsTab.SetActive(false);
            }
            ExtraAreaTab.SetActive(false);
        }
        else if (activeShopTab == 4)
        {
            if (ExtraAreaTab.active)
            {
                if (optionsTab.active)
                {
                    optionsTab.SetActive(false);
                }
                if (achievementsTab.active)
                {
                    achievementsTab.SetActive(false);
                }
                ExtraAreaTab.SetActive(false);
            }
            else
            {
                ExtraAreaTab.SetActive(true);
            }
            UpgradeTab.SetActive(false);
            AscensionTab.SetActive(false);
            SpecialCurrencyTab.SetActive(false);
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