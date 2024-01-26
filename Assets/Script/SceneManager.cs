using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManager : MonoBehaviour
{
    public static SceneManager instance;
    private void Awake()
    {
        instance = this;
    }

    public void LoadMiniGame(MiniGameName miniGameName)
    {
        
    }

}
