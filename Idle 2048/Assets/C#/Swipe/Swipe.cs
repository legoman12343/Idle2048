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
    private bool hasMoved = false;

    void Start()
    {
        dragDistance = Screen.height * 10 / 600;
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
            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved && !hasMoved)
            {

                endPos = Input.GetTouch(0).position;
                if (startPos.x > endPos.x && startPos.x - endPos.x > dragDistance)

                {
                    gm.directionLeft();
                    hasMoved = true;
                }
                else if (startPos.x < endPos.x && endPos.x - startPos.x > dragDistance)
                {
                    gm.directionRight();
                    hasMoved = true;
                }
                else if (startPos.y > endPos.y && startPos.y - endPos.y > dragDistance)
                {
                    gm.directionDown();
                    hasMoved = true;
                }
                else if (startPos.y < endPos.y && endPos.y - startPos.y > dragDistance)
                {
                    gm.directionUp();
                    hasMoved = true;
                }




            } else if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
            {
                hasMoved = false;
            }
        }
    }
}