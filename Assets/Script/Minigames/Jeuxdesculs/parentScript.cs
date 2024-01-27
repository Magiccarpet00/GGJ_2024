using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class parentScript : MonoBehaviour
{
    public static parentScript instance;

    public string assetTag;

    public GameObject firstGameObjectClicked;
    public GameObject secondGameObjectClicked;

    public bool clickPossible;



    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {

        if (firstGameObjectClicked != null && secondGameObjectClicked != null && firstGameObjectClicked.tag == secondGameObjectClicked.tag)
        {
            firstGameObjectClicked.GetComponent<Animator>().SetBool("Disapear",true);
            secondGameObjectClicked.GetComponent<Animator>().SetBool("Disapear",true);

        }
        if(firstGameObjectClicked != null && secondGameObjectClicked != null && firstGameObjectClicked.tag != secondGameObjectClicked.tag) 
        {
            firstGameObjectClicked.GetComponent<Animator>().SetBool("NotMatch",true);
            secondGameObjectClicked.GetComponent<Animator>().SetBool("NotMatch",true);
        }
    }

    public void DetectObjectClicked(GameObject objectClicked)
    {
        if(firstGameObjectClicked == null)
        {
            firstGameObjectClicked = objectClicked;
        }
        else
        {
            secondGameObjectClicked = objectClicked;
        }
    }

    public void DeleteObjectClicked(GameObject objecDeclicked)
    {
        if (firstGameObjectClicked == objecDeclicked)
        {
            firstGameObjectClicked = null;
        }
        if (secondGameObjectClicked == objecDeclicked)
        {
            secondGameObjectClicked = null;
        }
    }

    public void EndAnimation()
    {
        if (!firstGameObjectClicked && !secondGameObjectClicked) return;

        firstGameObjectClicked.GetComponent<Animator>().SetBool("NotMatch", false);
        secondGameObjectClicked.GetComponent<Animator>().SetBool("NotMatch", false);

    }
}
