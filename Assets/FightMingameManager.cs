using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FightMingameManager : MonoBehaviour
{
    
    [SerializeField] private Animator player;
    [SerializeField] private Animator enemie;

    // 0 => mini jeu en cours
    // 1 => player win
    // 2 => enemie win
    private int winner = 0;

    private float lifePlayer = 100f;
    private float lifeEnemie = 100f;

    [SerializeField] private Slider playerBar;
    [SerializeField] private Slider enemieBar;

    [SerializeField] private float damagePlayer;
    [SerializeField] private float damageEnemie;

    private void Start()
    {
        StartCoroutine(AutoPunch());
    }

    public IEnumerator AutoPunch()
    {
        yield return new WaitForSeconds(0.3f + Random.Range(-0.2f, 0.1f));

        if (winner == 0)
        {
            enemie.SetTrigger("punch");
            TakeDamage(1);
            StartCoroutine(AutoPunch());
        }
    }

    private void TakeDamage(int character)
    {
        

        if(character == 1)
        {
            lifePlayer -= damageEnemie;

            if (lifePlayer <= 0)
            {
                lifePlayer = 0;
                winner = 2;
            }

            playerBar.value = lifePlayer;

        }
        else if(character == 2)
        {
            lifeEnemie -= damagePlayer;

            if (lifeEnemie <= 0)
            {
                lifeEnemie = 0;
                winner = 1;
            }

            enemieBar.value = lifeEnemie;
        }

    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            player.SetTrigger("punch");
            TakeDamage(2);
        }
    }
}
