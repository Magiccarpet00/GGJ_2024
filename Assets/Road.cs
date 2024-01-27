using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Road : MonoBehaviour
{
    [SerializeField] private List<GameObject> obstaclePosition = new List<GameObject>();

	public void Init()
	{
		foreach (GameObject item in obstaclePosition)
		{
			item.SetActive(false);
		}
		SetObstacles();
	}

	private void SetObstacles()
	{
		for (int i = 0; i < 2; i++)
		{
			obstaclePosition[Random.Range(0, 3)].SetActive(true);
		}
	}
    
}
