using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGameTrigger : MonoBehaviour
{
    [SerializeField] private GameObject linkedDoor;
    public MiniGameName gameName;
    public event Action<MiniGameName, MiniGameTrigger> loadMiniGame;
    public Transform returnPostion;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            loadMiniGame?.Invoke(gameName, this);
            //gameObject.SetActive(false);
        }
    }

	private void OnDestroy()
	{
        linkedDoor.GetComponent<Door>()?.Open();
	}
}
