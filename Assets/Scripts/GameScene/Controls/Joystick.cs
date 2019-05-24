using UnityEngine;
using UnityEngine.EventSystems;
using System;
using UnityEngine.Events;


public class Joystick : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler
{
	[Header("Options")]
	[Range(0f, 2f)] public float handleLimit = 1f;

    private static Vector2 inputVector = Vector2.zero;

	[Header("Components")]
	public RectTransform background;
	public RectTransform handle;

	public static float getHorizontal { get { return inputVector.x; } }
	public static float getVertical { get { return inputVector.y; } }

    private Vector2 joystickPosition = Vector2.zero;
	private Camera cam = new Camera();

	void Start()
	{
		joystickPosition = RectTransformUtility.WorldToScreenPoint (cam, background.position);     
	}

	public virtual void OnDrag(PointerEventData eventData)
	{
		Vector2 direction = eventData.position - joystickPosition;
		inputVector = (direction.magnitude > background.sizeDelta.x / 2f) ? direction.normalized : direction / (background.sizeDelta.x / 2f);
		handle.anchoredPosition = (inputVector * background.sizeDelta.x / 2f) * handleLimit;
	}

	public virtual void OnPointerDown(PointerEventData eventData)
	{
        OnDrag(eventData);
    }

	public virtual void OnPointerUp(PointerEventData eventData)
	{
        inputVector = Vector2.zero;
        handle.anchoredPosition = Vector2.zero;
    }
}
