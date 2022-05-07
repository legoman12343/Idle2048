using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Random = UnityEngine.Random;

public class Tile : MonoBehaviour
{
    public int value;
    public Node Node;
    public Tile MergingTile;
    public bool Merging;
    public Vector2 Pos => transform.position;
    [SerializeField] private SpriteRenderer renderer;
    [SerializeField] private TextMeshPro text;
    public Sprite crateSprite;
    public GameManager gm;
    public MonsterPrefabStuff monsterScript;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
            StartCoroutine(DPSMultiplier());
    }

    public void init(TileType type)
    {
        value = type.value;
        renderer.color = type.colour;
        if (value == 0)
        {            
            renderer.sprite = crateSprite;
        }
        else
        {
            text.text = value.ToString();
        }
        
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

    public void setCrateSprite(Sprite c)
    {
        crateSprite = c;
    }

    public void crateReward(Sprite c)
    {
        switch (Random.value)
        {
            case < 0.05f:
                {
                    gm.giveGems();
                    break;
                }
            case < 0.3f:
                {
                    StartCoroutine(coinMultiplier());
                    break;
                }
            case < 0.5f:
                {
                    StartCoroutine(DPSMultiplier());
                    break;
                }
            case < 0.7f:
                {
                    gm.DoubleTiles();
                    break;
                }
            case < 2.0f:
                {
                    gm.giveCoins();
                    break;
                }
        }
    }

    public void updateNumber()
    {
        text.text = value.ToString();
        renderer.color = gm.GetTileTypeValue(value).colour;
    }

    private IEnumerator coinMultiplier()
    {
        monsterScript.multiplier += 1;
        yield return new WaitForSeconds(30f);
        monsterScript.multiplier -= 1;
    }

    private IEnumerator DPSMultiplier()
    {
        monsterScript.healthBar.multiplier += 1;
        yield return new WaitForSeconds(30f);
        monsterScript.healthBar.multiplier -= 1;
    }
}
