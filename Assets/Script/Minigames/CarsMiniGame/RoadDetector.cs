using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadDetector : MonoBehaviour
{
	public event Action<Road> OnRoadCollide;

	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Road"))
		{
			OnRoadCollide?.Invoke(other.GetComponent<Road>());
		}
	}
}
