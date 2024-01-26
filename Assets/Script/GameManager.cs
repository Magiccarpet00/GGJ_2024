using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [SerializeField] List<MiniGameTrigger> miniGameTriggers = new List<MiniGameTrigger>();
    private void Awake()
    {
        instance = this;
        foreach (MiniGameTrigger item in miniGameTriggers)
        {
            item.loadMiniGame += TriggerLoadMiniGame;
        }
    }

    private void TriggerLoadMiniGame(MiniGameName obj)
    {
        
    }


}

public enum MiniGameName
{
    CARS,
    FIGHT,
    FIND
}