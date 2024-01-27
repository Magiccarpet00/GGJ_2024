using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class parentScript : MonoBehaviour
{
    public static parentScript instance;

    public string assetTag;

    public GameObject firstGameObjectClicked;
    public GameObject secondGameObjectClicked;

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
        if (firstGameObjectClicked != null && secondGameObjectClicked !=null && firstGameObjectClicked.tag == secondGameObjectClicked.tag)
        {
            Destroy(firstGameObjectClicked);
            Destroy(secondGameObjectClicked);
        }
    }
}
