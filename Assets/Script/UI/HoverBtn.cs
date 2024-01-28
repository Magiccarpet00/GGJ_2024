using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class HoverBtn : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
	[SerializeField] private Sprite hoverSprite;
    private Sprite baseSprite;
    private Image image;

	public void OnPointerEnter(PointerEventData eventData)
	{
		image.sprite = hoverSprite;
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		image.sprite = baseSprite;
	}

	// Start is called before the first frame update
	void Start()
    {
        image = GetComponent<Image>();
        baseSprite = image.sprite;
    }
}
