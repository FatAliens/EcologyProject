using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

public class MouseMoveRotator : MonoBehaviour
{
    public Vector2 RotationSpeed;
    private Transform tr;
    private Vector2 mousePos;
    private Vector3 startRotation;
    void Start()
    {
        tr = transform;
        startRotation = tr.rotation.eulerAngles;
    }

    void Update()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    private void FixedUpdate()
    {
        tr.rotation = Quaternion.Euler(startRotation.x + (mousePos.y * RotationSpeed.x), startRotation.y + (-mousePos.x * RotationSpeed.y), startRotation.z);
    }
}
