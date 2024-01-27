using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] private List<GameObject> differentsVisuals;
    public void SetupObstacle()
	{
		ResetObstacles();
        int index = Random.Range(0, differentsVisuals.Count);
        transform.GetChild(index).gameObject.SetActive(true);
	}

    private void ResetObstacles()
	{
		for (int i = 0; i < transform.childCount; i++)
		{
			transform.GetChild(i).gameObject.SetActive(true);
		}
	}
}
