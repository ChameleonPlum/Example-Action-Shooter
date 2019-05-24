using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class JoystickRotation : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler
{
    public static Vector3 inputVector = Vector3.zero;

    private Vector3 startMousePos = Vector3.zero;
    private Vector3 targetMousePos;

    public void OnDrag(PointerEventData eventData)
    {
        targetMousePos = Input.mousePosition;

        Vector3 direction = (targetMousePos - startMousePos).normalized;
        direction.z = 0;
        inputVector = new Vector3(-direction.y, direction.x, 0);

        startMousePos = targetMousePos;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        startMousePos = Input.mousePosition;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        inputVector = Vector3.zero;
    }
    
}
