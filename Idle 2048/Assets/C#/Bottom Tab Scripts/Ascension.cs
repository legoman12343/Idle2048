using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Security.Cryptography;
using TMPro;

public class Ascension : MonoBehaviour
{

    [SerializeField] public List<GameObject> popUpList;
    [SerializeField] public List<Image> buttonList;
    private Color32 Green = new Color32(26, 210, 11, 255);
    private Color32 RedButton = new Color32(138, 28, 28, 255);
    private Color32 RedSlider = new Color32(185, 55, 34, 255);
    private Color32 Grey = new Color32(12, 17, 17, 255);
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

    //ascension buttons
    public void openAscensionPopUp()
    {
        currentButton = 37;
        openAndClose();
        lastButton = 37;
        string ascensionCoinsToGetString = FormatNumber(ascensionCoinsToGet);
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
                tempObject = SliderList[12].transform.Find("Background").gameObject;
                tempObject.GetComponent<Image>().color = RedSlider;
                tempObject = SliderList[18].transform.Find("Background").gameObject;
                tempObject.GetComponent<Image>().color = RedSlider;
                tempObject = SliderList[27].transform.Find("Background").gameObject;
                tempObject.GetComponent<Image>().color = RedSlider;
                tempObject = SliderList[33].transform.Find("Background").gameObject;
                tempObject.GetComponent<Image>().color = RedSlider;
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
        if (num >= 100000000)
        {
            return (num / 1000000D).ToString("0.#M");
        }
        if (num >= 1000000)
        {
            return (num / 1000000D).ToString("0.##M");
        }
        if (num >= 100000)
        {
            return (num / 1000D).ToString("0.#k");
        }
        if (num >= 10000)
        {
            return (num / 1000D).ToString("0.##k");
        }
        if (num >= 1000)
        {
            return num.ToString("#,0");
        }
        return num.ToString("0.#");
    }

