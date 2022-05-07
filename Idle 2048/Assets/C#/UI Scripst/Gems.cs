using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Gems : MonoBehaviour
{
    public int gems;
    public TextMeshProUGUI gemText;

    void Start()
    {
        gems = 0;
        gemText.text = gems.ToString();
    }


    public void addGems(int n)
    {
        gems += n;
        gemText.text = gems.ToString();
    }
}
