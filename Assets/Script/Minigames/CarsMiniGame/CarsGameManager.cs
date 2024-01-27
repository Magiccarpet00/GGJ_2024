using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarsGameManager : MiniGameManager
{
    [SerializeField] private Intro intro;
	[SerializeField] private Vector3 startPos;
	[SerializeField] private Car player;
	private float elapsedTime;
	[SerializeField] private float moveDuration;

	[SerializeField] private RoadManager roads;

	// Start is called before the first frame update
	void Start()
    {
		close.FinishClosing += Close_FinishClosing;
    }

	private void Close_FinishClosing()
	{
		intro.gameObject.SetActive(true);
		intro.OnFinish += Intro_OnFinish;
	}

	private void Intro_OnFinish()
	{
		intro.gameObject.SetActive(false);
		StartCoroutine(MovePlayer());
	}

	private void StartGame()
	{
		roads.Init();
	}

	IEnumerator MovePlayer()
	{
		while(elapsedTime < moveDuration)
		{
			elapsedTime += Time.deltaTime;
			player.transform.position = Vector3.MoveTowards(player.transform.position, startPos, elapsedTime / moveDuration);
			yield return null;
		}


		yield return new WaitForSeconds(2);

		StartGame();

	}

	
}
