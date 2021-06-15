using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using DG.Tweening;

public class MouseEnterEffect : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private float factor;
    [SerializeField] private float duration;

    private Transform thisTransform;

    private void Start()
    {
        thisTransform = GetComponent<Transform>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        thisTransform.DOScale(factor, duration).SetEase(Ease.OutBounce);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        thisTransform.DOScale(1f, duration / 2).SetEase(Ease.OutBounce);
    }
}