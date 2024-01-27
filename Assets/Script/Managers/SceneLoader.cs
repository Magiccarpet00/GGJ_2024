using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{

    public event Action<GameObject[], GameObject[]> SceneLoaded;
    public event Action<GameObject[]> SceneUnloaded;

    public static SceneLoader instance;

    private string addedScene;
    private GameObject[] mainSceneObject;

    

    private void Awake()
    {
        instance = this;
        mainSceneObject = SceneManager.GetActiveScene().GetRootGameObjects();

    }

    public void LoadMainScene()
	{
        StartCoroutine(UnloadAsync(addedScene));
    }


	public void LoadMiniGame(MiniGameName miniGameName)
    {
        addedScene = miniGameName.ToString();
        StartCoroutine(LoadAsync(addedScene));
    }

    IEnumerator LoadAsync(string sceneToLoad)
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneToLoad, LoadSceneMode.Additive);
        

        while (!asyncLoad.isDone)
        {
            asyncLoad.completed += AsyncLoad_completed;
            yield return null;
        }

    }

    IEnumerator UnloadAsync(string sceneToUnload)
	{
        AsyncOperation asyncUnload = SceneManager.UnloadSceneAsync(sceneToUnload);

        while(!asyncUnload.isDone)
		{
			asyncUnload.completed += AsyncUnload_completed;
            yield return null;
        }

        
	}

	private void AsyncUnload_completed(AsyncOperation obj)
	{
        obj.completed -= AsyncUnload_completed;
        SceneUnloaded?.Invoke(mainSceneObject);
    }

	private void AsyncLoad_completed(AsyncOperation obj)
	{
        obj.completed -= AsyncLoad_completed;
        SceneLoaded?.Invoke(mainSceneObject, SceneManager.GetSceneAt(1).GetRootGameObjects());
    }
}
