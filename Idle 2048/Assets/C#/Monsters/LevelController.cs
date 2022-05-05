using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelController : MonoBehaviour
{
    public TextMeshProUGUI levelCount;
    public int level;
    // Start is called before the first frame update
    void Start()
    {
        level = 1;
    }

    // Update is called once per frame
    void Update()
    {
        levelCount.text = level.ToString();
    }

    void levelUp()
    {
        level++;
    }
}
