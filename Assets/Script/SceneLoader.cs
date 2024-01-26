using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    private const string MAIN_SCENE = "MainScene";

    public event Action MainSceneLoaded;

    public static SceneLoader instance;

    private void Awake()
    {
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void LoadMainScene()
	{
        StartCoroutine(UnloadAsync(SceneManager.GetActiveScene()));
        StartCoroutine(LoadAsync(MAIN_SCENE));
    }

	IEnumerator UnloadAsync(Scene currentScene)
	{
        AsyncOperation async = SceneManager.UnloadSceneAsync(currentScene);

        while(!async.isDone)
		{
            yield return null;
		}
	}

	public void LoadMiniGame(MiniGameName miniGameName)
    {
        StartCoroutine(LoadAsync(miniGameName.ToString()));
    }

    IEnumerator LoadAsync(string sceneToLoad)
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneToLoad);

        while (!asyncLoad.isDone)
        {
            switch(sceneToLoad)
			{
                case MAIN_SCENE:
                    MainSceneLoaded?.Invoke();
                    break;
			}
            yield return null;
        }

    }
}
