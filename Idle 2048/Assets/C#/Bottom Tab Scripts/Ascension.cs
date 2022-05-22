using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Security.Cryptography;
using TMPro;
using System.Threading;

public class Ascension : MonoBehaviour
{

    [SerializeField] public List<GameObject> popUpList;
    [SerializeField] public List<Image> buttonList;
    [SerializeField] public List<GameObject> upgradesList;
    [SerializeField] public List<GameObject> gearList;
    private Color32 Green = new Color32(37, 166, 12, 255);
    private Color32 RedButton = new Color32(178, 18, 18, 255);
    private Color32 RedSlider = new Color32(212, 27, 27, 255);
    [SerializeField] public List<Slider> SliderList;
    private int lastButton;
    private int currentButton;
    public int ascensionCoinsHave;
    public int ascensionCoinsToGet = 1_000_000;
    public TextMeshProUGUI ascensionCoinsHaveDisplay;
    public Text ascensionCoinsToGetDisplay;
    private bool firstAscension = true;
    private GameObject tempObject;
    private int cost;
    private float timer;
    public Sprite redSliderSprite;

    public GameManager gameManager;
    public MonsterPrefabStuff monsterPrefabStuff;
    public BuyItem buyItem;
    public BuyItem buyItemCrate;
    public Damage damageScript;
    public FormatNumber formatNumber;

    private bool biggerGridUnlock1 = false;
    private bool biggerGridUnlock2 = false;
    private bool tileLevelUnlock1 = false;
    private bool tileLevelUnlock2 = false;
    private bool moneyDamageUnlock1 = false;
    private bool moneyDamageUnlock2 = false;
    private bool tileLevelUnlock = false;
    private bool biggerGridUnlock = false;
    private bool moneyDamageUnlock = false;
    private bool openOnceTileLevel = false;
    private bool openOnceBiggerGrid = false;
    private bool openOnceMoneyDamage = false;


    //ascension buttons
    public void openAscensionPopUp()
    {
        currentButton = 37;
        openAndClose();
        lastButton = 37;
        string ascensionCoinsToGetString = formatNumber.formatNumber(ascensionCoinsToGet, false);  
        ascensionCoinsToGetDisplay.text = ascensionCoinsToGetString;
    }
    public void buyAscension()
    {
       if (ascensionCoinsToGet != 0)
       {
            ascensionCoinsHave += ascensionCoinsToGet;
            ascensionCoinsToGet = 0;
            popUpList[36].gameObject.SetActive(false);
            string ascensionCoinsHaveString = FormatNumber(ascensionCoinsHave);
            ascensionCoinsHaveDisplay.text = ascensionCoinsHaveString;
            if (firstAscension == true)
            {
                firstAscension = false;
                tempObject = SliderList[1].transform.Find("Background").gameObject;
                tempObject.GetComponent<Image>().color = RedSlider;
                tempObject.GetComponent<Image>().sprite = redSliderSprite;
                tempObject = SliderList[12].transform.Find("Background").gameObject;
                tempObject.GetComponent<Image>().color = RedSlider;
                tempObject.GetComponent<Image>().sprite = redSliderSprite;
                tempObject = SliderList[18].transform.Find("Background").gameObject;
                tempObject.GetComponent<Image>().color = RedSlider;
                tempObject.GetComponent<Image>().sprite = redSliderSprite;
                tempObject = SliderList[27].transform.Find("Background").gameObject;
                tempObject.GetComponent<Image>().color = RedSlider;
                tempObject.GetComponent<Image>().sprite = redSliderSprite;
                tempObject = SliderList[33].transform.Find("Background").gameObject;
                tempObject.GetComponent<Image>().color = RedSlider;
                tempObject.GetComponent<Image>().sprite = redSliderSprite;
                buttonList[1].GetComponent<Image>().color = RedButton;
                buttonList[1].GetComponent<Button>().interactable = true;
                tempObject = buttonList[1].transform.Find("Image").gameObject;
                tempObject.SetActive(true);
                buttonList[14].GetComponent<Image>().color = RedButton;
                buttonList[14].GetComponent<Button>().interactable = true;
                tempObject = buttonList[14].transform.Find("Image").gameObject;
                tempObject.SetActive(true);
                buttonList[2].GetComponent<Image>().color = RedButton;
                buttonList[2].GetComponent<Button>().interactable = true;
                tempObject = buttonList[2].transform.Find("Image").gameObject;
                tempObject.SetActive(true);
                buttonList[19].GetComponent<Image>().color = RedButton;
                buttonList[19].GetComponent<Button>().interactable = true;
                tempObject = buttonList[19].transform.Find("Image").gameObject;
                tempObject.SetActive(true);
                buttonList[26].GetComponent<Image>().color = RedButton;
                buttonList[26].GetComponent<Button>().interactable = true;
                tempObject = buttonList[26].transform.Find("Image").gameObject;
                tempObject.SetActive(true);
                tempObject = buttonList[0].transform.Find("PopUp/Button_Confirm").gameObject;
                tempObject.SetActive(true);
                tempObject = buttonList[13].transform.Find("PopUp/Button_Confirm").gameObject;
                tempObject.SetActive(true);
                tempObject = buttonList[18].transform.Find("PopUp/Button_Confirm").gameObject;
                tempObject.SetActive(true);
                tempObject = buttonList[25].transform.Find("PopUp/Button_Confirm").gameObject;
                tempObject.SetActive(true);
            }

            //----------------------//
            //----- reset game------//
            //---------------------//
       }
    }

    string FormatNumber(float num)
    {
        return formatNumber.formatNumber(num, true);
    }

