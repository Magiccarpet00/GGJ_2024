using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarsGameManager : MiniGameManager
{
    

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Test());   
    }

}
