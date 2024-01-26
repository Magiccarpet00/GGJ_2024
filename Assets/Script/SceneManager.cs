using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager : MonoBehaviour
{
    public static SceneManager instance;
    private void Awake()
    {
        instance = this;
    }



}
