using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinScreen : MonoBehaviour
{
	public event Action OnWin;
	private int countLoop = 0;
	[SerializeField] private int maxLoopCompleted;

	public void OnLoopCompleted()
	{
		countLoop++;

		if (countLoop == maxLoopCompleted)
			OnWin?.Invoke();

	}
}
