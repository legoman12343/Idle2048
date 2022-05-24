using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotificationAnimation : MonoBehaviour
{
    public GameObject icon;
    public Vector3 originalScale;
    private IEnumerator routine;
    private bool check = false;

    void Start()
    {
        originalScale = icon.GetComponent<RectTransform>().localScale;
        routine = animation();
    }

    IEnumerator animation()
    {
        while(true)
        {
            LeanTween.scale(icon, originalScale*0.65f, 0.4f);
            yield return new WaitForSeconds(0.5f);
            LeanTween.scale(icon, originalScale, 0.4f);
            yield return new WaitForSeconds(0.5f);
        }
    }

    public bool startAnimation()
    {
        if (check == false)
        {
            icon.SetActive(true);
            StartCoroutine(routine);
            check = true;
            return true;
        }
        return false;
    }

    public void stopAnimation()
    {
        if (check == true)
        {
            StopCoroutine(routine);
            icon.SetActive(false);
            check = false;
        }
    }
}
