using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopButtonPopUp : MonoBehaviour
{
    public GameObject UpgradeTab;
    public GameObject QuestTab;
    public GameObject AscensionTab;
    public GameObject SpecialCurrencyTab;
    public GameObject ExtraAreaTab;
    public GameObject GearPanel;
    public GameObject UpgradePanel;
    public GameObject HealthBar;
    public GameObject ProgessSwitchButton;
    public GameObject ButtonsBoarder;
    int activeShopTab;
    int activeUpgradePanel;
    public Swipe swipe;

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
                    ButtonsBoarder.SetActive(true);
                    GearPanel.SetActive(false);
                    UpgradePanel.SetActive(false);
                    UpgradeTab.SetActive(false);
                    swipe.canSwipe = true;
                }
                else
                {
                    swipe.canSwipe = false;
                    UpgradeTab.SetActive(true);
                    if (activeUpgradePanel == 1)
                    {
                        UpgradePanel.SetActive(true);
                    }
                    else
                    {
                        GearPanel.SetActive(true);                        
                    }
                    ButtonsBoarder.SetActive(false);
                    QuestTab.SetActive(false);
                    HealthBar.SetActive(true);
                    ProgessSwitchButton.SetActive(true);
                    AscensionTab.SetActive(false);
                    SpecialCurrencyTab.SetActive(false);
                    ExtraAreaTab.SetActive(false);
                }
                
                
                break;
            case 2:
                if (AscensionTab.active)
                {
                    ButtonsBoarder.SetActive(true);
                    AscensionTab.SetActive(false);
                    swipe.canSwipe = true;
                }
                else
                {
                    ButtonsBoarder.SetActive(false);
                    swipe.canSwipe = false;
                    AscensionTab.SetActive(true);
                    HealthBar.SetActive(true);
                    ProgessSwitchButton.SetActive(true);
                    UpgradeTab.SetActive(false);
                    QuestTab.SetActive(false);
                    SpecialCurrencyTab.SetActive(false);
                    ExtraAreaTab.SetActive(false);
                }
                
                break;
            case 3:
                if (SpecialCurrencyTab.active)
                {
                    ButtonsBoarder.SetActive(true);
                    SpecialCurrencyTab.SetActive(false);
                    swipe.canSwipe = true;
                }
                else
                {
                    ButtonsBoarder.SetActive(false);
                    swipe.canSwipe = false;
                    SpecialCurrencyTab.SetActive(true);
                    HealthBar.SetActive(true);
                    ProgessSwitchButton.SetActive(true);
                    UpgradeTab.SetActive(false);
                    QuestTab.SetActive(false);
                    AscensionTab.SetActive(false);
                    ExtraAreaTab.SetActive(false);
                }
                
                break;
            case 4:
                if (ExtraAreaTab.active)
                {
                    ButtonsBoarder.SetActive(true);
                    HealthBar.SetActive(true);
                    ProgessSwitchButton.SetActive(true);
                    ExtraAreaTab.SetActive(false);
                    swipe.canSwipe = true;
                }
                else
                {
                    ButtonsBoarder.SetActive(false);
                    swipe.canSwipe = false;
                    HealthBar.SetActive(false);
                    ProgessSwitchButton.SetActive(false);
                    ExtraAreaTab.SetActive(true);
                    UpgradeTab.SetActive(false);
                    QuestTab.SetActive(false);
                    AscensionTab.SetActive(false);
                    SpecialCurrencyTab.SetActive(false);
                }
                
                break;
            case 5:
                if (activeUpgradePanel == 1)
                {
                    UpgradePanel.SetActive(true);
                    GearPanel.SetActive(false);
                    swipe.canSwipe = true;
                }
                else
                {
                    UpgradePanel.SetActive(false);
                    GearPanel.SetActive(true);
                    swipe.canSwipe = false;
                }
                break;
            case 6:
                if (QuestTab.active)
                {
                    ButtonsBoarder.SetActive(true);
                    QuestTab.SetActive(false);
                    swipe.canSwipe = true;
                }
                else
                {
                    ButtonsBoarder.SetActive(false);
                    swipe.canSwipe = false;
                    HealthBar.SetActive(true);
                    ProgessSwitchButton.SetActive(true);
                    QuestTab.SetActive(true);
                    UpgradeTab.SetActive(false);
                    SpecialCurrencyTab.SetActive(false);
                    AscensionTab.SetActive(false);
                    ExtraAreaTab.SetActive(false);

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

    public void OpenQuestTab()
    {
        activeShopTab = 6;
        changeShopTab();
    }

}
