using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

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
    public GameObject UpgradeWindow;
    public GameObject AscensionWindow;
    public GameObject QuestWindow;
    public GameObject GemWindow;
    public GameObject ExtraWindow;
    public Sprite Open;
    public Sprite Close;
    public GameObject Shop;
    public GameObject Quests;
    public GameObject Ascension;
    public GameObject GemShop;
    public GameObject Extra;
    public GameObject UpgradeTitle;
    public GameObject GearTitle;
    private int activeShopTab;
    private int activeUpgradePanel;
    private int lastButton;
    public Swipe swipe;
    private Color32 Dark = new Color32(164, 164, 164, 255);
    private Color32 Light = new Color32(255, 255, 255, 255);
    public GameObject ShopEnd;
    public GameObject ShopEndAscension;
    public GameObject ShopStart;
    private Vector3 startPoint;
    private Vector3 endPointAscension;
    private Vector3 endPoint;
    public NotificationAnimation upgradeAnimation;

    void Start()
    {
        activeUpgradePanel = 2;
        endPoint = ShopEnd.transform.position;
        endPointAscension = ShopEndAscension.transform.position;
        startPoint = ShopStart.transform.position;
    }

    void changeShopTab()
    {
        if(!UpgradeTab.activeSelf && !QuestTab.activeSelf && !AscensionTab.activeSelf && !SpecialCurrencyTab.activeSelf && !ExtraAreaTab.activeSelf)
        {
            lastButton = 0;
        }
        if (activeShopTab != 5)
        {
            switch (lastButton)
            {
                case 1:
                    Shop.GetComponent<Image>().sprite = Close;
                    ButtonsBoarder.SetActive(true);
                    GearPanel.SetActive(false);
                    UpgradePanel.SetActive(false);
                    UpgradeTab.SetActive(false);
                    swipe.canSwipe = true;
                    break;
                case 2:
                    Ascension.GetComponent<Image>().sprite = Close;
                    ButtonsBoarder.SetActive(true);
                    AscensionTab.SetActive(false);
                    swipe.canSwipe = true;
                    break;
                case 3:
                    GemShop.GetComponent<Image>().sprite = Close;
                    ButtonsBoarder.SetActive(true);
                    SpecialCurrencyTab.SetActive(false);
                    swipe.canSwipe = true;
                    break;
                case 4:
                    Extra.GetComponent<Image>().sprite = Close;
                    ButtonsBoarder.SetActive(true);
                    HealthBar.SetActive(true);
                    ProgessSwitchButton.SetActive(true);
                    ExtraAreaTab.SetActive(false);
                    swipe.canSwipe = true;
                    break;
                case 6:
                    Quests.GetComponent<Image>().sprite = Close;
                    ButtonsBoarder.SetActive(true);
                    QuestTab.SetActive(false);
                    swipe.canSwipe = true;
                    break;
            }
        }
        if (activeShopTab != lastButton || activeShopTab == 5)
        {
            switch (activeShopTab)
            {
                case 1:
                    Shop.GetComponent<Image>().sprite = Open;
                    swipe.canSwipe = false;
                    UpgradeTab.SetActive(true);
                    UpgradeWindow.transform.position = startPoint;
                    ButtonsBoarder.SetActive(false);
                    if (activeUpgradePanel == 1)
                    {
                        GearTitle.GetComponent<Image>().color = Dark;
                        UpgradeTitle.GetComponent<Image>().color = Light;
                        UpgradePanel.SetActive(true);
                    }
                    else
                    {
                        UpgradeTitle.GetComponent<Image>().color = Dark;
                        GearTitle.GetComponent<Image>().color = Light;
                        GearPanel.SetActive(true);
                    }
                    UpgradeWindow.transform.DOMove(endPoint, 0.2f);
                    upgradeAnimation.stopAnimation();
                    break;
                case 2:
                    Ascension.GetComponent<Image>().sprite = Open;
                    ButtonsBoarder.SetActive(false);
                    swipe.canSwipe = false;
                    AscensionTab.SetActive(true);
                    AscensionWindow.transform.position = startPoint;
                    AscensionWindow.transform.DOMove(endPointAscension, 0.2f);
                    break;
                case 3:
                    GemShop.GetComponent<Image>().sprite = Open;
                    ButtonsBoarder.SetActive(false);
                    swipe.canSwipe = false;
                    SpecialCurrencyTab.SetActive(true);
                    GemWindow.transform.position = startPoint;
                    GemWindow.transform.DOMove(endPoint, 0.2f);
                    break;
                case 4:
                    Extra.GetComponent<Image>().sprite = Open;
                    ButtonsBoarder.SetActive(false);
                    swipe.canSwipe = false;
                    HealthBar.SetActive(false);
                    ProgessSwitchButton.SetActive(false);
                    ExtraAreaTab.SetActive(true);
                    ExtraWindow.transform.position = startPoint;
                    ExtraWindow.transform.DOMove(endPointAscension, 0.2f);
                    break;
                case 5:
                    if (activeUpgradePanel == 1)
                    {
                        GearTitle.GetComponent<Image>().color = Dark;
                        UpgradeTitle.GetComponent<Image>().color = Light;
                        UpgradePanel.SetActive(true);
                        GearPanel.SetActive(false);
                        swipe.canSwipe = true;
                    }
                    else
                    {
                        UpgradeTitle.GetComponent<Image>().color = Dark;
                        GearTitle.GetComponent<Image>().color = Light;
                        UpgradePanel.SetActive(false);
                        GearPanel.SetActive(true);
                        swipe.canSwipe = false;
                    }
                    break;
                case 6:
                    Quests.GetComponent<Image>().sprite = Open;
                    ButtonsBoarder.SetActive(false);
                    swipe.canSwipe = false;
                    QuestTab.SetActive(true);
                    QuestWindow.transform.position = startPoint;
                    QuestWindow.transform.DOMove(endPoint, 0.2f);
                    break;
            }
        }
    }

    public void OpenUpgradeTab()
    {
        activeShopTab = 1;
        changeShopTab();
        lastButton = 1;
    }

    public void OpenAscensionTab()
    {
        activeShopTab = 2;
        changeShopTab();
        lastButton = 2;
    }

    public void OpenSpecialCurrencyTab()
    {
        activeShopTab = 3;
        changeShopTab();
        lastButton = 3;
    }

    public void OpenExtrasTab()
    {
        activeShopTab = 4;
        changeShopTab();
        lastButton = 4;
    }

    public void OpenGearTab()
    {
        activeUpgradePanel = 2;
        activeShopTab = 5;
        changeShopTab();
        lastButton = 1;
    }

    public void OpenUpgradePanel()
    {
        activeUpgradePanel = 1;
        activeShopTab = 5;
        changeShopTab();
        lastButton = 1;
    }

    public void OpenQuestTab()
    {
        activeShopTab = 6;
        changeShopTab();
        lastButton = 6;
    }
}
