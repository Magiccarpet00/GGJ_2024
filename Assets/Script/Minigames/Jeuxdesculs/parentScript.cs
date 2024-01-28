using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class parentScript : MiniGameManager
{
    public static parentScript instance;

    public string assetTag;

    public GameObject firstGameObjectClicked;
    public GameObject secondGameObjectClicked;

    Coroutine coroutineTimer;

    public float timer = 60;

    public GameObject canvas;

    GameObject currentCanvas;

    public bool clickPossible = true;

    public AudioSource winSound;
    public AudioSource looseSound;

    public bool hasWon = false;



    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        launchTimer(timer);
        setupLevel();

    }

    // Update is called once per frame
    void Update()
    {

        if (firstGameObjectClicked != null && secondGameObjectClicked != null && firstGameObjectClicked.tag == secondGameObjectClicked.tag)
        {
            firstGameObjectClicked.GetComponent<Animator>().SetBool("Disapear",true);
            secondGameObjectClicked.GetComponent<Animator>().SetBool("Disapear",true);


        }
        if (firstGameObjectClicked != null && secondGameObjectClicked != null && firstGameObjectClicked.tag != secondGameObjectClicked.tag) 
        {
            firstGameObjectClicked.GetComponent<Animator>().SetBool("NotMatch",true);
            secondGameObjectClicked.GetComponent<Animator>().SetBool("NotMatch",true);
        }

        if (currentCanvas.transform.childCount == 1)
        {
            StopCoroutine(coroutineTimer);
            hasWon = true;
            Win();
        }
    }

    private void setupLevel ()
    {
        currentCanvas = canvas;
        currentCanvas.SetActive(true);
    }

    private void launchTimer(float timer)
    {
        coroutineTimer = StartCoroutine(Timer(timer));
    }

    public void DetectObjectClicked(GameObject objectClicked)
    {
        if(clickPossible)
        {
            if (firstGameObjectClicked == null && clickPossible)
            {
                firstGameObjectClicked = objectClicked;
            }
            else
            {
                secondGameObjectClicked = objectClicked;
            }
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

    IEnumerator Timer(float timer)
    {
        yield return new WaitForSeconds(timer + 1.20f);
        Lose();
    }

    public void EndAnimation()
    {
        if (!firstGameObjectClicked && !secondGameObjectClicked) return;

        firstGameObjectClicked.GetComponent<Animator>().SetBool("NotMatch", false);
        secondGameObjectClicked.GetComponent<Animator>().SetBool("NotMatch", false);

    }

   
}
