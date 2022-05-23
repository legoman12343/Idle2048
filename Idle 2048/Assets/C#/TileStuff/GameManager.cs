using System;
using System.Numerics;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using DG.Tweening;
using UnityEngine;
using Random = UnityEngine.Random;
using Vector3 = UnityEngine.Vector3;
using Vector2 = UnityEngine.Vector2;
using Quaternion = UnityEngine.Quaternion;


public class GameManager : MonoBehaviour
{
    private float width;
    private float height;
    [SerializeField] private Node nodePrefab;
    [SerializeField] private Tile tilePrefab;
    [SerializeField] public List<TileType> types;
    private Vector2 Rightvec;
    private Vector2 Leftvec;
    private Vector2 Upvec;
    private Vector2 Downvec;
    public GameObject floatingTextPrefab;
    public float chance;
    public BigInteger startingValue;
    public List<Node> nodes;
    public List<Tile> tiles;
    private List<Tile> brokenCrates;
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
    public RectTransform gridBackground;
    public RectTransform resWorkAround;
    public bool gridSizeUp;
    public AudioSource moveTileSound;
    public AudioSource combineTileSound;
    public AudioSource crateCrash;
    public int movesNeeded;


    public TileType GetTileTypeValue(BigInteger value)
    {
        while (value > types[types.Count - 1].value)
        {
            int index = types.Count - 1;

            TileType newTile = new TileType();
            newTile.value = types[index].value * 2;

            index++;

            while (index > 19) index -= 19;

            newTile.colour = types[index].colour;

            types.Add(newTile);
        }

        return types.First(type => type.value == value);
    }
    
   

    void Start()
    {
        TileType y = new TileType();
        y.value = 0;
        y.colour = types[0].colour;
        types[0] = y;

        BigInteger x = 1;

        for (int i = 1; i < types.Count; i++)
        {
            TileType t = new TileType();
            t.value = x;
            t.colour = types[i].colour;
            types[i] = t;
            x *= 2;
        }

        startingValue = 1;
        movesNeeded = 2;
        round = 0;
        gridSizeUp = false;
        crateChance = 0f;
        crateMax = 1;
        crate = 1;
        ASMultiplier = 1.0f;
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

    public void clearLists()
    {
        while (tiles.Count() > 0)
        {
            Destroy(tiles[0].gameObject);
            tiles.RemoveAt(0);
        }
        while (nodes.Count > 0)
        {
            Destroy(nodes[0].gameObject);
            nodes.RemoveAt(0);
        }
        crate = crateMax;
    }

    public void makeGrid()
    {
        Vector3[] v = new Vector3[4];
        gridBackground.GetWorldCorners(v);

        float width;
        float w = v[2].x - v[1].x;
        if (!gridSizeUp)
        {
            nodes = new List<Node>();
            tiles = new List<Tile>();

            float half = 0.71f;
            float gap = (w - half * 8) / 5;
            for (int x = 1; x < 5; x++)
            {
                for (int y = 1; y < 5; y++)
                {
                    var node = Instantiate(nodePrefab, new Vector2(gap * x + ((2 * x) - 1) * half + v[0].x, gap * y + ((2 * y) - 1) * half + v[0].y), Quaternion.identity);
                    RectTransform transform = node.GetComponent<RectTransform>();
                    var a = (transform.localScale.x / Screen.width) * Screen.width * 1.35f;
                    var b = (transform.localScale.y / Screen.height) * Screen.height * 1.35f;
                    transform.localScale = new Vector3(a, b, transform.localScale.z);
                    transform.sizeDelta = new Vector2((Screen.width / 100) * 20, (Screen.width / 100) * 20);
                    nodes.Add(node);
                }
            }
            width = nodes[4].GetComponent<Transform>().position.x - nodes[0].GetComponent<Transform>().position.x;
        }
        else
        {
            clearLists();
            float half = 0.5f;
            float gap = (w - half * 10) / 6;
            for (int x = 1; x < 6; x++)
            {
                for (int y = 1; y < 6; y++)
                {
                    var node = Instantiate(nodePrefab, new Vector2(gap * x + ((2 * x) - 1) * half + v[0].x, gap * y + ((2 * y) - 1) * half + v[0].y), Quaternion.identity);
                    RectTransform transform = node.GetComponent<RectTransform>();
                    var a = (transform.localScale.x / Screen.width) * Screen.width;
                    var b = (transform.localScale.y / Screen.height) * Screen.height;
                    transform.localScale = new Vector3(a, b, transform.localScale.z);
                    transform.sizeDelta = new Vector2((Screen.width / 100) * 10, (Screen.width / 100) * 10);
                    nodes.Add(node);
                }
            }
            width = nodes[5].GetComponent<Transform>().position.x - nodes[0].GetComponent<Transform>().position.x;
        }

        float height = nodes[1].GetComponent<Transform>().position.y - nodes[0].GetComponent<Transform>().position.y;
        Rightvec = new Vector2(width, 0);
        Leftvec = new Vector2(-width, 0);
        Upvec = new Vector2(0, height);
        Downvec = new Vector2(0, -height);

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


    void spawnTile(Node node, BigInteger value, bool merging)
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
            crate -= 1;
            if (gridSizeUp)
            {
                RectTransform transform = tile.GetComponent<RectTransform>();
                var a = (transform.localScale.x / Screen.width) * Screen.width;
                var b = (transform.localScale.y / Screen.height) * Screen.height;
                transform.localScale = new Vector3(a, b, transform.localScale.z);
                transform.sizeDelta = new Vector2((Screen.width / 100) * 10, (Screen.width / 100) * 10);
            }
            else
            {
                RectTransform transform = tile.GetComponent<RectTransform>();
                var a = (transform.localScale.x / Screen.width) * Screen.width * 1.35f;
                var b = (transform.localScale.y / Screen.height) * Screen.height * 1.35f;
                transform.localScale = new Vector3(a, b, transform.localScale.z);
                transform.sizeDelta = new Vector2((Screen.width / 100) * 20, (Screen.width / 100) * 20);
            }
            tiles.Add(tile);
        }
        else
        {
            var tile = Instantiate(tilePrefab, node.Pos, Quaternion.identity);
            tile.init(GetTileTypeValue(value));
            tile.gm = this;
            tile.SetTile(node);
            tile.monsterScript = monster;
            if (gridSizeUp)
            {
                RectTransform transform = tile.GetComponent<RectTransform>();
                var a = (transform.localScale.x / Screen.width) * Screen.width;
                var b = (transform.localScale.y / Screen.height) * Screen.height;
                transform.localScale = new Vector3(a, b, transform.localScale.z);
                transform.sizeDelta = new Vector2((Screen.width / 100) * 10, (Screen.width / 100) * 10);
            }
            else
            {
                RectTransform transform = tile.GetComponent<RectTransform>();
                var a = (transform.localScale.x / Screen.width) * Screen.width * 1.35f;
                var b = (transform.localScale.y / Screen.height) * Screen.height * 1.35f;
                transform.localScale = new Vector3(a, b, transform.localScale.z);
                transform.sizeDelta = new Vector2((Screen.width / 100) * 20, (Screen.width / 100) * 20);
            }
            tiles.Add(tile);
            if (merging)tile.startParticles();
        }
        
        
    }

