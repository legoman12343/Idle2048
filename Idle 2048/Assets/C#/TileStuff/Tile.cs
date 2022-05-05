using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Tile : MonoBehaviour
{
    public int value;
    [SerializeField] private SpriteRenderer renderer;
    [SerializeField] private TextMeshPro text;
    public void init(TileType type)
    {
        value = type.value;
        renderer.color = type.colour;
        text.text = type.value.ToString();
    }
}
