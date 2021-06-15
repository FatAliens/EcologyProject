using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using DG.Tweening;
using UnityEngine;

public class MoreInfoConroller : MonoBehaviour
{
    private CanvasGroup canvas;
    void Start()
    {
        canvas = GetComponent<CanvasGroup>();
        canvas.alpha = 0;
    }

    public void OnClick()
    {
        canvas.DOFade(1, 2);
    }
}
