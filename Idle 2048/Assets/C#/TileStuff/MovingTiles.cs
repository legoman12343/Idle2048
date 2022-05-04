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


    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("d")){ moveRight();}
        if(Input.GetKeyDown("a")){moveLeft();}
        if(Input.GetKeyDown("w")){ moveUp();}
        if(Input.GetKeyDown("s")){ moveDown();}
    }

    void moveRight()
    {
        RaycastHit2D hit1;
        RaycastHit2D hit2;
        RaycastHit2D hit3;
        RaycastHit2D hit4;
        RaycastHit2D hit;
        Debug.Log("RIGHT");
        hit3 = Physics2D.Raycast(tileSpawn3.position, Vector2.left, 0.1f);
        if(hit3.collider != null)
        {
            hit = Physics2D.Raycast(tileSpawn4.position, Vector2.left, 0.1f);
            if(hit.collider == null)
            {
                hit3.transform.GetComponent<Transform>().position = tileSpawn4.transform.position;
            }
        }

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
        }

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

    }
    void moveLeft()
    {

    }
    void moveUp()
    {

    }
    void moveDown()
    {

    }
}
