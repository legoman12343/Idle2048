using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ability3 : MonoBehaviour
{

    private float activeTimer = 10f;
    private float cooldownTimer;

    public Slider slider;
    public GameObject ability;
    public float sliderMax = 2f;
    private bool bought = false;
    private bool active = false;
    public GameManager gm;

    // Start is called before the first frame update
    void Start()
    {
        sliderMax = 2f;
        slider.maxValue = sliderMax;
        ability.SetActive(false);
    }

    private IEnumerator cooldownAbility()
    {
        slider.maxValue = sliderMax;
        cooldownTimer -= Time.deltaTime;
        cooldownTimer = 0f;
        while (cooldownTimer < sliderMax)
        {
            cooldownTimer += 0.5f;
            slider.value = cooldownTimer;
            yield return new WaitForSeconds(0.5f);
        }
        active = true;
    }

    public void pressAbility3()
    {
        StartCoroutine(startAbility());
    }


    public IEnumerator startAbility()
    {
        if (active)
        {
            gm.mergeUpgradeChance += 1f;
            slider.maxValue = 10f;
            active = false;
            activeTimer -= Time.deltaTime;
            activeTimer = 10f;
            slider.value = 10f;
            while (activeTimer > 0)
            {
                activeTimer -= 0.01f;
                slider.value = activeTimer;
                yield return new WaitForSeconds(0.01f);
            }
            gm.mergeUpgradeChance -= 1f;
            StartCoroutine(cooldownAbility());
        }
    }


    public void buyAbility3()
    {
        ability.SetActive(true);
        bought = true;
        StartCoroutine(cooldownAbility());
    }
}