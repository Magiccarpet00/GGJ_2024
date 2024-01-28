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
	[SerializeField] private GameObject carBounce;
	[SerializeField] private GameObject winScreen;

	[SerializeField] private AudioSource introClip;
	[SerializeField] private AudioSource loop;
	[SerializeField] private AudioSource win;
	[SerializeField] private AudioSource lose;

	// Start is called before the first frame update
	void Start()
    {
		close.FinishClosing += Close_FinishClosing;
    }

	private void Close_FinishClosing()
	{
		intro.gameObject.SetActive(true);
		intro.OnFinish += Intro_OnFinish;
		CarSoundManager.instance.Play(introClip);
	}

	private void Intro_OnFinish()
	{
		intro.gameObject.SetActive(false);
		CarSoundManager.instance.Play(player.engine);
		StartCoroutine(MovePlayer());
		
	}

	IEnumerator Timer(float timer)
	{
		yield return new WaitForSeconds(timer);

		CarSoundManager.instance.Play(win);

		player.gameObject.SetActive(false);
		roads.StopRoad();
		carBounce.SetActive(true);
		winScreen.SetActive(true);
		winScreen.transform.GetChild(0).GetComponent<WinScreen>().OnWin += CarsGameManager_OnWin;
	}

	private void CarsGameManager_OnWin()
	{
		StartCoroutine(WaitBeforeLoading());
		winScreen.transform.GetChild(0).GetComponent<WinScreen>().OnWin -= CarsGameManager_OnWin;
		
	}

	IEnumerator WaitBeforeLoading()
	{
		yield return new WaitForSeconds(2);
		Win();
	}

	private void StartGame()
	{
		roads.Init();
		roads.OnCollide += Roads_OnCollide;
		player.AnimEnded += Player_AnimEnded;
	}

	private void Player_AnimEnded()
	{
		CarSoundManager.instance.Play(lose);
		Lose();
	}

	private void Roads_OnCollide()
	{
		player.Death();
	}

	IEnumerator MovePlayer()
	{
		while(elapsedTime < moveDuration)
		{
			elapsedTime += Time.deltaTime;
			player.transform.position = Vector3.MoveTowards(player.transform.position, startPos, elapsedTime / moveDuration);
			yield return null;
		}


		yield return new WaitForSeconds(2);;
		StartGame();

	}

	
}
