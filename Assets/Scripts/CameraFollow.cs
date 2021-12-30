using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform followingObject;
    [SerializeField] private Vector3 offset;
    [SerializeField] private bool lockY;
    [SerializeField] private float speed;

    private bool canFollow;


    public void StartFollow()
    {
        canFollow = true;
    }

    private void LateUpdate()
    {
        if (!canFollow) return;

        Vector3 destPos = followingObject.position;
        if (lockY)
            destPos.y = transform.position.y;
        transform.position = Vector3.MoveTowards(transform.position, destPos + offset, speed * Time.deltaTime);
    }
}