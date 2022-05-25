using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IAPManager : MonoBehaviour
{
    public AdManager ads;
    public Gems gems;

    public GameObject prefab;

    public Transform startPoint;
    public Transform endPoint;

    public Transform parent;

    public void removeAds()
    {
        Debug.Log("RemoveAds");
        ads.showAds = false;
        StartCoroutine(success());
    }

    public void BuyGems1()
    {
        Debug.Log("BuyGems1");
        gems.addGems(50);
        StartCoroutine(success());
    }

    public void BuyGems2()
    {
        Debug.Log("BuyGems2");
        gems.addGems(150);
        StartCoroutine(success());
    }

    public void BuyGems3()
    {
        Debug.Log("BuyGems3");
        gems.addGems(500);
        StartCoroutine(success());
    }

    public void BuyGems4()
    {
        Debug.Log("BuyGems4");
        gems.addGems(1100);
        StartCoroutine(success());
    }

    public void BuyGems5()
    {
        Debug.Log("BuyGems5");
        gems.addGems(2000);
        StartCoroutine(success());
    }

    private IEnumerator success()
    {
        var banner = Instantiate(prefab, startPoint.position, Quaternion.identity, parent);
        var script = banner.GetComponent<PopUp>();

        script.startPoint = startPoint;
        script.endPoint = endPoint;


        script.Init("Success", true);
        yield return 0;
    }

    public void fail()
    {
        StartCoroutine(failCo());
    }

    private IEnumerator failCo()
    {
        var banner = Instantiate(prefab, startPoint.position, Quaternion.identity, parent);
        var script = banner.GetComponent<PopUp>();

        script.startPoint = startPoint;
        script.endPoint = endPoint;

        script.Init("Failed", false);
        yield return 0;
    }
}
