using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetect : MonoBehaviour
{
	public event Action OnCollide;
	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Player"))
		{
			OnCollide?.Invoke();
			
		}
	}
}
