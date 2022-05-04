using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateTile : MonoBehaviour
{
    public GameObject tile;

    private Transform[] tileTransform;

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

    void Start()
    {
        tileTransform = new Transform[16];
        tileTransform[0] = tileSpawn1;
        tileTransform[1] = tileSpawn2;
        tileTransform[2] = tileSpawn3;
        tileTransform[3] = tileSpawn4;
        tileTransform[4] = tileSpawn5;
        tileTransform[5] = tileSpawn6;
        tileTransform[6] = tileSpawn7;
        tileTransform[7] = tileSpawn8;
        tileTransform[8] = tileSpawn9;
        tileTransform[9] = tileSpawn10;
        tileTransform[10] = tileSpawn11;
        tileTransform[11] = tileSpawn12;
        tileTransform[12] = tileSpawn13;
        tileTransform[13] = tileSpawn14;
        tileTransform[14] = tileSpawn15;
        tileTransform[15] = tileSpawn16; 
    }

    public void PlaceTile()
    {
        int random = 1;
        bool check = false;
        random = Random.Range(0, 16);
        RaycastHit2D hit = Physics2D.Raycast(tileTransform[random].position, Vector2.up, 0.01f);
        if (hit.collider != null)
        {
            check = true;
            Debug.Log("HIT");
        }else
        {
            Debug.Log("MISS");
        }
        /*
        while (check == false)
        {
            
        }
        */
        Instantiate(tile, tileTransform[random].position, tileTransform[random].rotation);
    }
}
