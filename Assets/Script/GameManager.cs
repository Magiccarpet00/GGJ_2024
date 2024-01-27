using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Transform player;
    public static GameManager instance;
    private Vector3 mainScenePos;
    [SerializeField] List<MiniGameTrigger> miniGameTriggers = new List<MiniGameTrigger>();
    [SerializeField] LoadingScreen loadingScreen;

    private MiniGameName currentMiniGame;

    private void Awake()
    {
        instance = this;
        foreach (MiniGameTrigger item in miniGameTriggers)
        {
            item.loadMiniGame += TriggerLoadMiniGame;
        }
    }

	private void Start()
	{
        
    }

	private void SceneLoader_SceneLoaded(GameObject[] gameObjects)
	{
		foreach (GameObject item in gameObjects)
		{
            item.SetActive(item.name == gameObject.name || item.name == loadingScreen.name);           

		}

        loadingScreen.ChangeState(true);
        SceneLoader.instance.SceneLoaded -= SceneLoader_SceneLoaded;
    }

	private void TriggerLoadMiniGame(MiniGameName obj)
    {
        currentMiniGame = obj;
        mainScenePos = player.position;
        loadingScreen.gameObject.SetActive(true);
		loadingScreen.StartLoading += LoadingScreen_StartLoading_MiniGame;
    }

	private void LoadingScreen_StartLoading_MiniGame()
	{

        loadingScreen.StartLoading -= LoadingScreen_StartLoading_MiniGame;
        SceneLoader.instance.LoadMiniGame(currentMiniGame);
        StartCoroutine(WaitMiniGameTime());
        SceneLoader.instance.SceneLoaded += SceneLoader_SceneLoaded;
    }

	IEnumerator WaitMiniGameTime()
	{
        yield return new WaitForSeconds(10);
        loadingScreen.gameObject.SetActive(true);
		loadingScreen.StartLoading += LoadingScreen_StartLoading_MainScene;

    }

	private void LoadingScreen_StartLoading_MainScene()
	{
        SceneLoader.instance.LoadMainScene();
		SceneLoader.instance.SceneUnloaded += Instance_SceneUnloaded;
	}

	private void Instance_SceneUnloaded(GameObject[] gameObjects)
	{
        foreach (GameObject item in gameObjects)
        {
            if (item.name == "AllMiniGameTriggers")
                item.SetActive(false);
            else
                item.SetActive(true);

        }

        loadingScreen.ChangeState(true);
        SceneLoader.instance.SceneUnloaded -= Instance_SceneUnloaded;
    }
}

public enum MiniGameName
{
    CARS,
    FIGHT,
    FIND
}