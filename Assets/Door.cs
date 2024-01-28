using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private GameObject open;
    [SerializeField] private GameObject close;

    public void Open()
    {
        close.SetActive(false);
        open.SetActive(true);
    }
}
