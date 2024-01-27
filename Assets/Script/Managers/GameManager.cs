using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private GameObject cam;
    [SerializeField] List<MiniGameTrigger> miniGameTriggers = new List<MiniGameTrigger>();
    [SerializeField] LoadingScreen loadingScreenOpen;
    [SerializeField] LoadingScreen loadingScreenClose;
    public static GameManager instance;

    private MiniGameName currentMiniGame;
	private Vector3 mainScenePos;
	private MiniGameManager currentMiniGameManager;
    private bool isWin;
    GameObject triggerToDestroy = null;
    MiniGameTrigger currentLoopGameObject = null;

    private Dictionary<MiniGameName, int> difficultyDictionary = new Dictionary<MiniGameName, int>();

    private void Awake()
    {
        instance = this;
        foreach (MiniGameTrigger item in miniGameTriggers)
        {
            item.loadMiniGame += TriggerLoadMiniGame;
        }

        difficultyDictionary.Add(MiniGameName.CARS, 0);
        difficultyDictionary.Add(MiniGameName.FIGHT, 0);
        difficultyDictionary.Add(MiniGameName.FIND, 0);
    }

	private void SceneLoader_SceneLoaded(GameObject[] mainScene, GameObject[] miniGame)
	{
		foreach (GameObject item in mainScene)
		{
            item.SetActive(item.name == gameObject.name);
  		}

        loadingScreenOpen.gameObject.SetActive(true);

        currentMiniGameManager = miniGame[0].GetComponent<MiniGameManager>();
        currentMiniGameManager.difficultyParameter = difficultyDictionary[currentMiniGame];
		currentMiniGameManager.OnWin += CurrentMiniGameManager_OnWin;
		currentMiniGameManager.OnLose += CurrentMiniGameManager_OnLose;
        SceneLoader.instance.SceneLoaded -= SceneLoader_SceneLoaded;

    }

	private void CurrentMiniGameManager_OnLose()
	{
        isWin = false;
        cam.SetActive(true);
        loadingScreenOpen.gameObject.SetActive(false);
        SceneLoader.instance.LoadMainScene();
        SceneLoader.instance.SceneUnloaded += Instance_SceneUnloaded;
    }

	private void TriggerLoadMiniGame(MiniGameName obj)
    {
        currentMiniGame = obj;
        mainScenePos = player.position;
        loadingScreenOpen.gameObject.SetActive(true);
		loadingScreenOpen.StartLoading += LoadingScreenOpen_StartLoading_MiniGame;
    }

	private void LoadingScreenOpen_StartLoading_MiniGame()
	{

        loadingScreenOpen.StartLoading -= LoadingScreenOpen_StartLoading_MiniGame;
        SceneLoader.instance.LoadMiniGame(currentMiniGame);
        SceneLoader.instance.SceneLoaded += SceneLoader_SceneLoaded;

    }

	private void CurrentMiniGameManager_OnWin()
	{
        isWin = true;
        cam.SetActive(true);
        loadingScreenOpen.gameObject.SetActive(false);
        SceneLoader.instance.LoadMainScene();
        SceneLoader.instance.SceneUnloaded += Instance_SceneUnloaded;
	}

	private void LoadingScreenClose_FinishClosing() 
	{

        if (triggerToDestroy)
        {
            miniGameTriggers.Remove(currentLoopGameObject);
            Destroy(triggerToDestroy);
        }

        loadingScreenClose.gameObject.SetActive(false);

        loadingScreenClose.FinishClosing -= LoadingScreenClose_FinishClosing;
    }

	private void Instance_SceneUnloaded(GameObject[] gameObjects)
    {
        
        foreach (GameObject item in gameObjects)
        {
            if (item.name == "AllMiniGameTriggers" && isWin)
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
                difficultyDictionary[currentMiniGame] += 1;
            }
            else
            {
                item.SetActive(true);
            }

        }
        player.gameObject.SetActive(false);
        StartCoroutine(WaitforCloseLoading(triggerToDestroy, currentLoopGameObject));

    }

    IEnumerator WaitforCloseLoading(GameObject gameObject, MiniGameTrigger gameTrigger)
	{
        loadingScreenClose.gameObject.SetActive(true);
        loadingScreenClose.FinishClosing += LoadingScreenClose_FinishClosing;
        SceneLoader.instance.SceneUnloaded -= Instance_SceneUnloaded;
        
        yield return new WaitForSeconds(0.3f);

        player.gameObject.SetActive(true);
    }
}

public enum MiniGameName
{
    CARS,
    FIGHT,
    FIND
}