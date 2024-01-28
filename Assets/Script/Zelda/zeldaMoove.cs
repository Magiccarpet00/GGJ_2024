using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zeldaMoove : MonoBehaviour
{
    public float deplacementX = 0.0001f; // Montant de déplacement en X
    public float deplacementY = 0.0f; // Montant de déplacement en Y

    private bool letsMoove = false;

    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    void Update()
    {
        if(letsMoove)
        {
            // Obtenez la position actuelle du GameObject
            Vector2 positionActuelle = transform.position;

            // Calculez la nouvelle position en ajoutant le déplacement
            Vector2 nouvellePosition = new Vector2(positionActuelle.x + deplacementX, positionActuelle.y + deplacementY);

            // Définissez la nouvelle position du GameObject
            transform.position = nouvellePosition;
        }
       
    }

 

    private void OnTriggerEnter2D(Collider2D collision)
    {
        letsMoove = true;
        animator.SetBool("zeldaWalking", true);
    }
}
