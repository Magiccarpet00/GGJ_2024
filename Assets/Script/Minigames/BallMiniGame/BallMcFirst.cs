using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMcFirst : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Vector2 v2;
    [SerializeField] private float speed;
    [SerializeField] private float incrSpeed;
    [SerializeField] private float pan;
    [SerializeField] private float rngOffSet;
    

    private void Start()
    {
        rb.Sleep();
    }

    private void OnMouseDown()
    {
        if (BallMiniGameManager.instance.gameStarted == false)
        {
            BallMiniGameManager.instance.StartGame();
            rb.WakeUp();
        }

        if (BallMiniGameManager.instance.lose == false)
        {
            StartCoroutine(Bounce());
        }
    }

    public IEnumerator Bounce()
    {
        yield return new WaitForSeconds(0.1f);
        float currentSpeed = speed;
        speed += incrSpeed;
        v2 = new Vector2(Random.Range(-pan, pan), 1f);
        currentSpeed += Random.Range(-rngOffSet, rngOffSet);
        v2 = (v2.normalized) * currentSpeed;

        rb.AddForce(v2);
    }
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground"))
        {

            rb.velocity = Vector3.zero;
            rb.Sleep();
            
            BallMiniGameManager.instance.PreLose();
        }
    }
}
