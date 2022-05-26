using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class CoinScript : MonoBehaviour
{
    public Transform objTransform;
    private Vector2 force;

    void Start()
    {
        StartCoroutine(init());
    }

    // Update is called once per frame
    public IEnumerator init()
    {
        float x, y;
        
        do{ x = Random.Range(-1f, 1f);} while (x < 0.5f && x > -0.5f);

        y = Random.Range(11.5f, 13.5f);

        force = new Vector2(x,y);
        Rigidbody2D rb = this.GetComponent<Rigidbody2D>();
        rb.AddForce(force * 2f, ForceMode2D.Impulse);

        yield return new WaitForSeconds(Random.Range(0.7f, 1.2f));
        
        yield return new WaitForSeconds(Random.Range(0.5f, 1.2f));
        Destroy(gameObject);
    }
}
