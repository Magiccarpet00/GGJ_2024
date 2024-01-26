using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    [SerializeField] private float speed;
    [SerializeField] private Transform player;
    [SerializeField] private float movementDuration;

    private float elapsedTime = 0f;
    private Vector2 startPosition;
    private Vector2 currentPos;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        elapsedTime += Time.deltaTime * speed;

        currentPos = Vector2.Lerp(startPosition, player.position, elapsedTime / movementDuration);
        transform.position = new Vector3(currentPos.x, currentPos.y, -10);

        if (elapsedTime >= movementDuration)
        {
            elapsedTime = 0;
            startPosition = new Vector2(transform.position.x, transform.position.y);
        }

    }
}
