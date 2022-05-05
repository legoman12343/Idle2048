using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileInfo : MonoBehaviour
{
    public int value;
    // Start is called before the first frame update
    void Start()
    {
        Tile1();
    }

    public void IncrementValue()
    {
        value++;
        switch(value)
        {
            case 2:
                Tile2();
                break;
            case 3:
                break;
        }
        
    }

    void Tile1()
    {
        value = 1;
        GetComponent<SpriteRenderer>().color = new Color(255, 0, 174, 255);
    }

    void Tile2()
    {
        GetComponent<SpriteRenderer>().color = new Color(255, 75, 0, 255);
    }
}
