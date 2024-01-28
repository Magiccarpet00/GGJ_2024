using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerFin : MonoBehaviour
{
    [SerializeField] PlayerMovement playerMovement;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            GameManager.instance.StopSounds();
            GameManager.instance.fin.Play();
            GameManager.instance.endScreen.SetActive(true);
            playerMovement.inputFreeze = true;
        }
     
    }




}
