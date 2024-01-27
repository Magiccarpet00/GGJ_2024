using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Intro : MonoBehaviour
{
	public event Action OnFinish;

    public void FinishIntro()
	{
		OnFinish?.Invoke();
	}
}
