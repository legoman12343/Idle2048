using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Gems : MonoBehaviour
{
    public int gems;
    public TextMeshProUGUI gemText;
    public FormatNumber fn;

    void Start()
    {
        gems = 0;
        gemText.text = fn.formatNumber(gems,false);
    }


    public void addGems(int n)
    {
        gems += n;
        gemText.text = fn.formatNumber(gems, false);
    }
}
