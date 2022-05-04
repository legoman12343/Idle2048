using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopButtonPopUp : MonoBehaviour
{
    public GameObject ShopTab;
    bool activeShopTab;

    void Start()
    {
        activeShopTab = false;
    }

    public void OpenShopTab()
    {
        if (activeShopTab == false)
        {
            ShopTab.SetActive(true);
            activeShopTab = true;
        }
        else
        {
            ShopTab.SetActive(false);
            activeShopTab = false;
        }
    }
}
