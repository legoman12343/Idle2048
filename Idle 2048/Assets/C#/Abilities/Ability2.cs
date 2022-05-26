using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ability2 : MonoBehaviour

{

    private float activeTimer = 10f;
    private float cooldownTimer;

    public Slider slider;
    public GameObject ability;
    public float sliderMax = 2f;
    private bool active = false;
    public GameManager gm;
    private float tempSpeed;
    public Image img;
    private Color32 grey = new Color32(128, 128, 128, 255);
    private Color32 white = new Color32(255, 255, 255, 255);

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
        img.color = grey;
        while (cooldownTimer < sliderMax)
        {
            cooldownTimer += 0.5f;
            slider.value = cooldownTimer;
            yield return new WaitForSeconds(0.5f);
        }
        img.color = white;
        active = true;
    }

    public void pressAbility2()
    {
        StartCoroutine(startAbility());
    }


    public IEnumerator startAbility()
    {
        if (active)
        {
            tempSpeed = gm.travelTime;
            gm.travelTime = 0.03f;
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
            gm.travelTime = tempSpeed;
            StartCoroutine(cooldownAbility());
        }
    }


    public void buyAbility2()
    {
        ability.SetActive(true);
        StartCoroutine(cooldownAbility());
    }
}

