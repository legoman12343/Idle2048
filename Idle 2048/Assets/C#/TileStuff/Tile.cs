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
    public Sprite crateSprite2;
    public GameManager gm;
    public MonsterPrefabStuff monsterScript;
    public Vector2 dir;
    public int crateHitCount;
    public bool silver;
    public bool broken = false;

    public void init(TileType type)
    {
        crateHitCount = 0;
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

    public void setCrateSprite2(Sprite c)
    {
        crateSprite2 = c;
    }

    public void crateReward()
    {
        gm.quest.updateOpenCrates(1);
        if (silver)
        {
            switch (Random.value)
            {
                case < 0.05f:
                    {
                        gm.giveGems(2);
                        break;
                    }
                case < 0.3f:
                    {
                        coinMultiplier(60f);
                        break;
                    }
                case < 0.5f:
                    {
                        DPSMultiplier(60f);
                        break;
                    }
                case < 0.7f:
                    {
                        gm.DoubleTiles(2);
                        break;
                    }
                case < 2.0f:
                    {
                        gm.giveCoins(20);
                        break;
                    }
            }
        }
        else
        {
            switch (Random.value)
            {
                case < 0.05f:
                    {
                        gm.giveGems(1);
                        break;
                    }
                case < 0.3f:
                    {
                        coinMultiplier(30f);
                        break;
                    }
                case < 0.5f:
                    {
                        DPSMultiplier(30f);
                        break;
                    }
                case < 0.7f:
                    {
                        gm.DoubleTiles(1);
                        break;
                    }
                case < 2.0f:
                    {
                        gm.giveCoins(10);
                        break;
                    }
            }
        }
    }


    public void updateNumber()
    {
        text.text = value.ToString();
        renderer.color = gm.GetTileTypeValue(value).colour;
    }

    private void coinMultiplier(float time)
    {
        StartCoroutine(gm.coinMultiplier(time));
    }

    private void DPSMultiplier(float time)
    {
        StartCoroutine(gm.DPSMultiplier(time));
    }

    public void DestroyCrate()
    {
        crateReward();
        StartCoroutine(crateAnimation());
    }

    private IEnumerator crateAnimation()
    {
        renderer.sortingOrder = 10;
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.simulated = true;
        rb.AddForce(new Vector2(dir.x,dir.y*2), ForceMode2D.Impulse);
        if (dir.y != 0) { rb.AddTorque(100 * (Random.value > 0.5f ? 1 : -1) * (30 * Mathf.Deg2Rad)); }
        else { rb.AddTorque(100 * (dir.x > 0 ? -1 : 1) * (30 * Mathf.Deg2Rad)); }
        yield return new WaitForSeconds(3f);
        Destroy(gameObject);
    }

    public IEnumerator changeCrateImage()
    {
        yield return new WaitForSeconds(0.2f);
        renderer.sprite = crateSprite2;
    }
}
