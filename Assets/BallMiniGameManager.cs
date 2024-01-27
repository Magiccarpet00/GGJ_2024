using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMiniGameManager : MiniGameManager
{
    public static BallMiniGameManager instance;
    private bool win;
    private bool lose;
    [SerializeField] private float miniGameTime;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
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
        win = true;
        if(lose == false)
            Win();
    }
}
