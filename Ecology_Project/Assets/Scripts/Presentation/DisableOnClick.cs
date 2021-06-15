using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class DisableOnClick : MonoBehaviour
{
    private CanvasGroup canvas;
    void Start()
    {
        canvas = GetComponent<CanvasGroup>();
        canvas.alpha = 1;
    }

    public void OnClick()
    {
        canvas.DOFade(0, 0.5f);
    }
}
