using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Credits : MonoBehaviour
{
    public GameObject window;

    private Vector3 startScale;

    public void openCredits()
    {
        window.SetActive(true);
        LeanTween.scale(window, startScale, 0.2f);
    }

    public void deactivate()
    {
        window.SetActive(false);
    }

    public void closeCredits()
    {
        LeanTween.scale(window, Vector2.zero, 0.2f).setOnComplete(deactivate);
    }

    void Start()
    {
        startScale = new Vector3(1f, 1f, 1f);
        window.GetComponent<Transform>().localScale = Vector3.zero;
    }
}
