using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]private float speed;
    [SerializeField]private Animator animator;
    [SerializeField] private Rigidbody2D rb;
    private Vector2 movement;

	private void Awake()
	{
        DontDestroyOnLoad(gameObject);
	}

	void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
    }





}
