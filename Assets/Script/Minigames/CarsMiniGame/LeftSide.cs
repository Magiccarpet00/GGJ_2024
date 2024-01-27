using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class LeftSide : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
	public event Action<int> OnLeft;

	public void OnPointerEnter(PointerEventData eventData)
	{
		OnLeft?.Invoke(-1);
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		OnLeft?.Invoke(0);
	}
}
