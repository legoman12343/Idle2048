using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using DG.Tweening;
using UnityEngine;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    private float width = 1.7f;
    private float height = 1.7f;
    private Vector2 Rightvec = new Vector2(1.7f, 0);
    private Vector2 Leftvec = new Vector2(-1.7f, 0);
    private Vector2 Upvec = new Vector2(0, 1.7f);
    private Vector2 Downvec = new Vector2(0, -1.7f);
    [SerializeField] private Node nodePrefab;
    [SerializeField] private Tile tilePrefab;
    [SerializeField] private List<TileType> types;
    [SerializeField] private FloatingText floatingTextPrefab;
    public float chance;
    public int startingValue;
    private List<Node> nodes;
    private List<Tile> tiles;
    private GameState state;
    private int round;
    public HealthBarScript healthBar;
    private float travelTime = 0.2f;


    private TileType GetTileTypeValue(int value) => types.First(types => types.value == value);

    void Start()
    {
        ChangeState(GameState.createLevel);
    }

    private void ChangeState(GameState newState)
    {
        state = newState;

        switch(newState)
        {
            case GameState.createLevel:
                makeGrid();
                break;
            case GameState.SpawningBlocks:
                SpawnTiles(round++ == 0 ? 2 : 1);
                break;
            case GameState.WaitingInput:
                break;
            case GameState.Moving:
                break;
        }
    }
    void Update()
    {
        if(tiles.Count() == 0)
        {
            round = 0;
            ChangeState(GameState.SpawningBlocks);
        }
        if (state != GameState.WaitingInput) return;

        if (Input.GetKeyDown(KeyCode.LeftArrow)) { Shift(Leftvec); return; }
        if (Input.GetKeyDown(KeyCode.RightArrow)) { Shift(Rightvec); return; }
        if (Input.GetKeyDown(KeyCode.UpArrow)) { Shift(Upvec); return; }
        if (Input.GetKeyDown(KeyCode.DownArrow)) { Shift(Downvec); return; }
    }


    void makeGrid()
    {
        round = 0;
        nodes = new List<Node>();
        tiles = new List<Tile>();
        for (int x = 0; x < 4; x++)
        {
            for (int y = 0; y < 4; y++)
            {
                var node = Instantiate(nodePrefab,new Vector2(x*width - 5f,y* height-2f),Quaternion.identity);
                nodes.Add(node);
            }
        }

        ChangeState(GameState.SpawningBlocks);
    }

    void SpawnTiles(int amount)
    {
        var freeNodes = nodes.Where(n => n.OccupiedTile == null).OrderBy(b=>Random.value).ToList();

        if (freeNodes.Count() != 0)
        {
            foreach (var node in freeNodes.Take(amount))
            {
                spawnTile(node, Random.value > chance ? startingValue + 1 : startingValue);
            }
        }
        else
        {
            Reset();
        }


        ChangeState(GameState.WaitingInput);

    }


    void spawnTile(Node node, int value)
    {
        var tile = Instantiate(tilePrefab, node.Pos, Quaternion.identity);
        tile.init(GetTileTypeValue(value));
        tile.SetTile(node);
        tiles.Add(tile);
    }

    void Shift(Vector2 dir) {
        ChangeState(GameState.Moving);
        var orderedTiles = tiles.OrderBy(b => b.Pos.x).ThenBy(b => b.Pos.y).ToList();
        if (dir == Rightvec || dir == Upvec) orderedTiles.Reverse();

        foreach (var tile in orderedTiles)
        {
            var next = tile.Node;
            do
            {
                tile.SetTile(next);

                var possibleNode = GetNodeAtPosition(next.Pos + dir);
                if (possibleNode != null)
                {
                    if(possibleNode.OccupiedTile != null && possibleNode.OccupiedTile.canMerge(tile.value))
                    {
                        tile.MergeTile(possibleNode.OccupiedTile);
                        
                    }
                    else if (possibleNode.OccupiedTile == null) next = possibleNode;
                }

            } while (next != tile.Node);

        }

        var sequence = DOTween.Sequence();

        foreach (var tile in orderedTiles)
        {
            var movePoint = tile.MergingTile != null ? tile.MergingTile.Node.Pos : tile.Node.Pos;

            sequence.Insert(0, tile.transform.DOMove(movePoint, travelTime).SetEase(Ease.InQuad));
        }

        sequence.OnComplete(() =>
        {
            var MergeTiles = orderedTiles.Where(b => b.MergingTile != null).ToList();
            foreach (var tile in MergeTiles)
            {
                mergeTiles(tile.MergingTile, tile);
            }

            ChangeState(GameState.SpawningBlocks);
        });

    }

    void mergeTiles(Tile baseTile, Tile mergingTile)
    {
        var newValue = baseTile.value + 1;
        healthBar.health -= newValue;
        spawnTile(baseTile.Node, newValue);
        //Instantiate(floatingTextPrefab, baseBlock.Pos, Quaternion.identity).Init(newValue);

        removeTile(baseTile);
        removeTile(mergingTile);
    }

    void removeTile(Tile tile)
    {
        tiles.Remove(tile);
        Destroy(tile.gameObject);
    }

    Node GetNodeAtPosition(Vector2 pos)
    {
        return nodes.FirstOrDefault(n => n.Pos == pos);
    }

    void Reset()
    {
        while(tiles.Count != 0)
        {
            removeTile(tiles[0]);
            Debug.Log("REMOVE");
        }
    }
}

[Serializable]

public struct TileType
{
    public int value;
    public Color colour;
}

public enum GameState
{
    createLevel,
    SpawningBlocks,
    WaitingInput,
    Moving,
        
}