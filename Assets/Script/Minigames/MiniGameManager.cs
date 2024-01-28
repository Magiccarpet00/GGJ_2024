using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGameManager : MonoBehaviour
{
    [SerializeField] protected LoadingScreen close;
    [SerializeField] protected LoadingScreen open;
    public event Action OnLose;
    public event Action OnWin;
	public int difficultyParameter;

	private void Awake()
	{

	}

	public void Win()
	{
		open.gameObject.SetActive(true);
		open.StartLoading += Open_Win;
    }

	private void Open_Win()
	{
		OnWin?.Invoke();
	}

	public virtual void Lose()
	{
		open.gameObject.SetActive(true);
		open.StartLoading += Open_Lose;
	}

	private void Open_Lose()
	{
		OnLose?.Invoke();
	}

}
