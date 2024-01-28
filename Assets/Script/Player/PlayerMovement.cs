using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]private float speed;
    [SerializeField]private Animator animator;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform footsteps;
    private Vector2 movement;

	void Update()
    {


        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        if(movement.x != 0 || movement.y != 0)
		{
            int rand = UnityEngine.Random.Range(0, footsteps.childCount);
            AudioSource newFootstep = footsteps.GetChild(rand).GetComponent<AudioSource>();
            if (!newFootstep.isPlaying)
                MainSoundManager.instance.Play(newFootstep);
            else
                MainSoundManager.instance.Stop(newFootstep);
        }

        animator.SetFloat("Left", movement.y);
        animator.SetFloat("Up", movement.x);
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
    }

    public void SetAnimWin()
	{
        animator.SetBool("isWinning", true);
	}

    public void EndAnimWin()
	{
        animator.SetBool("isWinning", false);
    }





}
