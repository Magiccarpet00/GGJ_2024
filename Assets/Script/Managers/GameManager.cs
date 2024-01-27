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
    private MiniGameManager currentMiniGameManager;

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

	private void SceneLoader_SceneLoaded(GameObject[] mainScene, GameObject[] miniGame)
	{
		foreach (GameObject item in mainScene)
		{
            item.SetActive(item.name == gameObject.name || item.name == loadingScreen.name);           

		}

        loadingScreen.ChangeState(true);
        currentMiniGameManager = miniGame[0].GetComponent<MiniGameManager>();
		currentMiniGameManager.OnWin += CurrentMiniGameManager_OnWin;
		currentMiniGameManager.OnLose += CurrentMiniGameManager_OnLose;
        SceneLoader.instance.SceneLoaded -= SceneLoader_SceneLoaded;
    }

	private void CurrentMiniGameManager_OnLose()
	{
		
	}

	private void CurrentMiniGameManager_OnWin()
	{
        loadingScreen.gameObject.SetActive(true);
        loadingScreen.StartLoading += LoadingScreen_StartLoading_MainScene;
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
        SceneLoader.instance.SceneLoaded += SceneLoader_SceneLoaded;
    }

	private void LoadingScreen_StartLoading_MainScene()
	{
        SceneLoader.instance.LoadMainScene();
		SceneLoader.instance.SceneUnloaded += Instance_SceneUnloaded;
	}

	private void Instance_SceneUnloaded(GameObject[] gameObjects)
	{
        GameObject triggerToDestroy = null;
        MiniGameTrigger currentLoopGameObject = null;
        foreach (GameObject item in gameObjects)
        {
            if (item.name == "AllMiniGameTriggers")
			{
                int childCount = item.transform.childCount;
				for (int i = 0; i < childCount; i++)
				{
                    currentLoopGameObject = item.transform.GetChild(i).GetComponent<MiniGameTrigger>();
                    if (currentLoopGameObject.gameName == currentMiniGame)
					{
                        triggerToDestroy = currentLoopGameObject.gameObject;
                        break;
					}
				}
			}
            else
                item.SetActive(true);

        }

        if (triggerToDestroy)
        {
            miniGameTriggers.Remove(currentLoopGameObject);
            Destroy(triggerToDestroy);
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