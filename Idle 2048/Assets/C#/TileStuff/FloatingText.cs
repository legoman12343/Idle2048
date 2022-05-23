using System.Collections;
using System.Numerics;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class FloatingText : MonoBehaviour
{
    private TextMeshPro _text;
    private float travelTime = 1.0f;
    public Transform endPoint;
    private Color32 Red = new Color32(255, 0, 0, 255);
    public FormatNumber fn;

    public void Init(BigInteger value, bool hitCrit)
    {

        _text = GetComponent<TextMeshPro>();

        _text.text = fn.formatNumberBigNumber(value,false);

        if (hitCrit) _text.color = Red;
        
        var sequence = DOTween.Sequence();

        sequence.Insert(0, _text.transform.DOMove(new Vector3(endPoint.position.x, endPoint.position.y+0.8f, endPoint.position.z), travelTime).SetEase(Ease.InQuad));

        sequence.OnComplete(() => Destroy(gameObject));
    }
}