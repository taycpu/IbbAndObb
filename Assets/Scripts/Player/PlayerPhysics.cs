using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPhysics : PlayerComponent
{
    public float Gravity => gravity;
    [HideInInspector] public Vector3 velocity;
    [SerializeField] private float gravity = 9.8f;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private float floorDistance = 0.1f;

    private Vector3 lastGroundPos;

    public override void Tick()
    {
        if (!isActive) return;
        if (RayToGround(out var distance))
        {
            if (distance > floorDistance)
            {
                velocity.y += gravity * Time.deltaTime;
            }

            else
            {
                velocity.y = 0;
            }
        }
        else
        {
            if (RayToUp(out var dist))
            {
            }
            else
            {
                velocity.y += gravity * Time.deltaTime;
            }
        }
    }

    public void PhysicsUpdate()
    {
        transform.position += velocity * Time.deltaTime;
    }

    private bool RayToUp(out float distance)
    {
        RaycastHit hit;
        distance = 0;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.up), out hit, Mathf.Infinity,
            groundLayer))
        {
            distance = Mathf.Abs(transform.position.y - hit.point.y);
            return true;
        }

        return false;
    }

    private bool RayToGround(out float distance)
    {
        RaycastHit hit;
        distance = 0;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), out hit, Mathf.Infinity,
            groundLayer))
        {
            distance = Mathf.Abs(transform.position.y - hit.point.y);
            return true;
        }

        return false;
    }

    public void ReverseGravity()
    {
        gravity *= -1;
    }
}