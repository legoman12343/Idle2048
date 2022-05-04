using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileColliding : MonoBehaviour
{
    public bool colliding;
    
    void Start()
    {
        colliding = false;
    }

    // Update is called once per frame
    void OnTriggerStay(Collider c)
    {
        
        Debug.Log("ASDFG");
        colliding = true;
        
    }

    void OnTriggerExit(Collider c)
    {

        colliding = false;
        
    }
}
