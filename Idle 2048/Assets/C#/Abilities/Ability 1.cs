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
    // Start is called before the first frame update
    void Start()
    {
        slider.maxValue = sliderMax;
        ability.SetActive(false);
    }

    private IEnumerator activateAbility()
    {
        activeTimer -= Time.deltaTime;
        activeTimer = 10f;
        while (activeTimer > 0)
        {
            activeTimer -= Time.deltaTime;
            yield return new WaitForSeconds(0.1f);
        }

        cooldownTimer -= Time.deltaTime;
        cooldownTimer = sliderMax;

        while (cooldownTimer > 0)
        {
            cooldownTimer -= Time.deltaTime;
            slider.value = cooldownTimer;
            yield return new WaitForSeconds(0.5f);
        }
    }

    public void buyAbility1()
    {
        ability.SetActive(true);
        bought = true;
    }
}
