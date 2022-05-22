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
    public bool showAds;


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
        showAds = true;
    }

    public void PlayCrateAd()
    {
        if (showAds)
        {
            if (Advertisement.IsReady(rewardAd))
            {
                adReady = false;
                Advertisement.Show(rewardAd);
                crate = true;
            }
        }
        else 
        {
            crate = true;
            claimAdReward();
        }

    }


    public void PlayGemAd()
    {
        if (showAds)
        {
            if (Advertisement.IsReady(rewardAd))
            {
                Advertisement.Show(rewardAd);
                gem = true;
            }
        }
        else
        {
            gem = true;
            claimAdReward();
        }
    }
    
    public void PlayOfflineAd()
    {
        if (showAds)
        {
            if (Advertisement.IsReady(rewardAd))
            {
                Advertisement.Show(rewardAd);
                offline = true;
            }
            else
            {
                Debug.Log("Ad not ready");
            }
        }
        else
        {
            offline = true;
            claimAdReward();
        }
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
            claimAdReward();
        }
    }

    private void claimAdReward()
    {
        if (crate)
        {
            gm.silverCrateCount += 3;
            crate = false;
            crateAdButton.SetActive(false);
            StartCoroutine(showCrateAd());
        }
        else if (gem)
        {
            gems.addGems(5);
            gem = false;
            gemAdButton.SetActive(false);
        }
        else if (offline)
        {
            offline = false;
            od.claimEarningsVideo();
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
