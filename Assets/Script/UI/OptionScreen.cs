using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionScreen : MonoBehaviour
{
    [SerializeField] private GameObject titleScreen;
    [SerializeField] private GameObject optionScreen;
    [SerializeField] private GameObject commandScreen;
    [SerializeField] private LoadingScreen loadingScreen;
    // Start is called before the first frame update
    void OnEnable()
    {
        loadingScreen.GetComponent<Image>().fillAmount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
