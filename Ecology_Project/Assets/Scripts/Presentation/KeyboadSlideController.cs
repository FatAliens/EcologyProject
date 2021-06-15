using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class KeyboadSlideController : MonoBehaviour
{
    public UnityEvent LeftSlide;
    public UnityEvent RightSlide;
    public UnityEvent FirstSlide;
    public UnityEvent<int> ChangeSlideWithNumber;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
        {
            LeftSlide.Invoke();
        }

        if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
        {
            RightSlide.Invoke();
        }

        if (Input.GetKeyDown(KeyCode.Alpha0) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            FirstSlide.Invoke();
        }

        if (Input.GetKeyDown(KeyCode.Alpha1)) ChangeSlideWithNumber.Invoke(1);
        if (Input.GetKeyDown(KeyCode.Alpha2)) ChangeSlideWithNumber.Invoke(2);
        if (Input.GetKeyDown(KeyCode.Alpha3)) ChangeSlideWithNumber.Invoke(3);
        if (Input.GetKeyDown(KeyCode.Alpha4)) ChangeSlideWithNumber.Invoke(4);
        if (Input.GetKeyDown(KeyCode.Alpha5)) ChangeSlideWithNumber.Invoke(5);
        if (Input.GetKeyDown(KeyCode.Alpha6)) ChangeSlideWithNumber.Invoke(6);
        if (Input.GetKeyDown(KeyCode.Alpha7)) ChangeSlideWithNumber.Invoke(7);
        if (Input.GetKeyDown(KeyCode.Alpha8)) ChangeSlideWithNumber.Invoke(8);
        if (Input.GetKeyDown(KeyCode.Alpha9)) ChangeSlideWithNumber.Invoke(9);
    }
}