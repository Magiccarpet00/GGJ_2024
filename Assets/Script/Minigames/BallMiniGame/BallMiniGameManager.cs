using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class BallMiniGameManager : MiniGameManager
{
    public static BallMiniGameManager instance;
    [SerializeField] private bool win;
    public bool lose;
    [SerializeField] private float miniGameTime;

    [HideInInspector] public bool gameStarted;

    [SerializeField] private BallMcFirst ball;

    public GameObject prefabBras;

    private void Awake()
    {
        instance = this;
    }

    public void StartGame()
    {
        gameStarted = true;
        StartCoroutine(Chronos());
    }
    
    public void PreLose()
    {
        if (win == false)
        {
            lose = true;
            Lose();
        }
    }   

    private IEnumerator Chronos()
    {
        yield return new WaitForSeconds(miniGameTime);
        
        if(lose == false)
        {
            win = true;
            Win();
        }
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.R)) // CODE TMP
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
