using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Cul : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    Image assetImage;
    bool isClicked = false;
    Color currentColor;

    // Start is called before the first frame update
    void Start()
    {
        assetImage = gameObject.GetComponent<Image>();
        currentColor = assetImage.color;

    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (isClicked == false)
        {
            Color newColor = new Color(currentColor.r, currentColor.g, currentColor.b, 1.0f); // 1.0f représente l'alpha complet
            assetImage.color = newColor;
           
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (isClicked == false)
        {
            assetImage.color = currentColor;
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        isClicked = !isClicked;
       

        if (isClicked == true)
        {
            Color newColor = Color.blue;
            assetImage.color = newColor;

            parentScript.instance.firstGameObjectClicked = gameObject; //soucis
            Debug.Log(parentScript.instance.firstGameObjectClicked.tag);

            if (parentScript.instance.firstGameObjectClicked != null)
            {
                parentScript.instance.secondGameObjectClicked = gameObject;
                Debug.Log(parentScript.instance.secondGameObjectClicked.tag);
            }
        }

        if (isClicked == false)
        {
            assetImage.color = currentColor;
        }
 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   
}
