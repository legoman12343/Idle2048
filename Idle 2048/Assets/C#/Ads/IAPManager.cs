using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IAPManager : MonoBehaviour
{
    public AdManager ads;
    public Gems gems;

    public void removeAds()
    {
        Debug.Log("RemoveAds");
        ads.showAds = false;
    }

    public void BuyGems1()
    {
        Debug.Log("BuyGems1");
        gems.addGems(50);
    }

    public void BuyGems2()
    {
        Debug.Log("BuyGems2");
        gems.addGems(150);
    }

    public void BuyGems3()
    {
        Debug.Log("BuyGems3");
        gems.addGems(500);
    }

    public void BuyGems4()
    {
        Debug.Log("BuyGems4");
        gems.addGems(1100);
    }
}
