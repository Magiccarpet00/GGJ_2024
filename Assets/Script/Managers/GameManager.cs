using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private Transform triggerContainer;
    [SerializeField] private GameObject cam;
    [SerializeField] List<MiniGameTrigger> miniGameTriggers = new List<MiniGameTrigger>();
    [SerializeField] LoadingScreen loadingScreenOpen;
    [SerializeField] LoadingScreen loadingScreenClose;
    [SerializeField] public GameObject endScreen;
    [SerializeField] private float delayBetweenAmbients = 10f;
    [SerializeField] private Transform allAmbients;
    [SerializeField] private AudioSource ambience;
    [SerializeField] private AudioSource kiss;
    [SerializeField] private AudioSource neon;
    [SerializeField] public AudioSource fin;

    public static GameManager instance;

    private MiniGameName currentMiniGame;
    private Vector3 mainScenePos;
    private MiniGameManager currentMiniGameManager;
    private bool isWin;
    GameObject triggerToDestroy = null;
    MiniGameTrigger currentLoopGameObject = null;
    public bool playAmbientSound = true;

    private Dictionary<MiniGameName, MiniGameTrigger> triggers = new Dictionary<MiniGameName, MiniGameTrigger>();


	private void Awake()
    {
        instance = this;
        foreach (MiniGameTrigger item in miniGameTriggers)
        {
            item.loadMiniGame += TriggerLoadMiniGame;
        }

		foreach (MiniGameTrigger item in miniGameTriggers)
		{
            triggers.Add(item.gameName, item);
		}

        MainSoundManager.instance.Play(ambience);
        AmbientSounds();
    }

    private void AmbientSounds()
	{
        if(playAmbientSound)
        {
            MainSoundManager.instance.Play(ChooseAmbient());
            StartCoroutine(InBetweenAmbients(delayBetweenAmbients));
        }
       
	}

    public void StopSounds()
    {
        playAmbientSound = false;

        MainSoundManager.instance.Stop(ambience);
        MainSoundManager.instance.Stop(kiss);
        MainSoundManager.instance.Stop(neon);
    }

    IEnumerator InBetweenAmbients (float timer)
    {
        yield return new WaitForSeconds(timer);

        AmbientSounds();
    }

    private AudioSource ChooseAmbient()
	{
        return allAmbients.GetChild(UnityEngine.Random.Range(0, allAmbients.childCount)).GetComponent<AudioSource>();
	}

	private void SceneLoader_SceneLoaded(GameObject[] mainScene, GameObject[] miniGame)
	{
        MiniGameManager memory;
        
		foreach (GameObject item in mainScene)
		{
            item.SetActive(item.name == gameObject.name);
  		}


        loadingScreenOpen.gameObject.SetActive(true);

        foreach (GameObject item in miniGame)
        {
            if (item.TryGetComponent<MiniGameManager>(out memory))
                currentMiniGameManager = memory;
        }

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

	private void TriggerLoadMiniGame(MiniGameName obj, MiniGameTrigger sender)
    {
        currentMiniGame = obj;
        mainScenePos = sender.returnPostion.position;
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
            item.SetActive(true);
        }

        triggers[currentMiniGame].gameObject.SetActive(!isWin);
        triggers[currentMiniGame].OpenDoor(isWin);
        player.gameObject.SetActive(false);
        StartCoroutine(WaitforCloseLoading(triggerToDestroy, currentLoopGameObject));

    }

    IEnumerator WaitforCloseLoading(GameObject gameObject, MiniGameTrigger gameTrigger)
	{
        loadingScreenClose.gameObject.SetActive(true);
        loadingScreenClose.FinishClosing += LoadingScreenClose_FinishClosing;
        SceneLoader.instance.SceneUnloaded -= Instance_SceneUnloaded;
        
        yield return new WaitForSeconds(0.3f);
        
        player.position = mainScenePos;
        player.gameObject.SetActive(true);
        if(isWin) player.GetComponent<PlayerMovement>().SetAnimWin();
        AmbientSounds();

    }
}

public enum MiniGameName
{
    CARS,
    FIGHT,
    FIND,
    MCFIRST
}