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

    public bool inputFreeze = true;

	void Update()
    {

        if(inputFreeze == false)
        {
            movement.x = Input.GetAxisRaw("Horizontal");
            movement.y = Input.GetAxisRaw("Vertical");

            

            animator.SetFloat("Left", movement.y);
            animator.SetFloat("Up", movement.x);

        }
       
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

    public void DefreezePlayer()
    {
        inputFreeze = false;
    }

    public void FreezePlayer()
    {
        inputFreeze = true;
    }





}
