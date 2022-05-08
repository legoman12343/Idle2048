using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Swipe : MonoBehaviour
{
    private Vector2 startPos;
    private Vector2 endPos;
    public GameManager gm;

    private Vector2 Rightvec = new Vector2(1.7f, 0);
    private Vector2 Leftvec = new Vector2(-1.7f, 0);
    private Vector2 Upvec = new Vector2(0, 1.7f);
    private Vector2 Downvec = new Vector2(0, -1.7f);

    private int dragDistance;

    public bool canSwipe;

    void Start()
    {
        dragDistance = Screen.height * 15 / 100;
        canSwipe = true;
    }

    void Update()
    {
        if (canSwipe)
        {
            if (Input.touchCount > 0)
            {
                Debug.Log("ASD");
            }
            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
            {
                startPos = Input.GetTouch(0).position;
            }
            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
            {

                endPos = Input.GetTouch(0).position;
                if (startPos.x > endPos.x && startPos.x - endPos.x > dragDistance)

                {
                    gm.direction = Leftvec;
                    gm.hasMoved = true;
                }
                else if (startPos.x < endPos.x && endPos.x - startPos.x > dragDistance)
                {
                    gm.direction = Rightvec;
                    gm.hasMoved = true;
                }
                else if (startPos.y > endPos.y && startPos.y - endPos.y > dragDistance)
                {
                    gm.direction = Downvec;
                    gm.hasMoved = true;
                }
                else if (startPos.y < endPos.y && endPos.y - startPos.y > dragDistance)
                {
                    gm.direction = Upvec;
                    gm.hasMoved = true;
                }




            }
        }
    }
}