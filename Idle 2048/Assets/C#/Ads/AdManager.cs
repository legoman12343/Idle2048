using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Advertisements;

public class AdManager : MonoBehaviour, IUnityAdsListener
{
    public GameManager gm;
    public Gems gems;
    public bool crate;
    public bool gem;
    public bool offline;
    public GameObject crateAdButton;
    public GameObject gemAdButton;
    private bool adReady;
    private float gemTimer;
    public OfflineDaily od;


#if UNITY_IOS
    string ID = "4747990";
    string rewardAd = "Rewarded_iOS";
#else
    string ID = "4747991";
    string rewardAd = "Rewarded_Android";
#endif


    void Start()
    {
        Advertisement.Initialize(ID);
        Advertisement.AddListener(this);
        gem = false;
        crate = false;
        crateAdButton.SetActive(false);
        gemAdButton.SetActive(false);
        adReady = false;
        gemTimer = 180f;
    }

    public void PlayCrateAd()
    {
        if (Advertisement.IsReady(rewardAd))
        {
            adReady = false;
            Advertisement.Show(rewardAd);
            crate = true;
        }
    }


    public void PlayGemAd()
    {
        if (Advertisement.IsReady(rewardAd))
        {
            Advertisement.Show(rewardAd);
            gem = true;
        }
        else
            Debug.Log("Ad not ready");
    }
    
    public void PlayOfflineAd()
    {
        if (Advertisement.IsReady(rewardAd))
        {
            Advertisement.Show(rewardAd);
            offline = true;
        }
        else
            Debug.Log("Ad not ready");
    } 

    public void OnUnityAdsReady(string placementID)
    {
        adReady = true;
    }

    public void OnUnityAdsDidError(string message)
    {
        Debug.Log("ERROR");
    }

    public void OnUnityAdsDidStart(string placementID)
    {
        Debug.Log("VideoStarted");
    }

    public void OnUnityAdsDidFinish(string placementID, ShowResult showResult)
    {
        if (placementID == rewardAd && showResult == ShowResult.Finished)
        {
            if (crate)
            {
                gm.silverCrateCount += 3;
                crate = false;
                StartCoroutine(showCrateAd());
            }
            else if (gem)
            {
                gems.addGems(5);
                gem = false;
            }
            else if(offline)
            {
                offline = false;
                od.claimEarningsVideo();                
            }
        }
    }

    public IEnumerator showCrateAd()
    {
        while(true)
        {
            yield return new WaitForSeconds(500f);
            if (gm.silverCrateCount == 0 && gm.crateChance > 0.0 && adReady)
            {
                crateAdButton.SetActive(true);
                yield break;
            }

        }
    }

    public IEnumerator showGemAd()
    {
        while (true)
        {
            yield return new WaitForSeconds(gemTimer);
            if (adReady)
            {
                gemTimer = 900f;
                gemAdButton.SetActive(true);
                yield break;
            }

        }
    }

}
