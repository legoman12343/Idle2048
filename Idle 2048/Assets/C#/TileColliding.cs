using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileColliding : MonoBehaviour
{
    public bool collider;
    

    // Update is called once per frame
    void TriggerEnter(Collider c)
    {
        collider = true;
    }

    void TriggerExit(Collider c)
    {
        collider = false;
    }
}
