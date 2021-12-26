using System;
using UnityEngine;

public class PlayerMovement : PlayerComponent
{
    public float Horizontal => horizontal;
    public float Vertical => rb.velocity.normalized.y;
    public bool OnJump => jumped;

    public FakeRigidbody Rb => rb;

    [SerializeField] private FakeRigidbody rb;
    [SerializeField] private PlayerInput playerInput;
    [SerializeField] private float jumpAmount;
    [SerializeField] private float speed;
    [SerializeField] private LayerMask jumpLayer;
    [SerializeField] private float jumpDistance;
    private bool isReversed;
    private bool jumped;
    private float horizontal;
    public bool pushing;
    public bool isUnited;

    public override void Tick()
    {
        if (!isActive) return;
        if (Input.GetKeyDown(playerInput.jump))
        {
            Jump();
        }

        if ((!isUnited && !pushing) || playerInput.GetHorizontalAxis() != 0)
        {
            horizontal = playerInput.GetHorizontalAxis();

            Move(horizontal);
        }
    }

    public void ReverseGravity()
    {
        if (Mathf.Abs(rb.velocity.y) < 3)
            rb.velocity.y += 3 * Mathf.Sign(rb.Gravity);
        rb.ReverseGravity();
        jumpAmount *= -1;
        float rot = rb.Gravity < 0 ? 0 : 180;
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
            Rb.velocity.y = velocity.y;
            Rb.velocity.x = velocity.x;
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

    private void Move(float axis)
    {
        Flip(axis);
        rb.velocity.x = axis * speed;
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
            float xRot = rb.Gravity < 0 ? 0 : 180;
            transform.rotation = Quaternion.Euler(new Vector3(xRot, yRot, 0));
        }
    }

    void Jump()
    {
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), jumpDistance, jumpLayer))
        {
            Debug.Log("Jump");
            rb.velocity.y += jumpAmount;
        }
    }
}