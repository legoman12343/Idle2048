using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingTiles : MonoBehaviour
{
    public Transform tileSpawn1;
    public Transform tileSpawn2;
    public Transform tileSpawn3;
    public Transform tileSpawn4;
    public Transform tileSpawn5;
    public Transform tileSpawn6;
    public Transform tileSpawn7;
    public Transform tileSpawn8;
    public Transform tileSpawn9;
    public Transform tileSpawn10;
    public Transform tileSpawn11;
    public Transform tileSpawn12;
    public Transform tileSpawn13;
    public Transform tileSpawn14;
    public Transform tileSpawn15;
    public Transform tileSpawn16;
    public CreateTile createTile;
    void Start()
    {
        createTile = GetComponent<CreateTile>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("d")){ moveRight(); SpawnTile(); }
        if(Input.GetKeyDown("a")){moveLeft(); SpawnTile(); }
        if(Input.GetKeyDown("w")){ moveUp(); SpawnTile(); }
        if(Input.GetKeyDown("s")){ moveDown(); SpawnTile(); }
    }

    void SpawnTile()
    {
        createTile.PlaceTile();
    }

    void moveRight()
    {
        RaycastHit2D hit1;
        RaycastHit2D hit2;
        RaycastHit2D hit3;
        RaycastHit2D hit4;
        RaycastHit2D hit;
        //first
        hit3 = Physics2D.Raycast(tileSpawn3.position, Vector2.left, 0.1f);
        if(hit3.collider != null)
        {
            hit = Physics2D.Raycast(tileSpawn4.position, Vector2.left, 0.1f);
            if(hit.collider == null)
            {
                hit3.transform.GetComponent<Transform>().position = tileSpawn4.transform.position;
            }
            else
            {
                Destroy(hit3.transform.GetComponent<GameObject>());
                hit.transform.GetComponent<TileInfo>().IncrementValue();
            }
        }
        hit3 = Physics2D.Raycast(tileSpawn7.position, Vector2.left, 0.1f);
        if (hit3.collider != null)
        {
            hit = Physics2D.Raycast(tileSpawn8.position, Vector2.left, 0.1f);
            if (hit.collider == null)
            {
                hit3.transform.GetComponent<Transform>().position = tileSpawn8.transform.position;
            }
            else
            {
                Destroy(hit3.transform.GetComponent<GameObject>());
                hit.transform.GetComponent<TileInfo>().IncrementValue();
            }
        }
        hit3 = Physics2D.Raycast(tileSpawn11.position, Vector2.left, 0.1f);
        if (hit3.collider != null)
        {
            hit = Physics2D.Raycast(tileSpawn12.position, Vector2.left, 0.1f);
            if (hit.collider == null)
            {
                hit3.transform.GetComponent<Transform>().position = tileSpawn12.transform.position;
            }
            else
            {
                Destroy(hit3.transform.GetComponent<GameObject>());
                hit.transform.GetComponent<TileInfo>().IncrementValue();
            }
        }
        hit3 = Physics2D.Raycast(tileSpawn15.position, Vector2.left, 0.1f);
        if (hit3.collider != null)
        {
            hit = Physics2D.Raycast(tileSpawn16.position, Vector2.left, 0.1f);
            if (hit.collider == null)
            {
                hit3.transform.GetComponent<Transform>().position = tileSpawn16.transform.position;
            }
            else
            {
                Destroy(hit3.transform.GetComponent<GameObject>());
                hit.transform.GetComponent<TileInfo>().IncrementValue();
            }
        }
        //second
        Physics.SyncTransforms();
        hit2 = Physics2D.Raycast(tileSpawn2.position, Vector2.left, 0.1f);
        if (hit2.collider != null)
        {
            hit = Physics2D.Raycast(tileSpawn3.position, Vector2.left, 0.1f);
            if (hit.collider == null)
            {
                hit2.transform.GetComponent<Transform>().position = tileSpawn3.transform.position;
                hit = Physics2D.Raycast(tileSpawn4.position, Vector2.left, 0.1f);
                if (hit.collider == null)
                {
                    hit2.transform.GetComponent<Transform>().position = tileSpawn4.transform.position;
                }
            }
            else
            {
                Destroy(hit2.transform.GetComponent<GameObject>());
                hit.transform.GetComponent<TileInfo>().IncrementValue();
                hit2.transform.GetComponent<Transform>().position = tileSpawn9.transform.position;
                hit = Physics2D.Raycast(tileSpawn13.position, Vector2.left, 0.1f);
                if (hit.collider == null)
                {
                    hit2.transform.GetComponent<Transform>().position = tileSpawn13.transform.position;
                }
            }
        }
        hit2 = Physics2D.Raycast(tileSpawn6.position, Vector2.left, 0.1f);
        if (hit2.collider != null)
        {
            hit = Physics2D.Raycast(tileSpawn7.position, Vector2.left, 0.1f);
            if (hit.collider == null)
            {
                hit2.transform.GetComponent<Transform>().position = tileSpawn7.transform.position;
                hit = Physics2D.Raycast(tileSpawn8.position, Vector2.left, 0.1f);
                if (hit.collider == null)
                {
                    hit2.transform.GetComponent<Transform>().position = tileSpawn8.transform.position;
                }
            }
            else
            {
                Destroy(hit2.transform.GetComponent<GameObject>());
                hit.transform.GetComponent<TileInfo>().IncrementValue();
                hit2.transform.GetComponent<Transform>().position = tileSpawn9.transform.position;
                hit = Physics2D.Raycast(tileSpawn13.position, Vector2.left, 0.1f);
                if (hit.collider == null)
                {
                    hit2.transform.GetComponent<Transform>().position = tileSpawn13.transform.position;
                }
            }
        }
        hit2 = Physics2D.Raycast(tileSpawn10.position, Vector2.left, 0.1f);
        if (hit2.collider != null)
        {
            hit = Physics2D.Raycast(tileSpawn11.position, Vector2.left, 0.1f);
            if (hit.collider == null)
            {
                hit2.transform.GetComponent<Transform>().position = tileSpawn11.transform.position;
                hit = Physics2D.Raycast(tileSpawn12.position, Vector2.left, 0.1f);
                if (hit.collider == null)
                {
                    hit2.transform.GetComponent<Transform>().position = tileSpawn12.transform.position;
                }
            }
            else
            {
                Destroy(hit2.transform.GetComponent<GameObject>());
                hit.transform.GetComponent<TileInfo>().IncrementValue();
                hit2.transform.GetComponent<Transform>().position = tileSpawn9.transform.position;
                hit = Physics2D.Raycast(tileSpawn13.position, Vector2.left, 0.1f);
                if (hit.collider == null)
                {
                    hit2.transform.GetComponent<Transform>().position = tileSpawn13.transform.position;
                }
            }
        }
        hit2 = Physics2D.Raycast(tileSpawn14.position, Vector2.left, 0.1f);
        if (hit2.collider != null)
        {
            hit = Physics2D.Raycast(tileSpawn15.position, Vector2.left, 0.1f);
            if (hit.collider == null)
            {
                hit2.transform.GetComponent<Transform>().position = tileSpawn15.transform.position;
                hit = Physics2D.Raycast(tileSpawn16.position, Vector2.left, 0.1f);
                if (hit.collider == null)
                {
                    hit2.transform.GetComponent<Transform>().position = tileSpawn16.transform.position;
                }
            }
            else
            {
                Destroy(hit2.transform.GetComponent<GameObject>());
                hit.transform.GetComponent<TileInfo>().IncrementValue();
                hit2.transform.GetComponent<Transform>().position = tileSpawn9.transform.position;
                hit = Physics2D.Raycast(tileSpawn13.position, Vector2.left, 0.1f);
                if (hit.collider == null)
                {
                    hit2.transform.GetComponent<Transform>().position = tileSpawn13.transform.position;
                }
            }
        }
        //third
        Physics.SyncTransforms();
        hit1 = Physics2D.Raycast(tileSpawn1.position, Vector2.left, 0.1f);
        if (hit1.collider != null)
        {
            hit2 = Physics2D.Raycast(tileSpawn2.position, Vector2.left, 0.1f);
            if (hit2.collider == null)
            {
                hit1.transform.GetComponent<Transform>().position = tileSpawn2.transform.position;
                hit3 = Physics2D.Raycast(tileSpawn3.position, Vector2.left, 0.1f);
                if (hit3.collider == null)
                {
                    hit1.transform.GetComponent<Transform>().position = tileSpawn3.transform.position;
                    hit4 = Physics2D.Raycast(tileSpawn4.position, Vector2.left, 0.1f);
                    if (hit4.collider == null)
                    {
                        hit1.transform.GetComponent<Transform>().position = tileSpawn4.transform.position;
                    }
                }
            }
        }
        hit1 = Physics2D.Raycast(tileSpawn5.position, Vector2.left, 0.1f);
        if (hit1.collider != null)
        {
            hit2 = Physics2D.Raycast(tileSpawn6.position, Vector2.left, 0.1f);
            if (hit2.collider == null)
            {
                hit1.transform.GetComponent<Transform>().position = tileSpawn6.transform.position;
                hit3 = Physics2D.Raycast(tileSpawn7.position, Vector2.left, 0.1f);
                if (hit3.collider == null)
                {
                    hit1.transform.GetComponent<Transform>().position = tileSpawn7.transform.position;
                    hit4 = Physics2D.Raycast(tileSpawn8.position, Vector2.left, 0.1f);
                    if (hit4.collider == null)
                    {
                        hit1.transform.GetComponent<Transform>().position = tileSpawn8.transform.position;
                    }
                }
            }
        }
        hit1 = Physics2D.Raycast(tileSpawn9.position, Vector2.left, 0.1f);
        if (hit1.collider != null)
        {
            hit2 = Physics2D.Raycast(tileSpawn10.position, Vector2.left, 0.1f);
            if (hit2.collider == null)
            {
                hit1.transform.GetComponent<Transform>().position = tileSpawn10.transform.position;
                hit3 = Physics2D.Raycast(tileSpawn11.position, Vector2.left, 0.1f);
                if (hit3.collider == null)
                {
                    hit1.transform.GetComponent<Transform>().position = tileSpawn11.transform.position;
                    hit4 = Physics2D.Raycast(tileSpawn12.position, Vector2.left, 0.1f);
                    if (hit4.collider == null)
                    {
                        hit1.transform.GetComponent<Transform>().position = tileSpawn12.transform.position;
                    }
                }
            }
        }
        hit1 = Physics2D.Raycast(tileSpawn13.position, Vector2.left, 0.1f);
        if (hit1.collider != null)
        {
            hit2 = Physics2D.Raycast(tileSpawn14.position, Vector2.left, 0.1f);
            if (hit2.collider == null)
            {
                hit1.transform.GetComponent<Transform>().position = tileSpawn14.transform.position;
                hit3 = Physics2D.Raycast(tileSpawn15.position, Vector2.left, 0.1f);
                if (hit3.collider == null)
                {
                    hit1.transform.GetComponent<Transform>().position = tileSpawn15.transform.position;
                    hit4 = Physics2D.Raycast(tileSpawn16.position, Vector2.left, 0.1f);
                    if (hit4.collider == null)
                    {
                        hit1.transform.GetComponent<Transform>().position = tileSpawn16.transform.position;
                    }
                }
            }
        }

    }
    void moveLeft()
    {
        RaycastHit2D hit1;
        RaycastHit2D hit2;
        RaycastHit2D hit3;
        RaycastHit2D hit4;
        RaycastHit2D hit;
        //first
        hit2 = Physics2D.Raycast(tileSpawn2.position, Vector2.left, 0.1f);
        if (hit2.collider != null)
        {
            hit = Physics2D.Raycast(tileSpawn1.position, Vector2.left, 0.1f);
            if (hit.collider == null)
            {
                hit2.transform.GetComponent<Transform>().position = tileSpawn1.transform.position;
            }
            else
            {
                Destroy(hit2.transform.GetComponent<GameObject>());
                hit.transform.GetComponent<TileInfo>().IncrementValue();
            }
        }
        hit2 = Physics2D.Raycast(tileSpawn6.position, Vector2.left, 0.1f);
        if (hit2.collider != null)
        {
            hit = Physics2D.Raycast(tileSpawn5.position, Vector2.left, 0.1f);
            if (hit.collider == null)
            {
                hit2.transform.GetComponent<Transform>().position = tileSpawn5.transform.position;
            }
            else
            {
                Destroy(hit2.transform.GetComponent<GameObject>());
                hit.transform.GetComponent<TileInfo>().IncrementValue();
            }
        }
        hit2 = Physics2D.Raycast(tileSpawn9.position, Vector2.left, 0.1f);
        if (hit2.collider != null)
        {
            hit = Physics2D.Raycast(tileSpawn10.position, Vector2.left, 0.1f);
            if (hit.collider == null)
            {
                hit2.transform.GetComponent<Transform>().position = tileSpawn11.transform.position;
            }
            else
            {
                Destroy(hit2.transform.GetComponent<GameObject>());
                hit.transform.GetComponent<TileInfo>().IncrementValue();
            }
        }
        hit2 = Physics2D.Raycast(tileSpawn13.position, Vector2.left, 0.1f);
        if (hit2.collider != null)
        {
            hit = Physics2D.Raycast(tileSpawn14.position, Vector2.left, 0.1f);
            if (hit.collider == null)
            {
                hit2.transform.GetComponent<Transform>().position = tileSpawn14.transform.position;
            }
            else
            {
                Destroy(hit2.transform.GetComponent<GameObject>());
                hit.transform.GetComponent<TileInfo>().IncrementValue();
            }
        }
        //second
        Physics.SyncTransforms();
        hit2 = Physics2D.Raycast(tileSpawn3.position, Vector2.left, 0.1f);
        if (hit2.collider != null)
        {
            hit = Physics2D.Raycast(tileSpawn2.position, Vector2.left, 0.1f);
            if (hit.collider == null)
            {
                hit2.transform.GetComponent<Transform>().position = tileSpawn2.transform.position;
                hit = Physics2D.Raycast(tileSpawn1.position, Vector2.left, 0.1f);
                if (hit.collider == null)
                {
                    hit2.transform.GetComponent<Transform>().position = tileSpawn1.transform.position;
                }
            }
            else
            {
                Destroy(hit2.transform.GetComponent<GameObject>());
                hit.transform.GetComponent<TileInfo>().IncrementValue();
                hit2.transform.GetComponent<Transform>().position = tileSpawn9.transform.position;
                hit = Physics2D.Raycast(tileSpawn13.position, Vector2.left, 0.1f);
                if (hit.collider == null)
                {
                    hit2.transform.GetComponent<Transform>().position = tileSpawn13.transform.position;
                }
            }
        }
        hit2 = Physics2D.Raycast(tileSpawn7.position, Vector2.left, 0.1f);
        if (hit2.collider != null)
        {
            hit = Physics2D.Raycast(tileSpawn6.position, Vector2.left, 0.1f);
            if (hit.collider == null)
            {
                hit2.transform.GetComponent<Transform>().position = tileSpawn6.transform.position;
                hit = Physics2D.Raycast(tileSpawn5.position, Vector2.left, 0.1f);
                if (hit.collider == null)
                {
                    hit2.transform.GetComponent<Transform>().position = tileSpawn5.transform.position;
                }
            }
            else
            {
                Destroy(hit2.transform.GetComponent<GameObject>());
                hit.transform.GetComponent<TileInfo>().IncrementValue();
                hit2.transform.GetComponent<Transform>().position = tileSpawn9.transform.position;
                hit = Physics2D.Raycast(tileSpawn13.position, Vector2.left, 0.1f);
                if (hit.collider == null)
                {
                    hit2.transform.GetComponent<Transform>().position = tileSpawn13.transform.position;
                }
            }
        }
        hit2 = Physics2D.Raycast(tileSpawn11.position, Vector2.left, 0.1f);
        if (hit2.collider != null)
        {
            hit = Physics2D.Raycast(tileSpawn10.position, Vector2.left, 0.1f);
            if (hit.collider == null)
            {
                hit2.transform.GetComponent<Transform>().position = tileSpawn10.transform.position;
                hit = Physics2D.Raycast(tileSpawn9.position, Vector2.left, 0.1f);
                if (hit.collider == null)
                {
                    hit2.transform.GetComponent<Transform>().position = tileSpawn9.transform.position;
                }
            }
            else
            {
                Destroy(hit2.transform.GetComponent<GameObject>());
                hit.transform.GetComponent<TileInfo>().IncrementValue();
                hit2.transform.GetComponent<Transform>().position = tileSpawn9.transform.position;
                hit = Physics2D.Raycast(tileSpawn13.position, Vector2.left, 0.1f);
                if (hit.collider == null)
                {
                    hit2.transform.GetComponent<Transform>().position = tileSpawn13.transform.position;
                }
            }
        }
        hit2 = Physics2D.Raycast(tileSpawn15.position, Vector2.left, 0.1f);
        if (hit2.collider != null)
        {
            hit = Physics2D.Raycast(tileSpawn14.position, Vector2.left, 0.1f);
            if (hit.collider == null)
            {
                hit2.transform.GetComponent<Transform>().position = tileSpawn14.transform.position;
                hit = Physics2D.Raycast(tileSpawn13.position, Vector2.left, 0.1f);
                if (hit.collider == null)
                {
                    hit2.transform.GetComponent<Transform>().position = tileSpawn13.transform.position;
                }
            }
            else
            {
                Destroy(hit2.transform.GetComponent<GameObject>());
                hit.transform.GetComponent<TileInfo>().IncrementValue();
                hit2.transform.GetComponent<Transform>().position = tileSpawn9.transform.position;
                hit = Physics2D.Raycast(tileSpawn13.position, Vector2.left, 0.1f);
                if (hit.collider == null)
                {
                    hit2.transform.GetComponent<Transform>().position = tileSpawn13.transform.position;
                }
            }
        }
        //third
        Physics.SyncTransforms();
        hit1 = Physics2D.Raycast(tileSpawn4.position, Vector2.left, 0.1f);
        if (hit1.collider != null)
        {
            hit2 = Physics2D.Raycast(tileSpawn3.position, Vector2.left, 0.1f);
            if (hit2.collider == null)
            {
                hit1.transform.GetComponent<Transform>().position = tileSpawn3.transform.position;
                hit3 = Physics2D.Raycast(tileSpawn2.position, Vector2.left, 0.1f);
                if (hit3.collider == null)
                {
                    hit1.transform.GetComponent<Transform>().position = tileSpawn2.transform.position;
                    hit4 = Physics2D.Raycast(tileSpawn1.position, Vector2.left, 0.1f);
                    if (hit4.collider == null)
                    {
                        hit1.transform.GetComponent<Transform>().position = tileSpawn1.transform.position;
                    }
                }
            }
        }
        hit1 = Physics2D.Raycast(tileSpawn8.position, Vector2.left, 0.1f);
        if (hit1.collider != null)
        {
            hit2 = Physics2D.Raycast(tileSpawn7.position, Vector2.left, 0.1f);
            if (hit2.collider == null)
            {
                hit1.transform.GetComponent<Transform>().position = tileSpawn7.transform.position;
                hit3 = Physics2D.Raycast(tileSpawn6.position, Vector2.left, 0.1f);
                if (hit3.collider == null)
                {
                    hit1.transform.GetComponent<Transform>().position = tileSpawn6.transform.position;
                    hit4 = Physics2D.Raycast(tileSpawn5.position, Vector2.left, 0.1f);
                    if (hit4.collider == null)
                    {
                        hit1.transform.GetComponent<Transform>().position = tileSpawn5.transform.position;
                    }
                }
            }
        }
        hit1 = Physics2D.Raycast(tileSpawn12.position, Vector2.left, 0.1f);
        if (hit1.collider != null)
        {
            hit2 = Physics2D.Raycast(tileSpawn11.position, Vector2.left, 0.1f);
            if (hit2.collider == null)
            {
                hit1.transform.GetComponent<Transform>().position = tileSpawn11.transform.position;
                hit3 = Physics2D.Raycast(tileSpawn10.position, Vector2.left, 0.1f);
                if (hit3.collider == null)
                {
                    hit1.transform.GetComponent<Transform>().position = tileSpawn10.transform.position;
                    hit4 = Physics2D.Raycast(tileSpawn9.position, Vector2.left, 0.1f);
                    if (hit4.collider == null)
                    {
                        hit1.transform.GetComponent<Transform>().position = tileSpawn9.transform.position;
                    }
                }
            }
        }
        hit1 = Physics2D.Raycast(tileSpawn16.position, Vector2.left, 0.1f);
        if (hit1.collider != null)
        {
            hit2 = Physics2D.Raycast(tileSpawn15.position, Vector2.left, 0.1f);
            if (hit2.collider == null)
            {
                hit1.transform.GetComponent<Transform>().position = tileSpawn15.transform.position;
                hit3 = Physics2D.Raycast(tileSpawn14.position, Vector2.left, 0.1f);
                if (hit3.collider == null)
                {
                    hit1.transform.GetComponent<Transform>().position = tileSpawn14.transform.position;
                    hit4 = Physics2D.Raycast(tileSpawn13.position, Vector2.left, 0.1f);
                    if (hit4.collider == null)
                    {
                        hit1.transform.GetComponent<Transform>().position = tileSpawn13.transform.position;
                    }
                }
            }
        }
    }
    void moveUp()
    {
        RaycastHit2D hit1;
        RaycastHit2D hit2;
        RaycastHit2D hit3;
        RaycastHit2D hit4;
        RaycastHit2D hit;
        //first
        hit2 = Physics2D.Raycast(tileSpawn5.position, Vector2.left, 0.1f);
        if (hit2.collider != null)
        {
            hit = Physics2D.Raycast(tileSpawn1.position, Vector2.left, 0.1f);
            if (hit.collider == null)
            {
                hit2.transform.GetComponent<Transform>().position = tileSpawn1.transform.position;
            }
            else
            {
                Destroy(hit2.transform.GetComponent<GameObject>());
                hit.transform.GetComponent<TileInfo>().IncrementValue();
            }
        }
        hit2 = Physics2D.Raycast(tileSpawn6.position, Vector2.left, 0.1f);
        if (hit2.collider != null)
        {
            hit = Physics2D.Raycast(tileSpawn2.position, Vector2.left, 0.1f);
            if (hit.collider == null)
            {
                hit2.transform.GetComponent<Transform>().position = tileSpawn2.transform.position;
            }
            else
            {
                Destroy(hit2.transform.GetComponent<GameObject>());
                hit.transform.GetComponent<TileInfo>().IncrementValue();
            }
        }
        hit2 = Physics2D.Raycast(tileSpawn7.position, Vector2.left, 0.1f);
        if (hit2.collider != null)
        {
            hit = Physics2D.Raycast(tileSpawn3.position, Vector2.left, 0.1f);
            if (hit.collider == null)
            {
                hit2.transform.GetComponent<Transform>().position = tileSpawn3.transform.position;
            }
            else
            {
                Destroy(hit2.transform.GetComponent<GameObject>());
                hit.transform.GetComponent<TileInfo>().IncrementValue();
            }
        }
        hit2 = Physics2D.Raycast(tileSpawn8.position, Vector2.left, 0.1f);
        if (hit2.collider != null)
        {
            hit = Physics2D.Raycast(tileSpawn4.position, Vector2.left, 0.1f);
            if (hit.collider == null)
            {
                hit2.transform.GetComponent<Transform>().position = tileSpawn4.transform.position;
            }
            else
            {
                Destroy(hit2.transform.GetComponent<GameObject>());
                hit.transform.GetComponent<TileInfo>().IncrementValue();
            }
        }
        //second
        Physics.SyncTransforms();
        hit2 = Physics2D.Raycast(tileSpawn9.position, Vector2.left, 0.1f);
        if (hit2.collider != null)
        {
            hit = Physics2D.Raycast(tileSpawn5.position, Vector2.left, 0.1f);
            if (hit.collider == null)
            {
                hit2.transform.GetComponent<Transform>().position = tileSpawn5.transform.position;
                hit = Physics2D.Raycast(tileSpawn1.position, Vector2.left, 0.1f);
                if (hit.collider == null)
                {
                    hit2.transform.GetComponent<Transform>().position = tileSpawn1.transform.position;
                }
            }
            else
            {
                Destroy(hit2.transform.GetComponent<GameObject>());
                hit.transform.GetComponent<TileInfo>().IncrementValue();
                hit2.transform.GetComponent<Transform>().position = tileSpawn9.transform.position;
                hit = Physics2D.Raycast(tileSpawn13.position, Vector2.left, 0.1f);
                if (hit.collider == null)
                {
                    hit2.transform.GetComponent<Transform>().position = tileSpawn13.transform.position;
                }
            }
        }
        hit2 = Physics2D.Raycast(tileSpawn10.position, Vector2.left, 0.1f);
        if (hit2.collider != null)
        {
            hit = Physics2D.Raycast(tileSpawn6.position, Vector2.left, 0.1f);
            if (hit.collider == null)
            {
                hit2.transform.GetComponent<Transform>().position = tileSpawn6.transform.position;
                hit = Physics2D.Raycast(tileSpawn2.position, Vector2.left, 0.1f);
                if (hit.collider == null)
                {
                    hit2.transform.GetComponent<Transform>().position = tileSpawn2.transform.position;
                }
            }
            else
            {
                Destroy(hit2.transform.GetComponent<GameObject>());
                hit.transform.GetComponent<TileInfo>().IncrementValue();
                hit2.transform.GetComponent<Transform>().position = tileSpawn9.transform.position;
                hit = Physics2D.Raycast(tileSpawn13.position, Vector2.left, 0.1f);
                if (hit.collider == null)
                {
                    hit2.transform.GetComponent<Transform>().position = tileSpawn13.transform.position;
                }
            }
        }
        hit2 = Physics2D.Raycast(tileSpawn11.position, Vector2.left, 0.1f);
        if (hit2.collider != null)
        {
            hit = Physics2D.Raycast(tileSpawn7.position, Vector2.left, 0.1f);
            if (hit.collider == null)
            {
                hit2.transform.GetComponent<Transform>().position = tileSpawn7.transform.position;
                hit = Physics2D.Raycast(tileSpawn3.position, Vector2.left, 0.1f);
                if (hit.collider == null)
                {
                    hit2.transform.GetComponent<Transform>().position = tileSpawn3.transform.position;
                }
            }
            else
            {
                Destroy(hit2.transform.GetComponent<GameObject>());
                hit.transform.GetComponent<TileInfo>().IncrementValue();
                hit2.transform.GetComponent<Transform>().position = tileSpawn9.transform.position;
                hit = Physics2D.Raycast(tileSpawn13.position, Vector2.left, 0.1f);
                if (hit.collider == null)
                {
                    hit2.transform.GetComponent<Transform>().position = tileSpawn13.transform.position;
                }
            }
        }
        hit2 = Physics2D.Raycast(tileSpawn12.position, Vector2.left, 0.1f);
        if (hit2.collider != null)
        {
            hit = Physics2D.Raycast(tileSpawn8.position, Vector2.left, 0.1f);
            if (hit.collider == null)
            {
                hit2.transform.GetComponent<Transform>().position = tileSpawn8.transform.position;
                hit = Physics2D.Raycast(tileSpawn4.position, Vector2.left, 0.1f);
                if (hit.collider == null)
                {
                    hit2.transform.GetComponent<Transform>().position = tileSpawn4.transform.position;
                }
            }
            else
            {
                Destroy(hit2.transform.GetComponent<GameObject>());
                hit.transform.GetComponent<TileInfo>().IncrementValue();
                hit2.transform.GetComponent<Transform>().position = tileSpawn9.transform.position;
                hit = Physics2D.Raycast(tileSpawn13.position, Vector2.left, 0.1f);
                if (hit.collider == null)
                {
                    hit2.transform.GetComponent<Transform>().position = tileSpawn13.transform.position;
                }
            }
        }
        //third
        Physics.SyncTransforms();
        hit1 = Physics2D.Raycast(tileSpawn13.position, Vector2.left, 0.1f);
        if (hit1.collider != null)
        {
            hit2 = Physics2D.Raycast(tileSpawn9.position, Vector2.left, 0.1f);
            if (hit2.collider == null)
            {
                hit1.transform.GetComponent<Transform>().position = tileSpawn9.transform.position;
                hit3 = Physics2D.Raycast(tileSpawn5.position, Vector2.left, 0.1f);
                if (hit3.collider == null)
                {
                    hit1.transform.GetComponent<Transform>().position = tileSpawn5.transform.position;
                    hit4 = Physics2D.Raycast(tileSpawn1.position, Vector2.left, 0.1f);
                    if (hit4.collider == null)
                    {
                        hit1.transform.GetComponent<Transform>().position = tileSpawn1.transform.position;
                    }
                }
            }
        }
        hit1 = Physics2D.Raycast(tileSpawn14.position, Vector2.left, 0.1f);
        if (hit1.collider != null)
        {
            hit2 = Physics2D.Raycast(tileSpawn10.position, Vector2.left, 0.1f);
            if (hit2.collider == null)
            {
                hit1.transform.GetComponent<Transform>().position = tileSpawn10.transform.position;
                hit3 = Physics2D.Raycast(tileSpawn6.position, Vector2.left, 0.1f);
                if (hit3.collider == null)
                {
                    hit1.transform.GetComponent<Transform>().position = tileSpawn6.transform.position;
                    hit4 = Physics2D.Raycast(tileSpawn2.position, Vector2.left, 0.1f);
                    if (hit4.collider == null)
                    {
                        hit1.transform.GetComponent<Transform>().position = tileSpawn2.transform.position;
                    }
                }
            }
        }
        hit1 = Physics2D.Raycast(tileSpawn15.position, Vector2.left, 0.1f);
        if (hit1.collider != null)
        {
            hit2 = Physics2D.Raycast(tileSpawn11.position, Vector2.left, 0.1f);
            if (hit2.collider == null)
            {
                hit1.transform.GetComponent<Transform>().position = tileSpawn11.transform.position;
                hit3 = Physics2D.Raycast(tileSpawn7.position, Vector2.left, 0.1f);
                if (hit3.collider == null)
                {
                    hit1.transform.GetComponent<Transform>().position = tileSpawn7.transform.position;
                    hit4 = Physics2D.Raycast(tileSpawn3.position, Vector2.left, 0.1f);
                    if (hit4.collider == null)
                    {
                        hit1.transform.GetComponent<Transform>().position = tileSpawn3.transform.position;
                    }
                }
            }
        }
        hit1 = Physics2D.Raycast(tileSpawn16.position, Vector2.left, 0.1f);
        if (hit1.collider != null)
        {
            hit2 = Physics2D.Raycast(tileSpawn12.position, Vector2.left, 0.1f);
            if (hit2.collider == null)
            {
                hit1.transform.GetComponent<Transform>().position = tileSpawn12.transform.position;
                hit3 = Physics2D.Raycast(tileSpawn8.position, Vector2.left, 0.1f);
                if (hit3.collider == null)
                {
                    hit1.transform.GetComponent<Transform>().position = tileSpawn8.transform.position;
                    hit4 = Physics2D.Raycast(tileSpawn4.position, Vector2.left, 0.1f);
                    if (hit4.collider == null)
                    {
                        hit1.transform.GetComponent<Transform>().position = tileSpawn4.transform.position;
                    }
                }
            }
        }
    }
    void moveDown()
    {
        RaycastHit2D hit1;
        RaycastHit2D hit2;
        RaycastHit2D hit3;
        RaycastHit2D hit4;
        RaycastHit2D hit;
        //first
        hit2 = Physics2D.Raycast(tileSpawn9.position, Vector2.left, 0.1f);
        if (hit2.collider != null)
        {
            hit = Physics2D.Raycast(tileSpawn13.position, Vector2.left, 0.1f);
            if (hit.collider == null)
            {
                hit2.transform.GetComponent<Transform>().position = tileSpawn13.transform.position;
            }
            else
            {
                Destroy(hit2.transform.GetComponent<GameObject>());
                hit.transform.GetComponent<TileInfo>().IncrementValue();
            }
        }
        hit2 = Physics2D.Raycast(tileSpawn10.position, Vector2.left, 0.1f);
        if (hit2.collider != null)
        {
            hit = Physics2D.Raycast(tileSpawn14.position, Vector2.left, 0.1f);
            if (hit.collider == null)
            {
                hit2.transform.GetComponent<Transform>().position = tileSpawn14.transform.position;
            }
            else
            {
                Destroy(hit2.transform.GetComponent<GameObject>());
                hit.transform.GetComponent<TileInfo>().IncrementValue();
            }
        }
        hit2 = Physics2D.Raycast(tileSpawn11.position, Vector2.left, 0.1f);
        if (hit2.collider != null)
        {
            hit = Physics2D.Raycast(tileSpawn15.position, Vector2.left, 0.1f);
            if (hit.collider == null)
            {
                hit2.transform.GetComponent<Transform>().position = tileSpawn15.transform.position;
            }
            else
            {
                Destroy(hit2.transform.GetComponent<GameObject>());
                hit.transform.GetComponent<TileInfo>().IncrementValue();
            }
        }
        hit2 = Physics2D.Raycast(tileSpawn12.position, Vector2.left, 0.1f);
        if (hit2.collider != null)
        {
            hit = Physics2D.Raycast(tileSpawn16.position, Vector2.left, 0.1f);
            if (hit.collider == null)
            {
                hit2.transform.GetComponent<Transform>().position = tileSpawn16.transform.position;
            }
            else
            {
                Destroy(hit2.transform.GetComponent<GameObject>());
                hit.transform.GetComponent<TileInfo>().IncrementValue();
            }
        }
        //second
        Physics.SyncTransforms();
        hit2 = Physics2D.Raycast(tileSpawn5.position, Vector2.left, 0.1f);
        if (hit2.collider != null)
        {
            hit = Physics2D.Raycast(tileSpawn9.position, Vector2.left, 0.1f);
            if (hit.collider == null)
            {
                hit2.transform.GetComponent<Transform>().position = tileSpawn9.transform.position;
                hit = Physics2D.Raycast(tileSpawn13.position, Vector2.left, 0.1f);
                if (hit.collider == null)
                {
                    hit2.transform.GetComponent<Transform>().position = tileSpawn13.transform.position;
                }
            }
            else
            {
                Destroy(hit2.transform.GetComponent<GameObject>());
                hit.transform.GetComponent<TileInfo>().IncrementValue();
                hit2.transform.GetComponent<Transform>().position = tileSpawn9.transform.position;
                hit = Physics2D.Raycast(tileSpawn13.position, Vector2.left, 0.1f);
                if (hit.collider == null)
                {
                    hit2.transform.GetComponent<Transform>().position = tileSpawn13.transform.position;
                }
            }
        }
        hit2 = Physics2D.Raycast(tileSpawn6.position, Vector2.left, 0.1f);
        if (hit2.collider != null)
        {
            hit = Physics2D.Raycast(tileSpawn10.position, Vector2.left, 0.1f);
            if (hit.collider == null)
            {
                hit2.transform.GetComponent<Transform>().position = tileSpawn10.transform.position;
                hit = Physics2D.Raycast(tileSpawn14.position, Vector2.left, 0.1f);
                if (hit.collider == null)
                {
                    hit2.transform.GetComponent<Transform>().position = tileSpawn14.transform.position;
                }
            }
            else
            {
                Destroy(hit2.transform.GetComponent<GameObject>());
                hit.transform.GetComponent<TileInfo>().IncrementValue();
                hit2.transform.GetComponent<Transform>().position = tileSpawn9.transform.position;
                hit = Physics2D.Raycast(tileSpawn13.position, Vector2.left, 0.1f);
                if (hit.collider == null)
                {
                    hit2.transform.GetComponent<Transform>().position = tileSpawn13.transform.position;
                }
            }
        }
        hit2 = Physics2D.Raycast(tileSpawn7.position, Vector2.left, 0.1f);
        if (hit2.collider != null)
        {
            hit = Physics2D.Raycast(tileSpawn11.position, Vector2.left, 0.1f);
            if (hit.collider == null)
            {
                hit2.transform.GetComponent<Transform>().position = tileSpawn11.transform.position;
                hit = Physics2D.Raycast(tileSpawn15.position, Vector2.left, 0.1f);
                if (hit.collider == null)
                {
                    hit2.transform.GetComponent<Transform>().position = tileSpawn15.transform.position;
                }
            }
            else
            {
                Destroy(hit2.transform.GetComponent<GameObject>());
                hit.transform.GetComponent<TileInfo>().IncrementValue();
                hit2.transform.GetComponent<Transform>().position = tileSpawn9.transform.position;
                hit = Physics2D.Raycast(tileSpawn13.position, Vector2.left, 0.1f);
                if (hit.collider == null)
                {
                    hit2.transform.GetComponent<Transform>().position = tileSpawn13.transform.position;
                }
            }
        }
        hit2 = Physics2D.Raycast(tileSpawn8.position, Vector2.left, 0.1f);
        if (hit2.collider != null)
        {
            hit = Physics2D.Raycast(tileSpawn12.position, Vector2.left, 0.1f);
            if (hit.collider == null)
            {
                hit2.transform.GetComponent<Transform>().position = tileSpawn12.transform.position;
                hit = Physics2D.Raycast(tileSpawn16.position, Vector2.left, 0.1f);
                if (hit.collider == null)
                {
                    hit2.transform.GetComponent<Transform>().position = tileSpawn16.transform.position;
                }
            }
            else
            {
                Destroy(hit2.transform.GetComponent<GameObject>());
                hit.transform.GetComponent<TileInfo>().IncrementValue();
                hit2.transform.GetComponent<Transform>().position = tileSpawn9.transform.position;
                hit = Physics2D.Raycast(tileSpawn13.position, Vector2.left, 0.1f);
                if (hit.collider == null)
                {
                    hit2.transform.GetComponent<Transform>().position = tileSpawn13.transform.position;
                }
            }
        }
        //third
        Physics.SyncTransforms();
        hit1 = Physics2D.Raycast(tileSpawn1.position, Vector2.left, 0.1f);
        if (hit1.collider != null)
        {
            hit2 = Physics2D.Raycast(tileSpawn5.position, Vector2.left, 0.1f);
            if (hit2.collider == null)
            {
                hit1.transform.GetComponent<Transform>().position = tileSpawn5.transform.position;
                hit3 = Physics2D.Raycast(tileSpawn9.position, Vector2.left, 0.1f);
                if (hit3.collider == null)
                {
                    hit1.transform.GetComponent<Transform>().position = tileSpawn9.transform.position;
                    hit4 = Physics2D.Raycast(tileSpawn13.position, Vector2.left, 0.1f);
                    if (hit4.collider == null)
                    {
                        hit1.transform.GetComponent<Transform>().position = tileSpawn13.transform.position;
                    }
                }
            }
        }
        hit1 = Physics2D.Raycast(tileSpawn2.position, Vector2.left, 0.1f);
        if (hit1.collider != null)
        {
            hit2 = Physics2D.Raycast(tileSpawn6.position, Vector2.left, 0.1f);
            if (hit2.collider == null)
            {
                hit1.transform.GetComponent<Transform>().position = tileSpawn6.transform.position;
                hit3 = Physics2D.Raycast(tileSpawn10.position, Vector2.left, 0.1f);
                if (hit3.collider == null)
                {
                    hit1.transform.GetComponent<Transform>().position = tileSpawn10.transform.position;
                    hit4 = Physics2D.Raycast(tileSpawn14.position, Vector2.left, 0.1f);
                    if (hit4.collider == null)
                    {
                        hit1.transform.GetComponent<Transform>().position = tileSpawn14.transform.position;
                    }
                }
            }
        }
        hit1 = Physics2D.Raycast(tileSpawn3.position, Vector2.left, 0.1f);
        if (hit1.collider != null)
        {
            hit2 = Physics2D.Raycast(tileSpawn7.position, Vector2.left, 0.1f);
            if (hit2.collider == null)
            {
                hit1.transform.GetComponent<Transform>().position = tileSpawn7.transform.position;
                hit3 = Physics2D.Raycast(tileSpawn11.position, Vector2.left, 0.1f);
                if (hit3.collider == null)
                {
                    hit1.transform.GetComponent<Transform>().position = tileSpawn11.transform.position;
                    hit4 = Physics2D.Raycast(tileSpawn15.position, Vector2.left, 0.1f);
                    if (hit4.collider == null)
                    {
                        hit1.transform.GetComponent<Transform>().position = tileSpawn15.transform.position;
                    }
                }
            }
        }
        hit1 = Physics2D.Raycast(tileSpawn4.position, Vector2.left, 0.1f);
        if (hit1.collider != null)
        {
            hit2 = Physics2D.Raycast(tileSpawn8.position, Vector2.left, 0.1f);
            if (hit2.collider == null)
            {
                hit1.transform.GetComponent<Transform>().position = tileSpawn8.transform.position;
                hit3 = Physics2D.Raycast(tileSpawn12.position, Vector2.left, 0.1f);
                if (hit3.collider == null)
                {
                    hit1.transform.GetComponent<Transform>().position = tileSpawn12.transform.position;
                    hit4 = Physics2D.Raycast(tileSpawn16.position, Vector2.left, 0.1f);
                    if (hit4.collider == null)
                    {
                        hit1.transform.GetComponent<Transform>().position = tileSpawn16.transform.position;
                    }
                }
            }
        }
    }
}


