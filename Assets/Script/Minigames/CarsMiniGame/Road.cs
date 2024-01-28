using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Road : MonoBehaviour
{
    [SerializeField] private List<GameObject> obstaclePosition = new List<GameObject>();
	public event System.Action OnCollide;

	public bool hasObstacles;

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
		GameObject currentObs;
		for (int i = 0; i < 2; i++)
		{
			currentObs = obstaclePosition[Random.Range(0, 3)];
			currentObs.transform.GetChild(0).GetComponent<Obstacle>().SetupObstacle();
			currentObs.transform.GetChild(0).GetComponent<Obstacle>().OnCollide += Road_OnCollide;
			currentObs.SetActive(true);
		}
	}

	public void StopObstacles()
    {
		foreach (GameObject item in obstaclePosition)
		{
			item.SetActive(false);
		}
	}

	private void Road_OnCollide()
	{
		OnCollide?.Invoke();
	}
}
