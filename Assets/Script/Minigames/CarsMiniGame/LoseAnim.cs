using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseAnim : MonoBehaviour
{
	public event Action OnEnd;
    public void EndAnim()
	{
		OnEnd?.Invoke();
	}
}
