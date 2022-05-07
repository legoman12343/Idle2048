using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;

public class FloatingText : MonoBehaviour
{
    private TextMeshPro _text;
    private float travelTime = 1.3f;
    public Transform endPoint;

    public void Init(int value)
    {
        _text = GetComponent<TextMeshPro>();
        
        _text.text = value.ToString();

        var sequence = DOTween.Sequence();

        sequence.Insert(0, _text.transform.DOMove(endPoint.position, travelTime).SetEase(Ease.InQuad));

        sequence.OnComplete(() => Destroy(gameObject));
    }
}