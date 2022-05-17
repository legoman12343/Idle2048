using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ability1 : MonoBehaviour
{

    private float activeTimer = 10f;
    private float cooldownTimer;

    public Image img;
    public Slider slider;
    public GameObject ability;
    public float sliderMax = 600f;
    private bool bought = false;
    private bool active = false;

    public GameObject fill;

    // Start is called before the first frame update
    void Start()
    {
        slider.maxValue = sliderMax;
        ability.SetActive(false);
    }

    private IEnumerator cooldownAbility()
    {
        slider.maxValue = sliderMax;
        cooldownTimer -= Time.deltaTime;
        cooldownTimer = sliderMax;

        while (cooldownTimer < 600)
        {
            cooldownTimer += Time.deltaTime;
            slider.value = cooldownTimer;
            yield return new WaitForSeconds(0.5f);
        }
        active = true;
        fill.SetActive(false);
    }

    public void pressAbility1()
    {
        StartCoroutine(startAbility());
    }


    public IEnumerator startAbility()
    {
        if (active)
        {
            fill.SetActive(true);
            slider.maxValue = 10f;
            active = false;
            activeTimer -= Time.deltaTime;
            activeTimer = 10f;
            slider.value = 10f;
            while (activeTimer > 0)
            {
                slider.value = activeTimer;
                activeTimer -= Time.deltaTime;
                yield return new WaitForSeconds(0.1f);
            }
            StartCoroutine(cooldownAbility);
        }
    }


    public void buyAbility1()
    {
        ability.SetActive(true);
        bought = true;
        StartCoroutine(cooldownAbility());
    }
}
