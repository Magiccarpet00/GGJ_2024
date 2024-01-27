using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank : MonoBehaviour
{
	private void OnEnable()
	{

		transform.GetChild(Random.Range(0, 2)).gameObject.SetActive(true);

	}

	private void OnDisable()
	{
		for (int i = 0; i < transform.childCount; i++)
		{
			transform.GetChild(i).gameObject.SetActive(false);
		}
	}
}
