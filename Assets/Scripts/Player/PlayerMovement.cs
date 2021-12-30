using System;
using UnityEngine;

public class PlayerMovement : PlayerComponent
{
    public float Horizontal => horizontal;
    public float Vertical => physics.velocity.normalized.y;
    public bool OnJump => jumped;

    public PlayerPhysics Physics => physics;

    [SerializeField] private PlayerPhysics physics;
    [SerializeField] private PlayerInput playerInput;
    [SerializeField] private float jumpAmount;
    [SerializeField] private float speed;
    [SerializeField] private LayerMask jumpLayer;
    [SerializeField] private LayerMask wallLayer;
    [SerializeField] private float jumpDistance;
    private bool isReversed;
    private bool jumped;
    private float horizontal;
    private bool pushing;
    private bool isUnited;
    private bool canMove = true;


    private float stopDistance = 0.2f;
    private float portalMinForce = 3f;

    public override void Tick()
    {
        if (!isActive) return;
        if (Input.GetKeyDown(playerInput.jump) || Input.GetKeyDown(playerInput.jumpSec))
        {
            Jump();
        }

        CheckWalls();

        if ((!isUnited && !pushing) || playerInput.GetHorizontalAxis() != 0)
        {
            horizontal = playerInput.GetHorizontalAxis();
            Move(horizontal);
        }
    }

    public void CheckWalls()
    {
        if (UnityEngine.Physics.Raycast(transform.position, transform.TransformDirection(Vector3.right), stopDistance,
            wallLayer))
        {
            horizontal = 0;
            Move(horizontal);
            canMove = false;
        }
        else
        {
            canMove = true;
        }
    }

    public void ReverseGravity()
    {
        if (Mathf.Abs(physics.velocity.y) < portalMinForce)
            physics.velocity.y += portalMinForce * Mathf.Sign(physics.Gravity);
        physics.ReverseGravity();
        jumpAmount *= -1;
        float rot = physics.Gravity < 0 ? 0 : 180;
        //    print("ROT = " + rot);
        transform.rotation = Quaternion.Euler(new Vector3(rot, transform.eulerAngles.y, 0));
        isReversed = true;
    }


    public void United(Vector3 velocity)
    {
        if (playerInput.GetHorizontalAxis() == 0)
        {
            horizontal = 0;
            isUnited = true;
            Physics.velocity.y = velocity.y;
            Physics.velocity.x = velocity.x;
        }
    }

    public void Push(Vector3 velocity)
    {
        pushing = true;
        horizontal = velocity.normalized.x;
        Move(horizontal);
    }

    public void ExtractFromOther()
    {
        pushing = false;
    }

    public void ExtractUnited()
    {
        isUnited = false;
    }

    private void Move(float axis)
    {
        Flip(axis);
        if (canMove)
            physics.velocity.x = axis * speed;
    }


    void Flip(float axis)
    {
        float leftDot = Vector3.Dot(Vector3.right, transform.right);
        bool faceRight = (leftDot > 0.9f && isReversed ? (axis < 0) : (axis > 0));
        bool faceLeft = (leftDot < -0.9f && isReversed ? (axis > 0) : (axis < 0));
        if (faceRight || faceLeft)
        {
            int yRot = axis > 0 ? 0 : 180;
            if (axis == 0) yRot = 90;
            float xRot = physics.Gravity < 0 ? 0 : 180;
            transform.rotation = Quaternion.Euler(new Vector3(xRot, yRot, 0));
        }
    }

    void Jump()
    {
        if (UnityEngine.Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), jumpDistance,
            jumpLayer))
        {
            Debug.Log("Jump");
            physics.velocity.y += jumpAmount;
        }
    }
}