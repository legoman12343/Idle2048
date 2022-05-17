using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class OfflineDaily : MonoBehaviour
{
	private DateTime oldtime;
	public LevelController level;
	public Damage damage;
	public AdManager ads;
	public int money;
	public CoinsDisplay moneyScript;
	public float multiplier;
	public GameObject offlineWindow;
	public Sprite greyButton;
	public GameObject doubleButton;
	public GameObject dailyTab;
	public GameObject dailyWindow;
	public GameObject offlineScaleWindow;
	public GameObject dailyClaimButton;
	public GameObject dailyAlertButton;
	public Text wang;
	[SerializeField] private List<Rewards> rewards;
	[SerializeField] private List<RectTransform> positions;
	public GameManager gm;
	private Vector3 windowScale;
	public NotificationAnimation dailyAnimation;

	void Start()
	{
		windowScale = new Vector3(1f, 2.17875f, 1f);
		dailyAlertButton.SetActive(true);
		offlineWindow.SetActive(true);
		oldtime = DateTime.Now;
		multiplier = 0.2f;
		offlineEarnings();
		InvokeRepeating("CheckDailyReward", 0f, 2f);
		StartCoroutine(initAnimation());
	}

	IEnumerator initAnimation()
	{
		bool c = false;
		while (!c)
		{
			yield return new WaitForSeconds(0.5f);
			Debug.Log("DSFAFGAGADFVESRTG");
			c = dailyAnimation.startAnimation();
			
		}
	}
	




	//dailyreward
	
	void CheckDailyReward()
	{
		int nextDay;
		if (WorldTimeAPI.Instance.IsTimeLodaed)
		{
			DateTime currentDateTime = WorldTimeAPI.Instance.GetCurrentDateTime();

			int dayOFYear = oldtime.DayOfYear;

			if (dayOFYear == 365 && DateTime.IsLeapYear(currentDateTime.Year) == false || dayOFYear == 366)
			{
				nextDay = 1;
			}
			else
			{
				nextDay = oldtime.DayOfYear + 1;
			}

			if (nextDay == currentDateTime.DayOfYear)
			{
				dailyAlertButton.SetActive(true);
				dailyAnimation.startAnimation();
				dailyClaimButton.SetActive(true);
			}
		}
	}
	
	public IEnumerator offlineEarnings()
	{
		bool completed = false;
		while (!completed)
		{
			yield return new WaitForSeconds(0.1f);
			if (WorldTimeAPI.Instance.IsTimeLodaed)
			{/*
				DateTime currentDateTime = WorldTimeAPI.Instance.GetCurrentDateTime();
				completed = true;
				float ttk = (float)level.getMonsterHealth() / (float)damage.getDPS();
				var difference = currentDateTime - oldtime;
				float seconds = (float)difference.TotalSeconds;
				int kills = (int)Math.Ceiling(seconds / ttk);
				money = (int)Math.Ceiling(kills * level.getMonsterCoins() * multiplier); */
				money = 1000;
				wang.text = money.ToString();
				completed = true;
			}
		}
	}

	public void claimEarnings()
	{
		moneyScript.Coins += money;
		money = 0;
		LeanTween.scale(offlineScaleWindow, Vector2.zero, 0.2f).setOnComplete(deactivateOffline);
	}

	public void deactivateOffline()
	{
		offlineScaleWindow.SetActive(false);
	}

	public void claimEarningsVideo()
	{
		money *= 2;
		doubleButton.GetComponent<Image>().sprite = greyButton;
		doubleButton.GetComponent<Button>().interactable = false;
	}

	public void claimDailyRewardFunc()
	{
		dailyAlertButton.SetActive(false);
		dailyAnimation.stopAnimation();
		Rewards reward = rewards[0];
		switch (reward.Type)
		{
			case RewardType.Gems:
				{
					gm.gems.addGems((int)Math.Ceiling(reward.Multiplier * 5f));
					reward.Multiplier *= 1.5f;
					break;
				}
			case RewardType.TimeSkip:
				{
					int money = (int)Math.Ceiling(reward.Multiplier * (damage.getDPS() / level.getMonsterHealth()) * 60 * level.getMonsterCoins());
					moneyScript.addCoins(money);
					reward.Multiplier *= 1.5f;
					break;
				}
			case RewardType.DPSboost:
				{
					StartCoroutine(gm.DPSMultiplier(60f * reward.Multiplier));
					reward.Multiplier *= 1.5f;
					break;
				}
			case RewardType.SilverCrates:
				{
					gm.silverCrateCount += (int)Math.Ceiling(reward.Multiplier);
					reward.Multiplier *= 1.5f;
					break;
				}
			case RewardType.MergeDamage:
				{
					StartCoroutine(mergeDamage(reward.Multiplier * 60f));
					reward.Multiplier *= 1.5f;
					break;
				}
			case RewardType.TileValue:
				{
					StartCoroutine(baseTileIncrease(reward.Multiplier * 60f));
					reward.Multiplier *= 1.5f;
					break;
				}
			case RewardType.CoinBoost:
				{
					StartCoroutine(gm.coinMultiplier(reward.Multiplier * 10f));
					reward.Multiplier *= 1.5f;
					break;
				}
			case RewardType.TileSpeed:
				{
					StartCoroutine(tileSpeed(reward.Multiplier * 5f));
					reward.Multiplier *= 1.5f;
					break;
				}
			case RewardType.Ascension:
				{
					Debug.Log("Quick Ascension");
					break;
				}
		}
		dailyClaimButton.SetActive(false);
		rewards.RemoveAt(0);
		rewards.Insert(rewards.Count, reward);
		Vector3 pos = positions[positions.Count - 1].anchoredPosition;
		Vector3 lastPos;
		for (int i = 0; i < positions.Count; i++)
		{
			lastPos = positions[i].anchoredPosition;
			positions[i].anchoredPosition = pos;
			pos = lastPos;
		}

	}

	private IEnumerator mergeDamage(float time)
	{
		gm.mergeDamageMultiplier += 1;
		yield return new WaitForSeconds(time);
		gm.mergeDamageMultiplier -= 1;
	}

	private IEnumerator baseTileIncrease(float time)
	{
		gm.tileValue += 1;
		yield return new WaitForSeconds(time);
		gm.tileValue -= 1;
	}

	private IEnumerator tileSpeed(float time)
	{
		gm.travelTime -= 0.1f;
		yield return new WaitForSeconds(time);
		gm.travelTime += 0.1f;
	}

	public void closeDaily()
	{
		Debug.Log("close daily");
		LeanTween.scale(dailyWindow, Vector2.zero, 0.2f).setOnComplete(deactivate);
	}

	public void deactivate()
	{
		dailyTab.SetActive(false);
	}
		

	public void openDailyAlert()
	{
		dailyTab.SetActive(true);
		LeanTween.scale(dailyWindow, windowScale, 0.2f);
	}

}

public enum RewardType
{
	Gems,
	TimeSkip,
	DPSboost,
	SilverCrates,
	MergeDamage,
	TileValue,
	CoinBoost,
	TileSpeed,
	Ascension

}

[Serializable]

public struct Rewards
{
	public RewardType Type;
	public float Multiplier;
}