    private IEnumerator buyAnimation(Slider _slider, Image _button)
    {
        while (_slider.value < 1)
        {
            _slider.value += 0.01f;
            yield return new WaitForSeconds(0.0001f);
        }
        _button.color = Green;
        if (tileLevelUnlock1 && tileLevelUnlock2 && tileLevelUnlock == false)
        {
            tileLevelUnlock = true;
            StartCoroutine(buyAnimation(SliderList[23], buttonList[37]));
            StartCoroutine(buyAnimation(SliderList[25], buttonList[37]));
        }
        if (biggerGridUnlock1 && biggerGridUnlock2 && biggerGridUnlock == false)
        {
            biggerGridUnlock = true;
            StartCoroutine(buyAnimation(SliderList[17], buttonList[38]));
            StartCoroutine(buyAnimation(SliderList[20], buttonList[38]));
        }
        if (moneyDamageUnlock1 && moneyDamageUnlock2 && moneyDamageUnlock == false)
        {
            moneyDamageUnlock = true;
            StartCoroutine(buyAnimation(SliderList[31], buttonList[39]));
            StartCoroutine(buyAnimation(SliderList[36], buttonList[39]));
        }
    }

    private void openAndClose()
    {
        if ((lastButton == currentButton) && (popUpList[currentButton - 1].gameObject.activeSelf == false)) lastButton = 0;
        if (lastButton != 0) popUpList[lastButton - 1].gameObject.SetActive(false);
        if (lastButton != currentButton) popUpList[currentButton - 1].gameObject.SetActive(true);
    }

