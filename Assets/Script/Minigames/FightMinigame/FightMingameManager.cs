using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FightMingameManager : MiniGameManager
{

    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip audioClip;
    [SerializeField] private AudioClip audioPunch;

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

    [SerializeField] private GameObject prefabWord;
    [SerializeField] private Transform pos1, pos2;

    [SerializeField] private float[] lvl; //attention yen a que 4

    private void Start()
    {
        damageEnemie = lvl[difficultyParameter];
        StartCoroutine(AutoPunch());
        audioSource.PlayOneShot(audioClip);
    }

    public IEnumerator AutoPunch()
    {
        yield return new WaitForSeconds(0.3f + Random.Range(-0.2f, 0.2f));

        if (winner == 0)
        {
            enemie.SetTrigger("punch");
            TakeDamage(1);
            audioSource.PlayOneShot(audioPunch);
            StartCoroutine(AutoPunch());
        }
        
    }

    private void TakeDamage(int character)
    {
        if (winner != 0)
            return;

        if(character == 1)
        {
            lifePlayer -= damageEnemie;

            if (lifePlayer <= 0)
            {
                lifePlayer = 0;
                winner = 2;

                player.SetTrigger("hurt");
                Lose();
            }

            playerBar.value = lifePlayer;

            Instantiate(prefabWord, pos1.position, Quaternion.identity);

        }
        else if(character == 2)
        {
            lifeEnemie -= damagePlayer;

            if (lifeEnemie <= 0)
            {
                lifeEnemie = 0;
                winner = 1;

                enemie.SetTrigger("hurt");
                Win();
            }

            enemieBar.value = lifeEnemie;

            Instantiate(prefabWord, pos2.position, Quaternion.identity);
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
