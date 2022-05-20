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
    [SerializeField] private Node nodePrefab;
    [SerializeField] private Tile tilePrefab;
    [SerializeField] public List<TileType> types;
    private Vector2 Rightvec = new Vector2(1.7f, 0);
    private Vector2 Leftvec = new Vector2(-1.7f, 0);
    private Vector2 Upvec = new Vector2(0, 1.7f);
    private Vector2 Downvec = new Vector2(0, -1.7f);
    public GameObject floatingTextPrefab;
    public float chance;
    public int startingValue;
    private List<Node> nodes;
    private List<Tile> tiles;
    private GameState state;
    private int round;
    public HealthBarScript healthBar;
    public float travelTime;
    public Transform endPoint;
    public float crateChance;
    public int crate;
    public int crateMax;
    public Sprite crateSprite;
    public Sprite crateSprite2;
    public Sprite silverCrateSprite;
    public Sprite silverCrateSprite2;
    public CoinsDisplay moneyScript;
    public LevelController level;
    public Gems gems;
    public MonsterPrefabStuff monster;
    public GameObject coinMultiplierText;
    public GameObject damageMultiplierText;
    private IEnumerator coroutine;
    public bool hasMoved;
    public Vector2 direction;
    public float mergeUpgradeChance;
    public float criticalHitChance;
    public int silverCrateCount = 0;
    public Quests quest;
    public bool randomShift = false;
    public float randomShiftTimer = 0f;
    private bool buttonOn = false;
    public GameObject button;
    public GameObject buttonDisabled;
    public GameObject buttonObj;
    public float instantCrateChance;
    private bool previousCrate;
    public int tileValue;
    public int mergeDamageMultiplier = 0;
    public bool hitCrit;
    private float tempCoinMult;
    public float ASMultiplier;
    public Ascension ascension;


    public TileType GetTileTypeValue(float value) => types.First(types => types.value == value);
    

    void Start()
    {
        crateChance = 1.0f;
        crateMax = 1;
        crate = 1;
        ASMultiplier = 0.0f;
        travelTime = 0.2f;
        tileValue = 1;
        previousCrate = false;
        instantCrateChance = 0f;
        mergeUpgradeChance = 0.0f;
        criticalHitChance = 0.0f;
        hasMoved = false;
        ChangeState(GameState.createLevel);
        buttonObj.SetActive(false);
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
                SpawnTiles(round++ == 0 ? tileValue +1 : tileValue);
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
        if (hasMoved)
        {
            hasMoved = false;
            Shift(direction);
            return;
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.UpArrow)) { Shift(Upvec);return; }
            if (Input.GetKeyDown(KeyCode.DownArrow)) { Shift(Downvec);return; }
            if (Input.GetKeyDown(KeyCode.LeftArrow)) { Shift(Leftvec);return; }
            if (Input.GetKeyDown(KeyCode.RightArrow)) { Shift(Rightvec);return; }
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
                var node = Instantiate(nodePrefab,new Vector2(x* (Screen.width / 220f) - 5f,y* (Screen.height / 330) -1.8f),Quaternion.identity);
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
                spawnTile(node, Random.value > chance ? startingValue * 2 : startingValue, false);
            }
        }
        else
        {
            Reset();
        }
        ChangeState(GameState.WaitingInput);
    }


    void spawnTile(Node node, float value, bool merging)
    {
        if ((Random.value < crateChance || (Random.value < instantCrateChance && previousCrate)) && crate != 0 && merging == false)
        {
            previousCrate = false;
            var tile = Instantiate(tilePrefab, node.Pos, Quaternion.identity);
            if (silverCrateCount > 0)
            {
                silverCrateCount--;
                tile.silver = true;
                tile.setCrateSprite(silverCrateSprite);
                tile.setCrateSprite2(silverCrateSprite2);
            }
            else
            {
                tile.silver = false;
                tile.setCrateSprite(crateSprite);
                tile.setCrateSprite2(crateSprite2);
            }
            
            tile.init(GetTileTypeValue(0));
            tile.gm = this;
            tile.SetTile(node);
            tile.monsterScript = monster;
            tiles.Add(tile);
            crate -= 1;
        }
        else
        {
            var tile = Instantiate(tilePrefab, node.Pos, Quaternion.identity);
            tile.init(GetTileTypeValue(value));
            tile.gm = this;
            tile.SetTile(node);
            tile.monsterScript = monster;
            tiles.Add(tile);
        }
        
        
    }

    void Shift(Vector2 dir) {
        ChangeState(GameState.Moving);
        var orderedTiles = tiles.OrderBy(b => b.Pos.x).ThenBy(b => b.Pos.y).ToList();
        if (dir == Rightvec || dir == Upvec) orderedTiles.Reverse();
        int count;
        bool crateHits;
        foreach (var tile in orderedTiles)
        {
            crateHits = false; 
            count = 0;
            var next = tile.Node;
            do
            {
                tile.SetTile(next);

                var possibleNode = GetNodeAtPosition(next.Pos + dir);
                if (possibleNode != null)
                {
                    if (possibleNode.OccupiedTile != null && possibleNode.OccupiedTile.canMerge(tile.value) && tile.value != 0)
                    {
                        tile.MergeTile(possibleNode.OccupiedTile);
                    }
                    else if (possibleNode.OccupiedTile == null)
                    {
                        next = possibleNode;
                        count++;
                    }
                }
                if (tile.value == 0 && count > 1)
                {
                    if (!crateHits) { tile.crateHitCount++; crateHits = true; } 
                    if (tile.crateHitCount == 2 && !tile.broken)
                    {
                        tile.broken = true;
                        tile.Node.OccupiedTile = null;
                        tile.dir = dir;
                        tiles.Remove(tile);
                        tile.DestroyCrate();
                        crate += 1;
                    }
                    else if(tile.crateHitCount == 1)
                    {
                        StartCoroutine(tile.changeCrateImage());
                    }
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
            float newValue = baseTile.value * 2 * (Random.value < mergeUpgradeChance ? 2 : 1);
            quest.updateMergeDamage(newValue + mergeDamageMultiplier);
            quest.updateTileLevel(newValue);
            spawnTile(baseTile.Node, newValue, true);
            if (Random.value < criticalHitChance) hitCrit = true;
            else hitCrit = false;
            if (hitCrit) newValue *= 5;
            newValue += ASMultiplier;
            StartCoroutine(damageMonster(newValue));
            var text = Instantiate(floatingTextPrefab, baseTile.Pos, Quaternion.identity);
            var floatingScript = text.GetComponent<FloatingText>();
            floatingScript.endPoint = endPoint;
            floatingScript.Init(newValue, hitCrit);

            removeTile(mergingTile);
            removeTile(baseTile);
    }

    void removeTile(Tile tile)
    {
        if (tile.value == 0)
        {
            previousCrate = true;
        }
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
        }
        crate = crateMax;
    }

    public IEnumerator damageMonster(float v)
    {
        yield return new WaitForSeconds(1f);
        healthBar.health -= v;
    }

    public void DoubleTiles(int n)
    {
        foreach (var tile in tiles)
        {
            if (tile.value != 0)
            {
                tile.value *= 2;
                tile.updateNumber();
            }
        }
    }

    public void giveGems(int n)
    {
        gems.addGems(n);
    }

    public void giveCoins(int n)
    {
        moneyScript.addCoins(level.getMonsterCoins() * n);
    }

    /*
    public void giveDPSBoost()
    {
        damage.multiplier += 1;
    }*/



    private IEnumerator automation()
    {
        while (randomShift && buttonOn)
        {
            switch (Random.Range(0, 4))
            {
                case 0:
                    {
                        Shift(Upvec);
                        break;
                    }
                case 1:
                    {
                        Shift(Rightvec);
                        break;
                    }
                case 2:
                    {
                        Shift(Leftvec);
                        break;
                    }
                case 3:
                    {
                        Shift(Downvec);
                        break;
                    }
            }

            yield return new WaitForSeconds(randomShiftTimer);
        }
        
    }

    public void updateButton()
    {
        if (buttonOn == true)
        {
            buttonOn = false;
            buttonDisabled.SetActive(true);
        }
        else
        {
            buttonOn = true;
            StartCoroutine(automation());
        }
    }

    public void showButton()
    {
        buttonObj.SetActive(true);
        buttonDisabled.SetActive(false);
        buttonOn = true;
        StartCoroutine(automation());
    }

    public IEnumerator DPSMultiplier(float time)
    {
        damageMultiplierText.SetActive(true);
        monster.healthBar.damage.changeMultiplier(1);
        yield return new WaitForSeconds(time);
        damageMultiplierText.SetActive(false);
        monster.healthBar.damage.changeMultiplier(-1);
    }

    public IEnumerator coinMultiplier(float time)
    {
        tempCoinMult = monster.multiplier;
        coinMultiplierText.SetActive(true);
        monster.multiplier *= 2;
        yield return new WaitForSeconds(time);
        coinMultiplierText.SetActive(false);
        monster.multiplier = tempCoinMult;
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