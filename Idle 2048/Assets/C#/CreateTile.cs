using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateTile : MonoBehaviour
{
    public GameObject tile;
    public Transform tileSpawn;

    public void PlaceTile()
    {
        Instantiate(tile, tileSpawn.position, tileSpawn.rotation);
    }
}
