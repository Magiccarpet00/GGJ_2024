using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadManager : MonoBehaviour
{
	[SerializeField] private float roadTravelSpeed;
	[SerializeField] private float nbrOfRoadPortion;
	[SerializeField] private Transform roadStartPoint;
	[SerializeField] private RoadDetector roadEndPoint;

	private List<Road> roads = new List<Road>();

	public void Init()
	{
		Road currentRoad = null;
		for (int i = 0; i < nbrOfRoadPortion; i++)
		{
			currentRoad = transform.GetChild(i).GetComponent<Road>();
			if (i > 2) currentRoad.Init();
			roads.Add(currentRoad);
		}

		roadEndPoint.OnRoadCollide += RoadEndPoint_OnRoadCollide;
	}

	private void RoadEndPoint_OnRoadCollide(Road obj)
	{
		roads.Remove(obj);
		obj.transform.position = roadStartPoint.position;
		roads.Add(obj);
		obj.Init();
	}

	// Update is called once per frame
	void Update()
    {
		foreach (Road road in roads)
		{
			MoveRoad(road.transform);
		}
    }

	private void MoveRoad(Transform road)
	{
		road.position += -Vector3.forward * roadTravelSpeed * Time.deltaTime;
	}
}
