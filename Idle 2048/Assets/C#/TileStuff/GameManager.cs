using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private float width = 1.7f;
    private float height = 1.7f;
    [SerializeField] private Node nodePrefab;

    void Start()
    {
        makeGrid();
    }

    void makeGrid()
    {
        for (int x = 0; x < 4; x++)
        {
            for (int y = 0; y < 4; y++)
            {
                var node = Instantiate(nodePrefab,new Vector2(x*width - 5f,y* height-2f),Quaternion.identity);
                Debug.Log("NODE");
            }
        }
    }
}