    void Shift(Vector2 dir)
    {
        ChangeState(GameState.Moving);
        bool merge = false;
        var orderedTiles = tiles.OrderBy(b => b.Pos.x).ThenBy(b => b.Pos.y).ToList();
        if (dir == Rightvec || dir == Upvec) orderedTiles.Reverse();
        int count;
        bool crateHits;
        brokenCrates = new List<Tile>();
        for (int i = 0; i < orderedTiles.Count; i++)
        {
            var tile = orderedTiles[i];
            
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
                        merge = true;
                    }
                    else if (possibleNode.OccupiedTile == null)
                    {
                        next = possibleNode;
                        count++;
                    }
                }
                if (tile.value == 0 && count > 1)
                {
                    if (!crateHits) { tile.crateHitCount++; crateCrash.Play(); crateHits = true;}
                    if (tile.crateHitCount == movesNeeded && !tile.broken)
                    {
                        if (!brokenCrates.Contains(tile))
                        {
                            tile.broken = true;
                            brokenCrates.Add(tile);
                        }
                    }
                    else
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

        while (brokenCrates.Count > 0)
        {
            brokenCrates[0].Node.OccupiedTile = null;
            brokenCrates[0].dir = dir;
            tiles.Remove(brokenCrates[0]);
            brokenCrates[0].DestroyCrate();
            brokenCrates.RemoveAt(0);
            crate += 1;
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
        if(merge)
        {
            combineTileSound.Play();
        }
        moveTileSound.Play();
    }

    void mergeTiles(Tile baseTile, Tile mergingTile)
    {
        BigInteger newValue = baseTile.value * 2 * (Random.value < mergeUpgradeChance ? 2 : 1);
        quest.updateMergeDamage(newValue + mergeDamageMultiplier);
        quest.updateTileLevel(newValue);
        spawnTile(baseTile.Node, newValue, true);
        if (Random.value < criticalHitChance) hitCrit = true;
        else hitCrit = false;
        if (hitCrit) newValue *= 5;
        newValue *= (int)(ASMultiplier * 100);
        newValue /= 100;
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

    public void directionLeft()
    {
        direction = Leftvec;
        hasMoved = true;
    }

    public void directionRight()
    {
        direction = Rightvec;
        hasMoved = true;
    }

    public void directionUp()
    {
        direction = Upvec;
        hasMoved = true;
    }

    public void directionDown()
    {
        direction = Downvec;
        hasMoved = true;
    }

    public IEnumerator damageMonster(BigInteger v)
    {
        yield return new WaitForSeconds(1f);
        if (v > 1000000000)
        {
            healthBar.healthBI -= v;
        }
        else
        {
            healthBar.health -= (float)v;
        }
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
    public BigInteger value;
    public Color colour;
}

public enum GameState
{
    createLevel,
    SpawningBlocks,
    WaitingInput,
    Moving,
        
}