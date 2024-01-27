using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tutoScript : MonoBehaviour
{
    private void Awake()
    {
        
    }
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Animator>().SetBool("tuto", true);
        StartCoroutine(falseCoroutine());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator falseCoroutine()
    {
        yield return new WaitForSeconds(1.2f);
        GetComponent<Animator>().SetBool("tuto", false);
    
    }
}
