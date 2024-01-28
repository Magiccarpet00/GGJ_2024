using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float moveDuration;
    [SerializeField] private Controller controller;
    [SerializeField] private Animator animator;
    [SerializeField] private LoseAnim lose;

    public AudioSource engine;
    [SerializeField] private AudioSource drift;
    [SerializeField] private AudioSource crash;

    public event Action AnimEnded;

    private bool hold = false;
    private Vector3 startPlayerPos;
    private Vector3 PlayerlastPos;

	private float elapsedTime;

    public void Death()
	{
        CarSoundManager.instance.Play(crash);
        lose.gameObject.SetActive(true);
        GetComponent<SpriteRenderer>().enabled = false;
	}
    

	private void Start()
	{
        startPlayerPos = transform.position;
		lose.OnEnd += Lose_OnEnd;
    }

	private void Lose_OnEnd()
	{
        AnimEnded?.Invoke();
	}

	// Update is called once per frame
	void Update()
    {
        CheckInput();

        if (hold) 
		{
            elapsedTime += Time.deltaTime;
            MoveCar();
            transform.position = Vector3.MoveTowards(transform.position, PlayerlastPos, elapsedTime / moveDuration);
            animator.SetFloat("Direction", controller.direction);
            CarSoundManager.instance.Play(drift);
        }
        else
		{
            transform.position = Vector3.MoveTowards(transform.position, startPlayerPos, elapsedTime / moveDuration);
            animator.SetFloat("Direction", 0);
        }
        

        if (elapsedTime >= moveDuration)
            elapsedTime = 0;
    }

    private void MoveCar()
	{
        Vector3 movement = controller.direction * Vector3.right * speed;
        PlayerlastPos = startPlayerPos + movement;
	}

    private void CheckInput()
	{
        if (Input.GetMouseButtonDown(0))
        {
            hold = true;
            startPlayerPos = transform.position;
        }
        if (Input.GetMouseButtonUp(0))
        {
            hold = false;

        }
	}
}
