using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;

public class PopUp : MonoBehaviour
{
    public GameObject obj;
    public TextMeshProUGUI text;
    public GameObject tickIMG;
    public GameObject errorIMG;
    public Transform endPoint;
    public Transform startPoint;
    public Transform transform;
    private float travelTime;

    public void Init(string _text, bool tick)
    {
        transform.position = startPoint.position;

        Debug.Log("INIT");
        travelTime = 1.5f;

        text.text = _text;

        if (tick) { tickIMG.SetActive(true); }
        else { errorIMG.SetActive(true); }

        var sequence = DOTween.Sequence();

        sequence.Insert(0, obj.transform.DOMove(new Vector3(endPoint.position.x, endPoint.position.y, endPoint.position.z), travelTime).SetEase(Ease.InQuad));

        sequence.OnComplete(() => StartCoroutine(finish()));
    }

    private IEnumerator finish()
    {
        yield return new WaitForSeconds(2.5f);

        var sequence = DOTween.Sequence();

        sequence.Insert(0, obj.transform.DOMove(new Vector3(startPoint.position.x, startPoint.position.y, startPoint.position.z), travelTime).SetEase(Ease.InQuad));

        sequence.OnComplete(() => Destroy(gameObject));
    }

}
