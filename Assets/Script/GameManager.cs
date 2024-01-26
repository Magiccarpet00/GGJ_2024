using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Transform player;
    public static GameManager instance;
    private Vector3 mainScenePos;
    [SerializeField] List<MiniGameTrigger> miniGameTriggers = new List<MiniGameTrigger>();
    private void Awake()
    {
        instance = this;
        foreach (MiniGameTrigger item in miniGameTriggers)
        {
            item.loadMiniGame += TriggerLoadMiniGame;
        }
		

        DontDestroyOnLoad(gameObject);
    }

	private void Start()
	{
        SceneLoader.instance.MainSceneLoaded += SceneLoader_MainSceneLoaded;
    }

	private void SceneLoader_MainSceneLoaded()
	{
        player.position = mainScenePos;
	}

	private void TriggerLoadMiniGame(MiniGameName obj)
    {
        mainScenePos = player.position;
        SceneLoader.instance.LoadMiniGame(obj);
        StartCoroutine(WaitMiniGameTime());
    }

	IEnumerator WaitMiniGameTime()
	{
        yield return new WaitForSeconds(5);

        SceneLoader.instance.LoadMainScene();
	}
}

public enum MiniGameName
{
    CARS,
    FIGHT,
    FIND
}