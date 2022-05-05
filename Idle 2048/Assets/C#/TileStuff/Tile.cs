using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Tile : MonoBehaviour
{
    public int value;
    public Node Node;
    public Tile MergingTile;
    public bool Merging;
    public Vector2 Pos => transform.position;
    [SerializeField] private SpriteRenderer renderer;
    [SerializeField] private TextMeshPro text;
    public void init(TileType type)
    {
        value = type.value;
        renderer.color = type.colour;
        text.text = type.value.ToString();
    }

    public void SetTile(Node node)
    {
        if (Node != null) Node.OccupiedTile = null;
        Node = node;
        Node.OccupiedTile = this;
    }

    public void MergeTile(Tile tileToMergeWith)
    {
        MergingTile = tileToMergeWith;

        Node.OccupiedTile = null;

        tileToMergeWith.Merging = true;
    }

    public bool canMerge(int Value) => Value == value && !Merging && MergingTile == null;
}
