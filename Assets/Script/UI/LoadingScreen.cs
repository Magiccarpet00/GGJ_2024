using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadingScreen : MonoBehaviour
{
	public event Action StartLoading;
	public event Action FinishClosing;
	private Animator animator;
	private void Awake()
	{
		animator = GetComponent<Animator>();
	}
	
    public void StartLoad()
	{
		StartLoading?.Invoke();
	}

	public void OnClose()
	{
		FinishClosing?.Invoke();
		gameObject.SetActive(false);
	}

	public void ChangeState(bool isClosing)
	{ 
		animator.SetBool("Close", isClosing);
	}
}
