using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class timer : MonoBehaviour
{
    public Image cercleVert;

    public float temps;
    public float seconde;

    // Start is called before the first frame update
    void Start()
    {
        temps = parentScript.instance.timer;
        seconde = temps;
        StartCoroutine(startGame());
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }

    IEnumerator enleverDelImage()
    {
        yield return new WaitForSeconds(1f);

        if (parentScript.instance.hasWon == false)
        {
            seconde = seconde - 1;
            cercleVert.fillAmount = seconde / temps;

            if (temps != 0)
            {
                StartCoroutine(enleverDelImage());
            }
        }
       
    }

    IEnumerator startGame()
    {
        yield return new WaitForSeconds(1.20f);
        StartCoroutine(enleverDelImage());
    }
}