    //tile buttons
    public void tileButton1a() {
        currentButton = 1;
        openAndClose();
        lastButton = 1;
    }
    public void tileButton1b() {
        cost = 1;
        if (ascensionCoinsHave >= cost)
        {
            ascensionCoinsHave -= cost;
            StartCoroutine(buyAnimation(SliderList[11], buttonList[0]));
            tempObject = SliderList[19].transform.Find("Background").gameObject;
            tempObject.GetComponent<Image>().color = RedSlider;
            tempObject.GetComponent<Image>().sprite = redSliderSprite;
            tempObject = SliderList[21].transform.Find("Background").gameObject;
            tempObject.GetComponent<Image>().color = RedSlider;
            tempObject.GetComponent<Image>().sprite = redSliderSprite;
            tempObject = SliderList[13].transform.Find("Background").gameObject;
            tempObject.GetComponent<Image>().color = RedSlider;
            tempObject.GetComponent<Image>().sprite = redSliderSprite;
            buttonList[3].GetComponent<Image>().color = RedButton;
            buttonList[3].GetComponent<Button>().interactable = true;
            tempObject = buttonList[3].transform.Find("Image").gameObject;
            tempObject.SetActive(true);
            buttonList[8].GetComponent<Image>().color = RedButton;
            buttonList[8].GetComponent<Button>().interactable = true;
            tempObject = buttonList[8].transform.Find("Image").gameObject;
            tempObject.SetActive(true);
            buttonList[9].GetComponent<Image>().color = RedButton;
            buttonList[9].GetComponent<Button>().interactable = true;
            tempObject = buttonList[9].transform.Find("Image").gameObject;
            tempObject.SetActive(true);
            tempObject = buttonList[1].transform.Find("PopUp/Button_Confirm").gameObject;
            tempObject.SetActive(true);
            tempObject = buttonList[2].transform.Find("PopUp/Button_Confirm").gameObject;
            tempObject.SetActive(true);
            tempObject = buttonList[0].transform.Find("PopUp/Button_Confirm").gameObject;
            tempObject.SetActive(false);
            popUpList[0].SetActive(false);

            gameManager.startingValue += 3;
        }
    }
    public void tileButton2a() {
        currentButton = 2;
        openAndClose();
        lastButton = 2;
    }
    public void tileButton2b() {
        cost = 1;
        if (ascensionCoinsHave >= cost)
        {
            ascensionCoinsHave -= cost;
            StartCoroutine(buyAnimation(SliderList[18], buttonList[1]));
            buttonList[38].GetComponent<Image>().color = RedButton;
            tempObject = SliderList[20].transform.Find("Background").gameObject;
            tempObject.GetComponent<Image>().color = RedSlider;
            tempObject.GetComponent<Image>().sprite = redSliderSprite;
            tempObject = SliderList[22].transform.Find("Background").gameObject;
            tempObject.GetComponent<Image>().color = RedSlider;
            tempObject.GetComponent<Image>().sprite = redSliderSprite;
            tempObject = SliderList[24].transform.Find("Background").gameObject;
            tempObject.GetComponent<Image>().color = RedSlider;
            tempObject.GetComponent<Image>().sprite = redSliderSprite;
            buttonList[10].GetComponent<Image>().color = RedButton;
            buttonList[10].GetComponent<Button>().interactable = true;
            tempObject = buttonList[10].transform.Find("Image").gameObject;
            tempObject.SetActive(true);
            buttonList[11].GetComponent<Image>().color = RedButton;
            buttonList[11].GetComponent<Button>().interactable = true;
            tempObject = buttonList[11].transform.Find("Image").gameObject;
            tempObject.SetActive(true);
            tempObject = buttonList[8].transform.Find("PopUp/Button_Confirm").gameObject;
            tempObject.SetActive(true);
            tempObject = buttonList[9].transform.Find("PopUp/Button_Confirm").gameObject;
            tempObject.SetActive(true);
            tempObject = buttonList[1].transform.Find("PopUp/Button_Confirm").gameObject;
            tempObject.SetActive(false);
            popUpList[1].SetActive(false);

            gameManager.startingValue *= 2;
        }
    }
    public void tileButton3a() {
        currentButton = 3;
        openAndClose();
        lastButton = 3;
    }
    public void tileButton3b() {
        cost = 1;
        if (ascensionCoinsHave >= cost)
        {
            ascensionCoinsHave -= cost;
            StartCoroutine(buyAnimation(SliderList[12], buttonList[2]));
            tempObject = SliderList[14].transform.Find("Background").gameObject;
            tempObject.GetComponent<Image>().color = RedSlider;
            tempObject.GetComponent<Image>().sprite = redSliderSprite;
            buttonList[4].GetComponent<Image>().color = RedButton;
            buttonList[4].GetComponent<Button>().interactable = true;
            tempObject = buttonList[4].transform.Find("Image").gameObject;
            tempObject.SetActive(true);
            tempObject = buttonList[3].transform.Find("PopUp/Button_Confirm").gameObject;
            tempObject.SetActive(true);
            tempObject = buttonList[2].transform.Find("PopUp/Button_Confirm").gameObject;
            tempObject.SetActive(false);
            popUpList[2].SetActive(false);

            gameManager.criticalHitChance += 0.03f;
        }
    }
    public void tileButton4a() {
        currentButton = 4;
        openAndClose();
        lastButton = 4;
    }
    public void tileButton4b() {
        cost = 1;
        if (ascensionCoinsHave >= cost)
        {
            ascensionCoinsHave -= cost;
            StartCoroutine(buyAnimation(SliderList[13], buttonList[3]));
            tempObject = SliderList[15].transform.Find("Background").gameObject;
            tempObject.GetComponent<Image>().color = RedSlider;
            tempObject.GetComponent<Image>().sprite = redSliderSprite;
            tempObject = SliderList[16].transform.Find("Background").gameObject;
            tempObject.GetComponent<Image>().color = RedSlider;
            tempObject.GetComponent<Image>().sprite = redSliderSprite;
            buttonList[5].GetComponent<Image>().color = RedButton;
            buttonList[5].GetComponent<Button>().interactable = true;
            tempObject = buttonList[5].transform.Find("Image").gameObject;
            tempObject.SetActive(true);
            buttonList[6].GetComponent<Image>().color = RedButton;
            buttonList[6].GetComponent<Button>().interactable = true;
            tempObject = buttonList[6].transform.Find("Image").gameObject;
            tempObject.SetActive(true);
            tempObject = buttonList[4].transform.Find("PopUp/Button_Confirm").gameObject;
            tempObject.SetActive(true);
            tempObject = buttonList[3].transform.Find("PopUp/Button_Confirm").gameObject;
            tempObject.SetActive(false);
            popUpList[3].SetActive(false);

            gameManager.criticalHitChance += 0.05f;
        }
    }
    public void tileButton5a() {
        currentButton = 5;
        openAndClose();
        lastButton = 5;
    }
    public void tileButton5b() {
        cost = 1;
        if (ascensionCoinsHave >= cost)
        {
            ascensionCoinsHave -= cost;
            StartCoroutine(buyAnimation(SliderList[14], buttonList[4]));
            buttonList[38].GetComponent<Image>().color = RedButton;
            tempObject = SliderList[17].transform.Find("Background").gameObject;
            tempObject.GetComponent<Image>().color = RedSlider;
            tempObject.GetComponent<Image>().sprite = redSliderSprite;
            tempObject = buttonList[5].transform.Find("PopUp/Button_Confirm").gameObject;
            tempObject.SetActive(true);
            tempObject = buttonList[6].transform.Find("PopUp/Button_Confirm").gameObject;
            tempObject.SetActive(true);
            tempObject = buttonList[4].transform.Find("PopUp/Button_Confirm").gameObject;
            tempObject.SetActive(false);
            popUpList[4].SetActive(false);

            gameManager.startingValue *= 8;
        }
    }
    public void tileButton6a() {
        currentButton = 6;
        openAndClose();
        lastButton = 6;
    }
    public void tileButton6b() {
        cost = 1;
        if (ascensionCoinsHave >= cost)
        {
            ascensionCoinsHave -= cost;
            StartCoroutine(buyAnimation(SliderList[15], buttonList[5]));
            tempObject = buttonList[5].transform.Find("PopUp/Button_Confirm").gameObject;
            tempObject.SetActive(false);
            popUpList[5].SetActive(false);

            gameManager.travelTime -= 0.05f;
        }
    }
    public void tileButton7a() {
        currentButton = 7;
        openAndClose();
        lastButton = 7;
    }
    public void tileButton7b() {
        cost = 1;
        if (ascensionCoinsHave >= cost)
        {
            biggerGridUnlock1 = true;
            ascensionCoinsHave -= cost;
            StartCoroutine(buyAnimation(SliderList[16], buttonList[6]));
            tempObject = buttonList[6].transform.Find("PopUp/Button_Confirm").gameObject;
            tempObject.SetActive(false);
            buttonList[7].GetComponent<Image>().color = RedButton;
            buttonList[7].GetComponent<Button>().interactable = true;
            tempObject = buttonList[7].transform.Find("Image").gameObject;
            tempObject.SetActive(true);
            popUpList[6].SetActive(false);

            gameManager.criticalHitChance += 0.10f;
        }
    }
    public void tileButton8a() {
        currentButton = 8;
        openAndClose();
        lastButton = 8;
        if (biggerGridUnlock1 && biggerGridUnlock2 && !openOnceBiggerGrid)
        {
            openOnceBiggerGrid = true;
            tempObject = buttonList[7].transform.Find("PopUp/Button_Confirm").gameObject;
            tempObject.SetActive(true);
        }
    }
    public void tileButton8b() {
        cost = 1;
        if (ascensionCoinsHave >= cost)
        {
            ascensionCoinsHave -= cost;
            StartCoroutine(buyAnimation(SliderList[40], buttonList[7]));
            tempObject = buttonList[7].transform.Find("PopUp/Button_Confirm").gameObject;
            tempObject.SetActive(false);
            popUpList[7].SetActive(false);

            gameManager.gridSizeUp = true;
            gameManager.makeGrid();
        }
    }
    public void tileButton9a() {
        currentButton = 9;
        openAndClose();
        lastButton = 9;
    }
    public void tileButton9b() {
        cost = 1;
        if (ascensionCoinsHave >= cost)
        {
            biggerGridUnlock2 = true;
            ascensionCoinsHave -= cost;
            StartCoroutine(buyAnimation(SliderList[19], buttonList[8]));
            tempObject = buttonList[8].transform.Find("PopUp/Button_Confirm").gameObject;
            tempObject.SetActive(false);
            tempObject = SliderList[40].transform.Find("Background").gameObject;
            tempObject.GetComponent<Image>().color = RedSlider;
            tempObject.GetComponent<Image>().sprite = redSliderSprite;
            buttonList[7].GetComponent<Image>().color = RedButton;
            buttonList[7].GetComponent<Button>().interactable = true;
            tempObject = buttonList[7].transform.Find("Image").gameObject;
            tempObject.SetActive(true);
            popUpList[8].SetActive(false);

            gameManager.travelTime -= 0.05f;
        }
    }
    public void tileButton10a() {
        currentButton = 10;
        openAndClose();
        lastButton = 10;
    }
    public void tileButton10b() {
        cost = 1;
        if (ascensionCoinsHave >= cost)
        {
            ascensionCoinsHave -= cost;
            StartCoroutine(buyAnimation(SliderList[21], buttonList[9]));
            tempObject = SliderList[23].transform.Find("Background").gameObject;
            tempObject.GetComponent<Image>().color = RedSlider;
            tempObject.GetComponent<Image>().sprite = redSliderSprite;
            tempObject = SliderList[25].transform.Find("Background").gameObject;
            tempObject.GetComponent<Image>().color = RedSlider;
            tempObject.GetComponent<Image>().sprite = redSliderSprite;
            buttonList[37].GetComponent<Image>().color = RedButton;
            tempObject = buttonList[10].transform.Find("PopUp/Button_Confirm").gameObject;
            tempObject.SetActive(true);
            tempObject = buttonList[11].transform.Find("PopUp/Button_Confirm").gameObject;
            tempObject.SetActive(true);
            tempObject = buttonList[9].transform.Find("PopUp/Button_Confirm").gameObject;
            tempObject.SetActive(false);
            popUpList[9].SetActive(false);

            gameManager.startingValue *= 8;
        }
    }
    public void tileButton11a() {
        currentButton = 11;
        openAndClose();
        lastButton = 11;
    }
    public void tileButton11b() {
        cost = 1;
        if (ascensionCoinsHave >= cost)
        {
            tileLevelUnlock1 = true;
            ascensionCoinsHave -= cost;
            StartCoroutine(buyAnimation(SliderList[24], buttonList[10]));
            tempObject = buttonList[10].transform.Find("PopUp/Button_Confirm").gameObject;
            tempObject.SetActive(false);
            buttonList[12].GetComponent<Image>().color = RedButton;
            buttonList[12].GetComponent<Button>().interactable = true;
            tempObject = buttonList[12].transform.Find("Image").gameObject;
            tempObject.SetActive(true);
            tempObject = SliderList[39].transform.Find("Background").gameObject;
            tempObject.GetComponent<Image>().color = RedSlider;
            tempObject.GetComponent<Image>().sprite = redSliderSprite;
            popUpList[10].SetActive(false);

            gameManager.startingValue *= 16;
        }
    }
    public void tileButton12a() {
        currentButton = 12;
        openAndClose();
        lastButton = 12;
    }
    public void tileButton12b() {
        cost = 1;
        if (ascensionCoinsHave >= cost)
        {
            tileLevelUnlock2 = true;
            ascensionCoinsHave -= cost;
            StartCoroutine(buyAnimation(SliderList[22], buttonList[11]));
            tempObject = buttonList[11].transform.Find("PopUp/Button_Confirm").gameObject;
            tempObject.SetActive(false);
            buttonList[12].GetComponent<Image>().color = RedButton;
            buttonList[12].GetComponent<Button>().interactable = true;
            tempObject = buttonList[12].transform.Find("Image").gameObject;
            tempObject.SetActive(true);
            tempObject = SliderList[39].transform.Find("Background").gameObject;
            tempObject.GetComponent<Image>().color = RedSlider;
            tempObject.GetComponent<Image>().sprite = redSliderSprite;
            popUpList[11].SetActive(false);

            gameManager.startingValue *= 16;
        }
    }
    public void tileButton13a() {
        currentButton = 13;
        openAndClose();
        lastButton = 13;
        if (tileLevelUnlock1 && tileLevelUnlock2 && !openOnceTileLevel)
        {
            openOnceTileLevel = true;
            tempObject = buttonList[12].transform.Find("PopUp/Button_Confirm").gameObject;
            tempObject.SetActive(true);
        }
    }
    public void tileButton13b() {
        cost = 1;
        if (ascensionCoinsHave >= cost)
        {
            ascensionCoinsHave -= cost;
            StartCoroutine(buyAnimation(SliderList[39], buttonList[12]));
            tempObject = buttonList[12].transform.Find("PopUp/Button_Confirm").gameObject;
            tempObject.SetActive(false);
            popUpList[12].SetActive(false);

            gameManager.startingValue *= 32;
        }
    }
    //money buttons
    public void moneyButton1a() {
        currentButton = 14;
        openAndClose();
        lastButton = 14;
    }
    public void moneyButton1b() {
        cost = 1;
        if (ascensionCoinsHave >= cost)
        {
            ascensionCoinsHave -= cost;
            StartCoroutine(buyAnimation(SliderList[26], buttonList[13]));
            buttonList[39].GetComponent<Image>().color = RedButton;
            tempObject = SliderList[28].transform.Find("Background").gameObject;
            tempObject.GetComponent<Image>().color = RedSlider;
            tempObject.GetComponent<Image>().sprite = redSliderSprite;
            tempObject = SliderList[29].transform.Find("Background").gameObject;
            tempObject.GetComponent<Image>().color = RedSlider;
            tempObject.GetComponent<Image>().sprite = redSliderSprite;
            tempObject = SliderList[30].transform.Find("Background").gameObject;
            tempObject.GetComponent<Image>().color = RedSlider;
            tempObject.GetComponent<Image>().sprite = redSliderSprite;
            tempObject = SliderList[31].transform.Find("Background").gameObject;
            tempObject.GetComponent<Image>().color = RedSlider;
            tempObject.GetComponent<Image>().sprite = redSliderSprite;
            buttonList[15].GetComponent<Image>().color = RedButton;
            buttonList[15].GetComponent<Button>().interactable = true;
            tempObject = buttonList[15].transform.Find("Image").gameObject;
            tempObject.SetActive(true);
            buttonList[16].GetComponent<Image>().color = RedButton;
            buttonList[16].GetComponent<Button>().interactable = true;
            tempObject = buttonList[16].transform.Find("Image").gameObject;
            tempObject.SetActive(true);
            buttonList[17].GetComponent<Image>().color = RedButton;
            buttonList[17].GetComponent<Button>().interactable = true;
            tempObject = buttonList[17].transform.Find("Image").gameObject;
            tempObject.SetActive(true);
            tempObject = buttonList[14].transform.Find("PopUp/Button_Confirm").gameObject;
            tempObject.SetActive(true);
            tempObject = buttonList[13].transform.Find("PopUp/Button_Confirm").gameObject;
            tempObject.SetActive(false);
            popUpList[13].SetActive(false);

            monsterPrefabStuff.multiplier += 0.1f;
        }
    }
    public void moneyButton2a() {
        currentButton = 15;
        openAndClose();
        lastButton = 15;
    }
    public void moneyButton2b() {
        cost = 1;
        if (ascensionCoinsHave >= cost)
        {
            moneyDamageUnlock1 = true;
            ascensionCoinsHave -= cost;
            StartCoroutine(buyAnimation(SliderList[27], buttonList[14]));
            tempObject = buttonList[15].transform.Find("PopUp/Button_Confirm").gameObject;
            tempObject.SetActive(true);
            buttonList[24].GetComponent<Image>().color = RedButton;
            buttonList[24].GetComponent<Button>().interactable = true;
            tempObject = buttonList[24].transform.Find("Image").gameObject;
            tempObject.SetActive(true);
            tempObject = SliderList[41].transform.Find("Background").gameObject;
            tempObject.GetComponent<Image>().color = RedSlider;
            tempObject.GetComponent<Image>().sprite = redSliderSprite;
            tempObject = buttonList[16].transform.Find("PopUp/Button_Confirm").gameObject;
            tempObject.SetActive(true);
            tempObject = buttonList[17].transform.Find("PopUp/Button_Confirm").gameObject;
            tempObject.SetActive(true);
            tempObject = buttonList[14].transform.Find("PopUp/Button_Confirm").gameObject;
            tempObject.SetActive(false);
            popUpList[14].SetActive(false);

            monsterPrefabStuff.multiplier += 0.15f;
        }
    }
    public void moneyButton3a() {
        currentButton = 16;
        openAndClose();
        lastButton = 16;
    }
    public void moneyButton3b() {
        cost = 1;
        if (ascensionCoinsHave >= cost)
        {
            ascensionCoinsHave -= cost;
            StartCoroutine(buyAnimation(SliderList[28], buttonList[15]));
            tempObject = buttonList[15].transform.Find("PopUp/Button_Confirm").gameObject;
            tempObject.SetActive(false);
            popUpList[15].SetActive(false);

            
            for (int i = 0; i < upgradesList.Count; i++)
            {
                buyItem = upgradesList[i].GetComponent<BuyItem>();
                buyItem.updateDiscount(-0.1f);
            }
            for (int i = 0; i < gearList.Count; i++)
            {
                buyItem = gearList[i].GetComponent<BuyItem>();
                buyItem.updateDiscount(-0.1f);
            }
        }
    }
    public void moneyButton4a() {
        currentButton = 17;
        openAndClose();
        lastButton = 17;
    }
    public void moneyButton4b() {
        cost = 1;
        if (ascensionCoinsHave >= cost)
        {
            ascensionCoinsHave -= cost;
            StartCoroutine(buyAnimation(SliderList[29], buttonList[16]));
            tempObject = buttonList[16].transform.Find("PopUp/Button_Confirm").gameObject;
            tempObject.SetActive(false);
            popUpList[16].SetActive(false);

            monsterPrefabStuff.multiplier += 0.2f;
        }
    }
    public void moneyButton5a() {
        currentButton = 18;
        openAndClose();
        lastButton = 18;
    }
    public void moneyButton5b() {
        cost = 1;
        if (ascensionCoinsHave >= cost)
        {
            ascensionCoinsHave -= cost;
            StartCoroutine(buyAnimation(SliderList[30], buttonList[17]));
            tempObject = buttonList[17].transform.Find("PopUp/Button_Confirm").gameObject;
            tempObject.SetActive(false);
            popUpList[17].SetActive(false);

            monsterPrefabStuff.multiplier += 0.25f;
            damageScript.changeASMulitplier(0.25f);
            gameManager.ASMultiplier += 0.25f;
        }
    }
    //DPS buttons
    public void DPSButton1a() {
        currentButton = 19;
        openAndClose();
        lastButton = 19;
    }
    public void DPSButton1b() {
        cost = 1;
        if (ascensionCoinsHave >= cost)
        {
            ascensionCoinsHave -= cost;
            StartCoroutine(buyAnimation(SliderList[32], buttonList[18]));
            tempObject = SliderList[34].transform.Find("Background").gameObject;
            tempObject.GetComponent<Image>().color = RedSlider;
            tempObject.GetComponent<Image>().sprite = redSliderSprite;
            buttonList[20].GetComponent<Image>().color = RedButton;
            buttonList[20].GetComponent<Button>().interactable = true;
            tempObject = buttonList[20].transform.Find("Image").gameObject;
            tempObject.SetActive(true);
            tempObject = buttonList[19].transform.Find("PopUp/Button_Confirm").gameObject;
            tempObject.SetActive(true);
            tempObject = buttonList[18].transform.Find("PopUp/Button_Confirm").gameObject;
            tempObject.SetActive(false);
            popUpList[18].SetActive(false);

            damageScript.changeASMulitplier(0.1f);
            gameManager.ASMultiplier += 0.1f;
        }
    }
    public void DPSButton2a() {
        currentButton = 20;
        openAndClose();
        lastButton = 20;
    }
    public void DPSButton2b() {
        cost = 1;
        if (ascensionCoinsHave >= cost)
        {
            ascensionCoinsHave -= cost;
            StartCoroutine(buyAnimation(SliderList[33], buttonList[19]));
            tempObject = SliderList[35].transform.Find("Background").gameObject;
            tempObject.GetComponent<Image>().color = RedSlider;
            tempObject.GetComponent<Image>().sprite = redSliderSprite;
            buttonList[21].GetComponent<Image>().color = RedButton;
            buttonList[21].GetComponent<Button>().interactable = true;
            tempObject = buttonList[21].transform.Find("Image").gameObject;
            tempObject.SetActive(true);
            tempObject = buttonList[20].transform.Find("PopUp/Button_Confirm").gameObject;
            tempObject.SetActive(true);
            tempObject = buttonList[19].transform.Find("PopUp/Button_Confirm").gameObject;
            tempObject.SetActive(false);
            popUpList[19].SetActive(false);

            damageScript.changeASMulitplier(0.20f);
            gameManager.ASMultiplier += 0.20f;
        }
    }
    public void DPSButton3a() {
        currentButton = 21;
        openAndClose();
        lastButton = 21;
    }
    public void DPSButton3b() {
        cost = 1;
        if (ascensionCoinsHave >= cost)
        {
            ascensionCoinsHave -= cost;
            StartCoroutine(buyAnimation(SliderList[34], buttonList[20]));
            tempObject = SliderList[36].transform.Find("Background").gameObject;
            tempObject.GetComponent<Image>().color = RedSlider;
            tempObject.GetComponent<Image>().sprite = redSliderSprite;
            tempObject = SliderList[37].transform.Find("Background").gameObject;
            tempObject.GetComponent<Image>().color = RedSlider;
            tempObject.GetComponent<Image>().sprite = redSliderSprite;
            buttonList[22].GetComponent<Image>().color = RedButton;
            buttonList[22].GetComponent<Button>().interactable = true;
            tempObject = buttonList[22].transform.Find("Image").gameObject;
            tempObject.SetActive(true);
            buttonList[39].GetComponent<Image>().color = RedButton;
            tempObject = buttonList[21].transform.Find("PopUp/Button_Confirm").gameObject;
            tempObject.SetActive(true);
            tempObject = buttonList[20].transform.Find("PopUp/Button_Confirm").gameObject;
            tempObject.SetActive(false);
            popUpList[20].SetActive(false);

            damageScript.changeASMulitplier(0.25f);
            gameManager.ASMultiplier += 0.25f;
        }
    }
    public void DPSButton4a() {
        currentButton = 22;
        openAndClose();
        lastButton = 22;
    }
    public void DPSButton4b() {
        cost = 1;
        if (ascensionCoinsHave >= cost)
        {
            moneyDamageUnlock2 = true;
            ascensionCoinsHave -= cost;
            StartCoroutine(buyAnimation(SliderList[35], buttonList[21]));
            tempObject = SliderList[38].transform.Find("Background").gameObject;
            tempObject.GetComponent<Image>().color = RedSlider;
            tempObject.GetComponent<Image>().sprite = redSliderSprite;
            buttonList[23].GetComponent<Image>().color = RedButton;
            buttonList[23].GetComponent<Button>().interactable = true;
            tempObject = buttonList[23].transform.Find("Image").gameObject;
            tempObject.SetActive(true);
            buttonList[24].GetComponent<Image>().color = RedButton;
            buttonList[24].GetComponent<Button>().interactable = true;
            tempObject = buttonList[24].transform.Find("Image").gameObject;
            tempObject.SetActive(true);
            tempObject = SliderList[41].transform.Find("Background").gameObject;
            tempObject.GetComponent<Image>().color = RedSlider;
            tempObject.GetComponent<Image>().sprite = redSliderSprite;
            tempObject = buttonList[22].transform.Find("PopUp/Button_Confirm").gameObject;
            tempObject.SetActive(true);
            tempObject = buttonList[21].transform.Find("PopUp/Button_Confirm").gameObject;
            tempObject.SetActive(false);
            popUpList[21].SetActive(false);

            damageScript.changeASMulitplier(0.50f);
            gameManager.ASMultiplier += 0.50f;
        }
    }
    public void DPSButton5a() {
        currentButton = 23;
        openAndClose();
        lastButton = 23;
    }
    public void DPSButton5b() {
        cost = 1;
        if (ascensionCoinsHave >= cost)
        {
            ascensionCoinsHave -= cost;
            StartCoroutine(buyAnimation(SliderList[37], buttonList[22]));
            tempObject = buttonList[23].transform.Find("PopUp/Button_Confirm").gameObject;
            tempObject.SetActive(true);
            tempObject = buttonList[22].transform.Find("PopUp/Button_Confirm").gameObject;
            tempObject.SetActive(false);
            popUpList[22].SetActive(false);

            damageScript.changeASMulitplier(1f);
            gameManager.ASMultiplier += 1f;
        }
    }
    public void DPSButton6a() {
        currentButton = 24;
        openAndClose();
        lastButton = 24;
    }
    public void DPSButton6b() {
        cost = 1;
        if (ascensionCoinsHave >= cost)
        {
            ascensionCoinsHave -= cost;
            StartCoroutine(buyAnimation(SliderList[38], buttonList[23]));
            tempObject = buttonList[23].transform.Find("PopUp/Button_Confirm").gameObject;
            tempObject.SetActive(false);
            popUpList[23].SetActive(false);

            damageScript.changeASMulitplier(2f);
            gameManager.ASMultiplier += 2f;
        }
    }
    public void DPSButton7a() {
        currentButton = 25;
        openAndClose();
        lastButton = 25;
        if (moneyDamageUnlock1 && moneyDamageUnlock2 && !openOnceMoneyDamage)
        {
            openOnceMoneyDamage = true;
            tempObject = buttonList[24].transform.Find("PopUp/Button_Confirm").gameObject;
            tempObject.SetActive(true);
        }
    }
    public void DPSButton7b() {
        cost = 1;
        if (ascensionCoinsHave >= cost)
        {
            ascensionCoinsHave -= cost;
            StartCoroutine(buyAnimation(SliderList[41], buttonList[24]));
            tempObject = buttonList[24].transform.Find("PopUp/Button_Confirm").gameObject;
            tempObject.SetActive(false);
            popUpList[24].SetActive(false);

            damageScript.changeASMulitplier(0.5f);
            gameManager.ASMultiplier += 0.5f;
            monsterPrefabStuff.multiplier += 0.5f;
        }
    }
    //crate buttons
    public void crateButton1a() {
        currentButton = 26;
        openAndClose();
        lastButton = 26;
    }
    public void crateButton1b() {
        cost = 1;
        if (ascensionCoinsHave >= cost)
        {
            ascensionCoinsHave -= cost;
            StartCoroutine(buyAnimation(SliderList[0], buttonList[25]));
            tempObject = SliderList[2].transform.Find("Background").gameObject;
            tempObject.GetComponent<Image>().color = RedSlider;
            tempObject.GetComponent<Image>().sprite = redSliderSprite;
            buttonList[27].GetComponent<Image>().color = RedButton;
            buttonList[27].GetComponent<Button>().interactable = true;
            tempObject = buttonList[27].transform.Find("Image").gameObject;
            tempObject.SetActive(true);
            tempObject = buttonList[26].transform.Find("PopUp/Button_Confirm").gameObject;
            tempObject.SetActive(true);
            tempObject = buttonList[25].transform.Find("PopUp/Button_Confirm").gameObject;
            tempObject.SetActive(false);
            popUpList[25].SetActive(false);

            buyItemCrate.upCrateChance(0.01f);
        }
    }
    public void crateButton2a() {
        currentButton = 27;
        openAndClose();
        lastButton = 27;
    }
    public void crateButton2b() {
        cost = 1;
        if (ascensionCoinsHave >= cost)
        {
            ascensionCoinsHave -= cost;
            StartCoroutine(buyAnimation(SliderList[1], buttonList[26]));
            tempObject = SliderList[3].transform.Find("Background").gameObject;
            tempObject.GetComponent<Image>().color = RedSlider;
            tempObject.GetComponent<Image>().sprite = redSliderSprite;
            buttonList[28].GetComponent<Image>().color = RedButton;
            buttonList[28].GetComponent<Button>().interactable = true;
            tempObject = buttonList[28].transform.Find("Image").gameObject;
            tempObject.SetActive(true);
            tempObject = buttonList[27].transform.Find("PopUp/Button_Confirm").gameObject;
            tempObject.SetActive(true);
            tempObject = buttonList[26].transform.Find("PopUp/Button_Confirm").gameObject;
            tempObject.SetActive(false);
            popUpList[26].SetActive(false);

            buyItemCrate.upCrateChance(0.01f);
        }
    }
    public void crateButton3a() {
        currentButton = 28;
        openAndClose();
        lastButton = 28;
    }
    public void crateButton3b() {
        cost = 1;
        if (ascensionCoinsHave >= cost)
        {
            ascensionCoinsHave -= cost;
            StartCoroutine(buyAnimation(SliderList[2], buttonList[27]));
            tempObject = SliderList[4].transform.Find("Background").gameObject;
            tempObject.GetComponent<Image>().color = RedSlider;
            tempObject.GetComponent<Image>().sprite = redSliderSprite;
            buttonList[29].GetComponent<Image>().color = RedButton;
            buttonList[29].GetComponent<Button>().interactable = true;
            tempObject = buttonList[29].transform.Find("Image").gameObject;
            tempObject.SetActive(true);
            tempObject = buttonList[28].transform.Find("PopUp/Button_Confirm").gameObject;
            tempObject.SetActive(true);
            tempObject = buttonList[27].transform.Find("PopUp/Button_Confirm").gameObject;
            tempObject.SetActive(false);
            popUpList[27].SetActive(false);

            buyItemCrate.upCrateChance(0.01f);
        }
    }
    public void crateButton4a() {
        currentButton = 29;
        openAndClose();
        lastButton = 29;
    }
    public void crateButton4b() {
        cost = 1;
        if (ascensionCoinsHave >= cost)
        {
            ascensionCoinsHave -= cost;
            StartCoroutine(buyAnimation(SliderList[3], buttonList[28]));
            tempObject = SliderList[5].transform.Find("Background").gameObject;
            tempObject.GetComponent<Image>().color = RedSlider;
            tempObject.GetComponent<Image>().sprite = redSliderSprite;
            buttonList[30].GetComponent<Image>().color = RedButton;
            buttonList[30].GetComponent<Button>().interactable = true;
            tempObject = buttonList[30].transform.Find("Image").gameObject;
            tempObject.SetActive(true);
            tempObject = buttonList[29].transform.Find("PopUp/Button_Confirm").gameObject;
            tempObject.SetActive(true);
            tempObject = buttonList[28].transform.Find("PopUp/Button_Confirm").gameObject;
            tempObject.SetActive(false);
            popUpList[28].SetActive(false);

            buyItemCrate.upCrateChance(0.02f);
        }
    }
    public void crateButton5a() {
        currentButton = 30;
        openAndClose();
        lastButton = 30;
    }
    public void crateButton5b() {
        cost = 1;
        if (ascensionCoinsHave >= cost)
        {
            ascensionCoinsHave -= cost;
            StartCoroutine(buyAnimation(SliderList[4], buttonList[29]));
            tempObject = SliderList[6].transform.Find("Background").gameObject;
            tempObject.GetComponent<Image>().color = RedSlider;
            tempObject.GetComponent<Image>().sprite = redSliderSprite;
            tempObject = SliderList[9].transform.Find("Background").gameObject;
            tempObject.GetComponent<Image>().color = RedSlider;
            tempObject.GetComponent<Image>().sprite = redSliderSprite;
            buttonList[31].GetComponent<Image>().color = RedButton;
            buttonList[31].GetComponent<Button>().interactable = true;
            tempObject = buttonList[31].transform.Find("Image").gameObject;
            tempObject.SetActive(true);
            buttonList[34].GetComponent<Image>().color = RedButton;
            buttonList[34].GetComponent<Button>().interactable = true;
            tempObject = buttonList[34].transform.Find("Image").gameObject;
            tempObject.SetActive(true);
            tempObject = buttonList[30].transform.Find("PopUp/Button_Confirm").gameObject;
            tempObject.SetActive(true);
            tempObject = buttonList[29].transform.Find("PopUp/Button_Confirm").gameObject;
            tempObject.SetActive(false);
            popUpList[29].SetActive(false);

            buyItemCrate.upCrateChance(0.02f);
        }
    }
    public void crateButton6a() {
        currentButton = 31;
        openAndClose();
        lastButton = 31;
    }
    public void crateButton6b() {
        cost = 1;
        if (ascensionCoinsHave >= cost)
        {
            ascensionCoinsHave -= cost;
            StartCoroutine(buyAnimation(SliderList[5], buttonList[30]));
            tempObject = SliderList[7].transform.Find("Background").gameObject;
            tempObject.GetComponent<Image>().color = RedSlider;
            tempObject.GetComponent<Image>().sprite = redSliderSprite;
            tempObject = SliderList[8].transform.Find("Background").gameObject;
            tempObject.GetComponent<Image>().color = RedSlider;
            tempObject.GetComponent<Image>().sprite = redSliderSprite;
            tempObject = SliderList[10].transform.Find("Background").gameObject;
            tempObject.GetComponent<Image>().color = RedSlider;
            tempObject.GetComponent<Image>().sprite = redSliderSprite;
            buttonList[32].GetComponent<Image>().color = RedButton;
            buttonList[32].GetComponent<Button>().interactable = true;
            tempObject = buttonList[32].transform.Find("Image").gameObject;
            tempObject.SetActive(true);
            buttonList[33].GetComponent<Image>().color = RedButton;
            buttonList[33].GetComponent<Button>().interactable = true;
            tempObject = buttonList[33].transform.Find("Image").gameObject;
            tempObject.SetActive(true);
            buttonList[35].GetComponent<Image>().color = RedButton;
            buttonList[35].GetComponent<Button>().interactable = true;
            tempObject = buttonList[35].transform.Find("Image").gameObject;
            tempObject.SetActive(true);
            tempObject = buttonList[31].transform.Find("PopUp/Button_Confirm").gameObject;
            tempObject.SetActive(true);
            tempObject = buttonList[34].transform.Find("PopUp/Button_Confirm").gameObject;
            tempObject.SetActive(true);
            tempObject = buttonList[30].transform.Find("PopUp/Button_Confirm").gameObject;
            tempObject.SetActive(false);
            popUpList[30].SetActive(false);

            buyItemCrate.upCrateChance(0.02f);
        }
    }
    public void crateButton7a() {
        currentButton = 32;
        openAndClose();
        lastButton = 32;
    }
    public void crateButton7b() {
        cost = 1;
        if (ascensionCoinsHave >= cost)
        {
            ascensionCoinsHave -= cost;
            StartCoroutine(buyAnimation(SliderList[6], buttonList[31]));
            tempObject = buttonList[32].transform.Find("PopUp/Button_Confirm").gameObject;
            tempObject.SetActive(true);
            tempObject = buttonList[33].transform.Find("PopUp/Button_Confirm").gameObject;
            tempObject.SetActive(true);
            tempObject = buttonList[31].transform.Find("PopUp/Button_Confirm").gameObject;
            tempObject.SetActive(false);
            popUpList[31].SetActive(false);

            buyItemCrate.upCrateChance(0.03f);
        }
    }
    public void crateButton8a() {
        currentButton = 33;
        openAndClose();
        lastButton = 33;
    }
    public void crateButton8b() {
        cost = 1;
        if (ascensionCoinsHave >= cost)
        {
            ascensionCoinsHave -= cost;
            StartCoroutine(buyAnimation(SliderList[7], buttonList[32]));
            tempObject = buttonList[32].transform.Find("PopUp/Button_Confirm").gameObject;
            tempObject.SetActive(false);
            popUpList[32].SetActive(false);

            gameManager.crate += 1;
            gameManager.crateMax += 1;
        }
    }
    public void crateButton9a() {
        currentButton = 34;
        openAndClose();
        lastButton = 34;
    }
    public void crateButton9b() {
        cost = 1;
        if (ascensionCoinsHave >= cost)
        {
            ascensionCoinsHave -= cost;
            StartCoroutine(buyAnimation(SliderList[8], buttonList[33]));
            tempObject = buttonList[33].transform.Find("PopUp/Button_Confirm").gameObject;
            tempObject.SetActive(false);
            popUpList[33].SetActive(false);

            gameManager.crate += 1;
            gameManager.crateMax += 1;
        }
    }
    public void crateButton10a() {
        currentButton = 35;
        openAndClose();
        lastButton = 35;
    }
    public void crateButton10b() {
        cost = 1;
        if (ascensionCoinsHave >= cost)
        {
            ascensionCoinsHave -= cost;
            StartCoroutine(buyAnimation(SliderList[9], buttonList[34]));
            tempObject = buttonList[35].transform.Find("PopUp/Button_Confirm").gameObject;
            tempObject.SetActive(true);
            tempObject = buttonList[34].transform.Find("PopUp/Button_Confirm").gameObject;
            tempObject.SetActive(false);
            popUpList[34].SetActive(false);

            buyItemCrate.upCrateChance(0.05f);
        }
    }
    public void crateButton11a() {
        currentButton = 36;
        openAndClose();
        lastButton = 36;
    }
    public void crateButton11b() {
        cost = 1;
        if (ascensionCoinsHave >= cost)
        {
            ascensionCoinsHave -= cost;
            StartCoroutine(buyAnimation(SliderList[10], buttonList[35]));
            tempObject = buttonList[35].transform.Find("PopUp/Button_Confirm").gameObject;
            tempObject.SetActive(false);
            popUpList[35].SetActive(false);

            gameManager.movesNeeded = 1;
        }
    }
   
 
}

