using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    public Sprite Open;
    public Sprite Close;
    public GameObject Shop;
    public GameObject Quests;
    public GameObject Ascension;
    public GameObject GemShop;
    public GameObject Extra;
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
                    Shop.GetComponent<Image>().sprite = Close;
                    ButtonsBoarder.SetActive(true);
                    GearPanel.SetActive(false);
                    UpgradePanel.SetActive(false);
                    UpgradeTab.SetActive(false);
                    swipe.canSwipe = true;
                }
                else
                {
                    Shop.GetComponent<Image>().sprite = Open;
                    Ascension.GetComponent<Image>().sprite = Close;
                    GemShop.GetComponent<Image>().sprite = Close;
                    Extra.GetComponent<Image>().sprite = Close;
                    Quests.GetComponent<Image>().sprite = Close;
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
                    Ascension.GetComponent<Image>().sprite = Close;
                    ButtonsBoarder.SetActive(true);
                    AscensionTab.SetActive(false);
                    swipe.canSwipe = true;
                }
                else
                {
                    Ascension.GetComponent<Image>().sprite = Open;
                    Shop.GetComponent<Image>().sprite = Close;
                    GemShop.GetComponent<Image>().sprite = Close;
                    Extra.GetComponent<Image>().sprite = Close;
                    Quests.GetComponent<Image>().sprite = Close;
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
                    GemShop.GetComponent<Image>().sprite = Close;
                    ButtonsBoarder.SetActive(true);
                    SpecialCurrencyTab.SetActive(false);
                    swipe.canSwipe = true;
                }
                else
                {
                    GemShop.GetComponent<Image>().sprite = Open;
                    Shop.GetComponent<Image>().sprite = Close;
                    Ascension.GetComponent<Image>().sprite = Close;
                    Extra.GetComponent<Image>().sprite = Close;
                    Quests.GetComponent<Image>().sprite = Close;
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
                    Extra.GetComponent<Image>().sprite = Close;
                    ButtonsBoarder.SetActive(true);
                    HealthBar.SetActive(true);
                    ProgessSwitchButton.SetActive(true);
                    ExtraAreaTab.SetActive(false);
                    swipe.canSwipe = true;
                }
                else
                {
                    Extra.GetComponent<Image>().sprite = Open;
                    Shop.GetComponent<Image>().sprite = Close;
                    Ascension.GetComponent<Image>().sprite = Close;
                    GemShop.GetComponent<Image>().sprite = Close;
                    Quests.GetComponent<Image>().sprite = Close;
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
                    Quests.GetComponent<Image>().sprite = Close;
                    ButtonsBoarder.SetActive(true);
                    QuestTab.SetActive(false);
                    swipe.canSwipe = true;
                }
                else
                {
                    Quests.GetComponent<Image>().sprite = Open;
                    Shop.GetComponent<Image>().sprite = Close;
                    Ascension.GetComponent<Image>().sprite = Close;
                    GemShop.GetComponent<Image>().sprite = Close;
                    Extra.GetComponent<Image>().sprite = Close;
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
