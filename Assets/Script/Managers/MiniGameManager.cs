using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGameManager : MonoBehaviour
{
    public event Action OnLose;
    public event Action OnWin;


    public IEnumerator Test()
    {
        yield return new WaitForSeconds(3);

        OnWin?.Invoke();
    }
}
