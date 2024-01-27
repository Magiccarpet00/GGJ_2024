using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadingScreen : MonoBehaviour
{
	private Animator animator;
	private void Start()
	{
		animator = GetComponent<Animator>();
	}
	public event Action StartLoading;
    public void StartLoad()
	{
		StartLoading?.Invoke();
	}

	public void OnClose()
	{
		gameObject.SetActive(false);
	}

	public void ChangeState(bool isClosing)
	{
		animator.SetBool("Close", isClosing);
	}
}
