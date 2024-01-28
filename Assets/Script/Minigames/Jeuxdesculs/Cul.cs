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
        if (parentScript.instance.clickPossible == true)
        {
            isClicked = !isClicked;


            if (isClicked == true)
            {
                Color newColor = Color.gray;
                assetImage.color = newColor;

                parentScript.instance.DetectObjectClicked(gameObject);


            }

            if (isClicked == false)
            {
                parentScript.instance.DeleteObjectClicked(gameObject);

                assetImage.color = currentColor;
            }
        }
            
    }

    public void disableClick()
    {
        parentScript.instance.clickPossible = false;
    }

    public void ableClick()
    {
        parentScript.instance.clickPossible = true;
    }

    public void DestroyImage()
    {
        parentScript.instance.winSound.Play();
        Destroy(this.gameObject);
    }

    public void DontMatchImage()
    {
        parentScript.instance.looseSound.Play();
        assetImage.color = currentColor;
        isClicked = false;

        parentScript.instance.EndAnimation();

        parentScript.instance.firstGameObjectClicked = null;
        parentScript.instance.secondGameObjectClicked = null;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

   
}
