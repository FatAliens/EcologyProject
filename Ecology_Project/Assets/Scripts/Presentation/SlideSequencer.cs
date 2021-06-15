using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using DG.Tweening;

public class SlideSequencer : MonoBehaviour
{
    [Serializable]
    public class Slide
    {
        public GameObject canvas;
        public GameObject model;
        public float scale;
    }
    [Tooltip("0 - first slide")] [SerializeField]
    private int startSlideIndex;

    [SerializeField] private bool isLoop;

    [SerializeField] public List<Slide> slides = new List<Slide>();
    private int currentPanelIndex;

    private void Start()
    {
        foreach (var slide in slides)
        {
            slide.scale = slide.model.transform.localScale.x;
        }
        
        currentPanelIndex = startSlideIndex;
        slides.ForEach((slide) => slide.canvas.GetComponent<CanvasGroup>().alpha = 0);
        slides.ForEach((slide) => slide.canvas.SetActive(false));
        slides[currentPanelIndex].canvas.SetActive(true);
        slides[currentPanelIndex].canvas.GetComponent<CanvasGroup>().DOFade(1, 0.6f);
        
        slides.ForEach(slide=> slide.model.transform.localScale = Vector3.zero);
        slides[currentPanelIndex].model.transform.DOScale(slides[currentPanelIndex].scale, 1).SetEase(Ease.OutElastic);
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
            slides[selectedIndex].canvas.SetActive(true);
            //tween sequence
            var sequence = DOTween.Sequence();
            
            sequence.Append(slides[currentPanelIndex].canvas.transform.DOScale(0.8f, 0.3f));
            sequence.Join(slides[currentPanelIndex].canvas.GetComponent<CanvasGroup>().DOFade(0, 0.3f));
            sequence.Join(slides[currentPanelIndex].model.transform.DOScale(0, 0.5f));
            
            sequence.Append(slides[selectedIndex].canvas.transform.DOScale(1, 0.3f).From(0.5f));
            sequence.Join(slides[selectedIndex].canvas.GetComponent<CanvasGroup>().DOFade(1, 0.3f).From(0));
            sequence.Join(slides[selectedIndex].model.transform.DOScale(slides[selectedIndex].scale, 1).SetEase(Ease.OutElastic, 0.01f));
            sequence.Play();
            slides[currentPanelIndex].canvas.SetActive(false);
            currentPanelIndex = selectedIndex;
        }
    }
}