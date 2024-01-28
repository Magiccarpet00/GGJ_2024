using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainSoundManager : MonoBehaviour
{
	public static MainSoundManager instance;

	private void Awake()
	{
		instance = this;
	}

	public void Play(AudioSource clipToPlay)
	{
		clipToPlay.Play();
	}

	public void Stop(AudioSource clipToStop)
	{
		clipToStop.Stop();
	}
}
