using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]private float speed;
    [SerializeField]private Animator animator;
    [SerializeField] private Rigidbody2D rb;
    private Vector2 movement;

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("MiniGameTrigger"))
        {
            MiniGameName miniGameName = collision.GetComponent<MiniGameTrigger>().gameName;

            switch (miniGameName)
            {
                case MiniGameName.CARS:
                    
                    break;
                case MiniGameName.FIGHT:
                    break;
                case MiniGameName.FIND:
                    break;
                default:
                    break;
            }
        }
    }
}
