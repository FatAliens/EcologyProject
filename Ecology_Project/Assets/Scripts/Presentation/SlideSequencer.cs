using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using DG.Tweening;

public class SlideSequencer : MonoBehaviour
{
    [Tooltip("0 - first slide")] [SerializeField]
    private int startSlideIndex;

    [SerializeField] private bool isLoop;

    private List<GameObject> slides = new List<GameObject>();
    private int currentPanelIndex;

    private void Start()
    {
        int childCount = transform.childCount;
        for (int i = 0; i < childCount; i++)
        {
            slides.Add(transform.GetChild(i).gameObject);
        }

        currentPanelIndex = startSlideIndex;
        slides.ForEach((slide) => slide.GetComponent<CanvasGroup>().alpha = 0);
        slides[currentPanelIndex].GetComponent<CanvasGroup>().DOFade(1, 0.6f);
    }

    public void FirstSlide() => ChangeSlide(0);

    public void NextSlide()
    {
        if (currentPanelIndex + 1 < slides.Count)
        {
            ChangeSlide(currentPanelIndex + 1);
        }
        else
        {
            if (isLoop)
            {
                FirstSlide();
            }
        }
    }

    public void PrevSlide()
    {
        if (currentPanelIndex - 1 >= 0)
        {
            ChangeSlide(currentPanelIndex - 1);
        }
    }

    public void SlideToNumber(int number)
    {
        number--;
        if (number >= 0 && number < slides.Count)
        {
            ChangeSlide(number);
        }
    }

    private void ChangeSlide(int selectedIndex)
    {
        if (selectedIndex != currentPanelIndex)
        {
            //tween sequence
            var sequence = DOTween.Sequence();
            sequence.Append(slides[currentPanelIndex].transform.DOScale(0.8f, 0.3f));
            sequence.Join(slides[currentPanelIndex].GetComponent<CanvasGroup>().DOFade(0, 0.3f));
            sequence.Append(slides[selectedIndex].transform.DOScale(1, 0.3f).From(0.5f));
            sequence.Join(slides[selectedIndex].GetComponent<CanvasGroup>().DOFade(1, 0.3f).From(0));
            sequence.Play();

            currentPanelIndex = selectedIndex;
        }
    }
}