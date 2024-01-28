using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zeldaMoove : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] float finalPositionZeldaX;
    [SerializeField] float finalPositionZeldaY;
    private Vector2 movement;

    public bool letsMoove = false;

    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
        movement.x = 1.0f;
        movement.y = 0.0f;
    }
    void FixedUpdate()
    {
        if(letsMoove)
        { 
          rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        letsMoove = true;
        animator.SetBool("zeldaWalking", true);
        StartCoroutine(TPZelda());
    }

    IEnumerator TPZelda()
    {
        yield return new WaitForSeconds(3.0f);

        transform.position = new Vector2(finalPositionZeldaX, finalPositionZeldaY);
        animator.SetBool("zeldaWalking", false);
        letsMoove = false;
    }
}
