using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NorificationAnimation : MonoBehaviour
{
    public GameObject icon;
    public Vector3 originalScale;
    private IEnumerator routine;

    void Start()
    {
        originalScale = icon.GetComponent<RectTransform>().localScale;
        routine = animation();
    }

    IEnumerator animation()
    {
        while(true)
        {
            LeanTween.scale(icon, originalScale/4, 0.2f);
            yield return new WaitForSeconds(0.25f);
            LeanTween.scale(icon, originalScale, 0.2f);
            yield return new WaitForSeconds(0.25f);
        }
    }

    public void startAnimation()
    {
        icon.SetActive(true);
        StartCoroutine(routine);
    }

    public void stopAnimation()
    {
        StopCoroutine(routine);
        icon.SetActive(false);
    }
}
