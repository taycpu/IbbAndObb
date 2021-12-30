using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractWithOther : PlayerComponent
{
    [SerializeField] private LayerMask playerLayer;
    [SerializeField] private PlayerMovement myPlayer;
    [SerializeField] private PlayerMovement otherPlayer;
    [SerializeField] private Transform rayPos;

    private float distance = 0.4f;

    public override void Tick()
    {
        PushHorizontal();
        GetOnTop();
    }

    private void PushHorizontal()
    {
        Debug.DrawRay(rayPos.position, transform.right * distance, Color.white);
        if (myPlayer.Physics.velocity.x != 0)
        {
            // Does the ray intersect any objects excluding the player layer
            if (Physics.Raycast(rayPos.position, transform.right, distance, playerLayer))
            {
                print("HITTING");
                otherPlayer.Push(myPlayer.Physics.velocity);
            }
            else
            {
                otherPlayer.ExtractFromOther();
            }
        }
        else
        {
            otherPlayer.ExtractFromOther();
        }
    }

    private void GetOnTop()
    {
        Debug.DrawRay(transform.position, -transform.up * distance, Color.white);

        if (Physics.Raycast(transform.position, -transform.up, 0.1f, playerLayer))
        {
            myPlayer.United(otherPlayer.Physics.velocity);
        }
        else
        {
            myPlayer.ExtractUnited();
        }
    }
}