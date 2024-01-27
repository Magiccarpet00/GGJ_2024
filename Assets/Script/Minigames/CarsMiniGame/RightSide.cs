using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class RightSide : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public event Action<int> OnRight;

    public void OnPointerEnter(PointerEventData eventData)
    {
        OnRight?.Invoke(1);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        OnRight?.Invoke(0);
    }
}

