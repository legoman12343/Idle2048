using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Achievements : MonoBehaviour
{
    private Vector3 startScale;

    public GameObject window;

    void Start()
    {
        startScale = new Vector3(1f, 1f, 1f);
        window.GetComponent<Transform>().localScale = Vector3.zero;
    }

    public void openSettings()
    {
        window.SetActive(true);
        LeanTween.scale(window, startScale, 0.2f);
    }

    public void closeSettings()
    {
        LeanTween.scale(window, Vector2.zero, 0.2f).setOnComplete(deactivate);
    }

    public void deactivate()
    {
        window.SetActive(false);
    }

}
