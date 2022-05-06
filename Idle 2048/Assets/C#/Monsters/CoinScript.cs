using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class CoinScript : MonoBehaviour
{
    public Transform objTransform;
    private float timePast = 0;
    private Vector2 force;

    void Start()
    {
        StartCoroutine(init());
    }

    // Update is called once per frame
    public IEnumerator init()
    {
        float x, y;
        
        do
        {
            x = Random.Range(-1.2f, 1.2f);
        } while (x < 1f && x > -1f);
        y = Random.Range(1.5f, 2.5f);

        force = new Vector2(x,y);
        Rigidbody2D rb = this.GetComponent<Rigidbody2D>();
        rb.AddForce(force * 2f, ForceMode2D.Impulse);

        yield return new WaitForSeconds(Random.Range(0.7f, 1.2f));
        //rb.bodyType = RigidbodyType2D.Kinematic;
        yield return new WaitForSeconds(Random.Range(0.5f, 1.2f));
        Destroy(gameObject);
    }
}
