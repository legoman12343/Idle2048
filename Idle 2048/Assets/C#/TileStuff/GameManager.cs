using System.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    private float width = 1.7f;
    private float height = 1.7f;
    [SerializeField] private Node nodePrefab;
    [SerializeField] private Tile tilePrefab;
    [SerializeField] private List<TileType> types;
    public float chance;
    public int startingValue;
    private List<Node> nodes;
    private List<Tile> tiles;
    private GameState state;
    private int round;

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
                var tile = Instantiate(tilePrefab,node.Pos,Quaternion.identity);
                tile.init(GetTileTypeValue(Random.value > chance ? startingValue+1 : startingValue));
            }
        }
        else
        {
            //loose
            Reset();
        }
    }

    void Reset()
    {

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