using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    [SerializeField] private float speed;
    [SerializeField] private Transform player;
    [SerializeField] private Vector3 offset;

    private void FixedUpdate()
    {
        Vector3 desiredPos = player.position + offset;
        Vector3 smoothPosition = Vector3.Lerp(transform.position, desiredPos, speed);
        transform.position = smoothPosition;
    }
}
