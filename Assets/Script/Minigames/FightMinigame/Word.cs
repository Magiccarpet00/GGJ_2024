using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Word : MonoBehaviour
{
    [SerializeField] private Sprite[] sprites;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private ConstantForce2D constantForce2D;
    [SerializeField] private Rigidbody2D rb;

    private Vector2 movement = Vector2.zero;

    private void Start()
    {
        int rngSprite = Random.Range(0, sprites.Length);
        spriteRenderer.sprite = sprites[rngSprite];

        float rngRotation = Random.Range(-30, 30);
        rb.MoveRotation(rngRotation);

        movement.x = Random.Range(-3, 3);

    }

    private void Update()
    {
        rb.MovePosition(rb.position + movement * Time.fixedDeltaTime);
    }

    public void DestroyAnim()
    {
        Destroy(this.gameObject);
    }
}
