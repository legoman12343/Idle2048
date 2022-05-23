using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using LootLocker.Requests;
using TMPro;
using System.Numerics;

public class LeaderboardController : MonoBehaviour
{
    public string MemberID;
    public Damage damage;
    public int ID;
    int MaxScores = 15;
    [SerializeField] private List<Text> Rank;
    [SerializeField] private List<Text> Name;
    [SerializeField] private List<Text> Value;
    [SerializeField] private List<Text> RankYou;
    [SerializeField] private List<Text> NameYou;
    [SerializeField] private List<Text> ValueYou;
    public TMP_InputField playerNameInput;
    public GameObject leaderboardWindow;
    private bool menu = false;
    public Sprite selected;
    public Sprite notSelected;
    public GameObject you;
    public GameObject top;
    public Image topImg;
    public Image youImg;
    public FormatNumber fn;

    // Start is called before the first frame update
    private void Start()
    {
        you.SetActive(false);
        top.SetActive(false);
        leaderboardWindow.SetActive(false);
        LootLockerSDKManager.StartGuestSession((response) =>
        {
            if (response.success)
            {
                Debug.Log("LL Success");
                PlayerPrefs.SetString("PlayerID", response.player_id.ToString());
                MemberID = response.player_id.ToString();
            }
            else
            {
                Debug.Log("LL Failed");
            }
        });

        InvokeRepeating("SubmitScore", 1f, 30f);
    }

    public void SetPlayerName()
    {
        LootLockerSDKManager.SetPlayerName(playerNameInput.text, (response) =>
         {
             if (response.success)
             {
                 Debug.Log("Name Success");
             }
             else
             {
                 Debug.Log("Name Failed");
             }
         });

    }


    public void open()
    {
        leaderboardWindow.SetActive(true);
        if(!menu)
        {
            you.SetActive(false);
            top.SetActive(true);
            ShowScoresTop();
        }
        else
        {
            you.SetActive(true);
            top.SetActive(false);
            ShowScoresYou();
        }
        
    }

    public void close()
    {
        leaderboardWindow.SetActive(false);
    }



    public void ShowScoresTop()
    {
        LootLockerSDKManager.GetScoreList(ID, MaxScores, (response) =>
          {
              if (response.success)
              {
                  LootLockerLeaderboardMember[] scores = response.items;
                  for (int i = 0; i < scores.Length; i++)
                  {
                      if(scores[i].player.name == "")
                          Name[i].text = (scores[i].player.id).ToString();
                      else
                          Name[i].text = (scores[i].player.name).ToString();

                      Rank[i].text = (scores[i].rank).ToString();                      
                      Value[i].text = (scores[i].score).ToString();
                  }

                  if (scores.Length < MaxScores)
                  {
                      for (int i = scores.Length; i < MaxScores; i++)
                      {
                          Rank[i].text = (i + 1).ToString();
                          Name[i].text = "None";
                          Value[i].text = "None";
                      }
                  }
              }
          });
        
    }


    public void ShowScoresYou()
    {
        LootLockerSDKManager.GetMemberRank(ID.ToString(), MemberID, (response) =>
        {
            if (response.success)
            {
                int rank = response.rank;
                int count = 15;
                int after = rank < 11 ? 0 : rank - 5;

                LootLockerSDKManager.GetScoreListMain(ID, count, after, (response) =>
                {
                    if (response.success)
                    {
                        LootLockerLeaderboardMember[] scores = response.items;
                        for (int i = 0; i < scores.Length; i++)
                        {
                            if (scores[i].player.name == "")
                                NameYou[i].text = (scores[i].player.id).ToString();
                            else
                                NameYou[i].text = (scores[i].player.name).ToString();

                            RankYou[i].text = (scores[i].rank).ToString();
                            ValueYou[i].text = (scores[i].score).ToString();
                        }

                        if (scores.Length < MaxScores)
                        {
                            for (int i = scores.Length; i < MaxScores; i++)
                            {
                                RankYou[i].text = (i + 1).ToString();
                                NameYou[i].text = "None";
                                ValueYou[i].text = "None";
                            }
                        }
                    }
                    else
                    {
                        Debug.Log("failed: " + response.Error);
                    }
                });
            }
            else
            {
                Debug.Log("failed: " + response.Error);
            }
        });

    }




    public void SubmitScore()
    {
        /*
        BigInteger score = damage.getDPS();
        LootLockerSDKManager.GetMemberRank(ID.ToString(), PlayerPrefs.GetString("PlayerID"), (response) =>
        {
            if (response.score < score && response.success)
            {
                LootLockerSDKManager.SubmitScore(PlayerPrefs.GetString("PlayerID"), fn.formatNumberBigNumber(score), ID, (response) =>
                {
                    if (response.success)
                    {
                        Debug.Log("SCORE Success");
                    }
                    else
                    {
                        Debug.Log("SCORE Failed");
                    }
                });
            }
        });   */     
    }


    public void openYou()
    {
        if (!menu)
        {
            menu = true;
            you.SetActive(true);
            top.SetActive(false);
            topImg.sprite = notSelected;
            youImg.sprite = selected;
            ShowScoresYou();
        }
    }

    public void openTop()
    {
        if (menu)
        {
            menu = false;
            you.SetActive(false);
            top.SetActive(true);
            topImg.sprite = selected;
            youImg.sprite = notSelected;
            ShowScoresTop();
        }
    }
}
