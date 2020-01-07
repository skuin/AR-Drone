﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Joystick1 : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler
{
    private Image bgImg;
    private Image joystickImg;
    private Vector3 inputVector;

    // Start is called before the first frame update
    void Start()
    {
        bgImg = GetComponent<Image>();
        joystickImg = transform.GetChild(0).GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public virtual void OnDrag(PointerEventData ped)
    {
        Debug.Log("Joystick >>> OnDrag()");

        Vector2 pos;
        if(RectTransformUtility.ScreenPointToLocalPointInRectangle(bgImg.rectTransform
            , ped.position, ped.pressEventCamera, out pos))
        {
            pos.x = (pos.x / bgImg.rectTransform.sizeDelta.x);
            pos.y = (pos.y / bgImg.rectTransform.sizeDelta.y);
        }

        inputVector = new Vector3(pos.x * 2 + 1, pos.y * 2 - 1, 0);
        inputVector = (inputVector.magnitude > 1.0f) ? inputVector.normalized : inputVector;

        // Move Joystick Img
        joystickImg.rectTransform.anchoredPosition
            = new Vector3(inputVector.x * (bgImg.rectTransform.sizeDelta.x / 3)
            , inputVector.y * (bgImg.rectTransform.sizeDelta.y / 3));
    }

    public virtual void OnPointerDown(PointerEventData ped)
    {
        OnDrag(ped);
    }

    public virtual void OnPointerUp(PointerEventData ped)
    {
        inputVector = Vector3.zero;
        joystickImg.rectTransform.anchoredPosition = Vector3.zero;
    }

    // PlayerController 스크립트에서 inputVector.x 값 받기 위해 사용
    public float GetHorizonValue()
    {
        return inputVector.x;
    }

    // PlayerController 스크립트에서 inputVector.y 값 받기 위해 사용
    public float GetVerticalValue()
    {
        return inputVector.y;
    }
}