    private IEnumerator buyAnimation(Slider _slider, Image _button)
    {
        while (_slider.value < 1)
        {
            _slider.value += 0.01f;
            yield return new WaitForSeconds(0.0001f);
        }
        _button.color = Green;
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
            tempObject = SliderList[21].transform.Find("Background").gameObject;
            tempObject.GetComponent<Image>().color = RedSlider;
            tempObject = SliderList[13].transform.Find("Background").gameObject;
            tempObject.GetComponent<Image>().color = RedSlider;
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
        }
    }
    public void tileButton2a() {
        currentButton = 2;
        openAndClose();
        lastButton = 2;
    }
    public void tileButton2b() {

    }
    public void tileButton3a() {
        currentButton = 3;
        openAndClose();
        lastButton = 3;
    }
    public void tileButton3b() {

    }
    public void tileButton4a() {
        currentButton = 4;
        openAndClose();
        lastButton = 4;
    }
    public void tileButton4b() {

    }
    public void tileButton5a() {
        currentButton = 5;
        openAndClose();
        lastButton = 5;
    }
    public void tileButton5b() {

    }
    public void tileButton6a() {
        currentButton = 6;
        openAndClose();
        lastButton = 6;
    }
    public void tileButton6b() {

    }
    public void tileButton7a() {
        currentButton = 7;
        openAndClose();
        lastButton = 7;
    }
    public void tileButton7b() {

    }
    public void tileButton8a() {
        currentButton = 8;
        openAndClose();
        lastButton = 8;
    }
    public void tileButton8b() {

    }
    public void tileButton9a() {
        currentButton = 9;
        openAndClose();
        lastButton = 9;
    }
    public void tileButton9b() {
   
    }
    public void tileButton10a() {
        currentButton = 10;
        openAndClose();
        lastButton = 10;
    }
    public void tileButton10b() {
     
    }
    public void tileButton11a() {
        currentButton = 11;
        openAndClose();
        lastButton = 11;
    }
    public void tileButton11b() {
  
    }
    public void tileButton12a() {
        currentButton = 12;
        openAndClose();
        lastButton = 12;
    }
    public void tileButton12b() {
 
    }
    public void tileButton13a() {
        currentButton = 13;
        openAndClose();
        lastButton = 13;
    }
    public void tileButton13b() {

    }
    //money buttons
    public void moneyButton1a() {
        currentButton = 14;
        openAndClose();
        lastButton = 14;
    }
    public void moneyButton1b() {

    }
    public void moneyButton2a() {
        currentButton = 15;
        openAndClose();
        lastButton = 15;
    }
    public void moneyButton2b() {

    }
    public void moneyButton3a() {
        currentButton = 16;
        openAndClose();
        lastButton = 16;
    }
    public void moneyButton3b() {

    }
    public void moneyButton4a() {
        currentButton = 17;
        openAndClose();
        lastButton = 17;
    }
    public void moneyButton4b() {
        
    }
    public void moneyButton5a() {
        currentButton = 18;
        openAndClose();
        lastButton = 18;
    }
    public void moneyButton5b() {

    }
    //DPS buttons
    public void DPSButton1a() {
        currentButton = 19;
        openAndClose();
        lastButton = 19;
    }
    public void DPSButton1b() {

    }
    public void DPSButton2a() {
        currentButton = 20;
        openAndClose();
        lastButton = 20;
    }
    public void DPSButton2b() {
   
    }
    public void DPSButton3a() {
        currentButton = 21;
        openAndClose();
        lastButton = 21;
    }
    public void DPSButton3b() {

    }
    public void DPSButton4a() {
        currentButton = 22;
        openAndClose();
        lastButton = 22;
    }
    public void DPSButton4b() {

    }
    public void DPSButton5a() {
        currentButton = 23;
        openAndClose();
        lastButton = 23;
    }
    public void DPSButton5b() {

    }
    public void DPSButton6a() {
        currentButton = 24;
        openAndClose();
        lastButton = 24;
    }
    public void DPSButton6b() {

    }
    public void DPSButton7a() {
        currentButton = 25;
        openAndClose();
        lastButton = 25;
    }
    public void DPSButton7b() {

    }
    //crate buttons
    public void crateButton1a() {
        currentButton = 26;
        openAndClose();
        lastButton = 26;
    }
    public void crateButton1b() {

    }
    public void crateButton2a() {
        currentButton = 27;
        openAndClose();
        lastButton = 27;
    }
    public void crateButton2b() {

    }
    public void crateButton3a() {
        currentButton = 28;
        openAndClose();
        lastButton = 28;
    }
    public void crateButton3b() {

    }
    public void crateButton4a() {
        currentButton = 29;
        openAndClose();
        lastButton = 29;
    }
    public void crateButton4b() {

    }
    public void crateButton5a() {
        currentButton = 30;
        openAndClose();
        lastButton = 30;
    }
    public void crateButton5b() {
 
    }
    public void crateButton6a() {
        currentButton = 31;
        openAndClose();
        lastButton = 31;
    }
    public void crateButton6b() { 
    
    }
    public void crateButton7a() {
        currentButton = 32;
        openAndClose();
        lastButton = 32;
    }
    public void crateButton7b() { 
    
    }
    public void crateButton8a() {
        currentButton = 33;
        openAndClose();
        lastButton = 33;
    }
    public void crateButton8b() { 
    
    }
    public void crateButton9a() {
        currentButton = 34;
        openAndClose();
        lastButton = 34;
    }
    public void crateButton9b() { 
    
    }
    public void crateButton10a() {
        currentButton = 35;
        openAndClose();
        lastButton = 35;
    }
    public void crateButton10b() { 
    
    }
    public void crateButton11a() {
        currentButton = 36;
        openAndClose();
        lastButton = 36;
    }
    public void crateButton11b() { 
    
    }
   
 
}

