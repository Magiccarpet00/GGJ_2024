using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
	public event Action OnCollide;

    [SerializeField] private List<GameObject> differentsVisuals;
    public void SetupObstacle()
	{
		ResetObstacles();
        int index = UnityEngine.Random.Range(0, differentsVisuals.Count);
        transform.GetChild(index).gameObject.SetActive(true);
	}

    private void ResetObstacles()
	{
		for (int i = 0; i < transform.childCount; i++)
		{
			transform.GetChild(i).gameObject.SetActive(false);
			transform.GetChild(i).GetComponent<PlayerDetect>().OnCollide += Obstacle_OnCollide;
		}
	}

	private void Obstacle_OnCollide()
	{
		OnCollide?.Invoke();
	}
}
