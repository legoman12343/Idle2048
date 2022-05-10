using UnityEngine;
using UnityEngine.UI;
using System;

public class OfflineDaily : MonoBehaviour
{
	private DateTime oldtime;
	public bool claimDailyReward;
	public LevelController level;
	public Damage damage;
	public AdManager ads;
	public int money;
	public CoinsDisplay moneyScript;
	public float multiplier;
	public GameObject offlineWindow;
	public Sprite greyButton;
	public GameObject doubleButton;
	public Text wang;

	void Start()
	{
		offlineWindow.SetActive(true);
		oldtime = DateTime.Now;
		claimDailyReward = false;
		multiplier = 0.2f;
		offlineEarnings();
	}
	//dailyreward
	void FixedUpdate()
	{
		int nextDay;
		if (WorldTimeAPI.Instance.IsTimeLodaed)
		{
			DateTime currentDateTime = WorldTimeAPI.Instance.GetCurrentDateTime();

			int dayOFYear = currentDateTime.DayOfYear;

			if (dayOFYear == 365 && DateTime.IsLeapYear(currentDateTime.Year) || dayOFYear == 366)
			{
				nextDay = 1;
			}
			else
			{
				nextDay = oldtime.DayOfYear + 1;
			}

			if (nextDay > dayOFYear || ((nextDay == 1) && (oldtime.DayOfYear == 365 || oldtime.DayOfYear == 366)))
			{
				claimDailyReward = true;
			}

		}
	}

	public void offlineEarnings()
	{
		bool completed = false;
		while (!completed)
		{
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
		offlineWindow.SetActive(false);
	}

	public void claimEarningsVideo()
	{
		
		money *= 2;
		doubleButton.GetComponent<Image>().sprite = greyButton;
		doubleButton.GetComponent<Button>().interactable = false;
	}
}