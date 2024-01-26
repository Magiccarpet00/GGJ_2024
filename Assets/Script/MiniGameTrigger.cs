using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGameTrigger : MonoBehaviour
{
    public MiniGameName gameName;
    public event Action<MiniGameName> loadMiniGame;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            loadMiniGame?.Invoke(gameName);
            gameObject.SetActive(false);
        }
    }
}
