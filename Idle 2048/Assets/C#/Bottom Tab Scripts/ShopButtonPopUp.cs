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
    public GameObject GearPanel;
    public GameObject UpgradePanel;
    public GameObject HealthBar;
    int activeShopTab;
    int activeUpgradePanel;

    void Start()
    {
        activeUpgradePanel = 2;
    }

    void changeShopTab()
    {
        switch (activeShopTab)
        {
            case 1:
                if (UpgradeTab.active)
                {
                    GearPanel.SetActive(false);
                    UpgradePanel.SetActive(false);
                    UpgradeTab.SetActive(false);
                }
                else
                {
                    UpgradeTab.SetActive(true);
                    if (activeUpgradePanel == 1)
                    {
                        UpgradePanel.SetActive(true);
                    }
                    else
                    {
                        GearPanel.SetActive(true);
                    }
                }
                HealthBar.SetActive(true);
                AscensionTab.SetActive(false);
                SpecialCurrencyTab.SetActive(false);
                optionsTab.SetActive(false);
                achievementsTab.SetActive(false);
                ExtraAreaTab.SetActive(false);
                break;
            case 2:
                if (AscensionTab.active)
                {
                    AscensionTab.SetActive(false);
                }
                else
                {
                    AscensionTab.SetActive(true);
                }
                HealthBar.SetActive(true);
                UpgradeTab.SetActive(false);
                SpecialCurrencyTab.SetActive(false);
                optionsTab.SetActive(false);
                achievementsTab.SetActive(false);
                ExtraAreaTab.SetActive(false);
                break;
            case 3:
                if (SpecialCurrencyTab.active)
                {
                    SpecialCurrencyTab.SetActive(false);
                }
                else
                {
                    SpecialCurrencyTab.SetActive(true);
                }
                HealthBar.SetActive(true);
                UpgradeTab.SetActive(false);
                AscensionTab.SetActive(false);
                optionsTab.SetActive(false);
                achievementsTab.SetActive(false);
                ExtraAreaTab.SetActive(false);
                break;
            case 4:
                if (ExtraAreaTab.active)
                {
                    HealthBar.SetActive(true);
                    optionsTab.SetActive(false);
                    achievementsTab.SetActive(false);
                    ExtraAreaTab.SetActive(false);
                }
                else
                {
                    HealthBar.SetActive(false);
                    ExtraAreaTab.SetActive(true);
                }
                UpgradeTab.SetActive(false);
                AscensionTab.SetActive(false);
                SpecialCurrencyTab.SetActive(false);
                break;
            case 5:
                if (activeUpgradePanel == 1)
                {
                    UpgradePanel.SetActive(true);
                    GearPanel.SetActive(false);
                }
                else
                {
                    UpgradePanel.SetActive(false);
                    GearPanel.SetActive(true);
                }
                break;
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

    public void OpenGearTab()
    {
        activeUpgradePanel = 2;
        activeShopTab = 5;
        changeShopTab();
    }

    public void OpenUpgradePanel()
    {
        activeUpgradePanel = 1;
        activeShopTab = 5;
        changeShopTab();
    }

}
