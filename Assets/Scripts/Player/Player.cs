using System;
using CpuMisc;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private PlayerMovement movement;
    [SerializeField] private FakeRigidbody fakeRigidbody;
    [SerializeField] private PlayerAnimator playerAnimator;
    [SerializeField] private InteractWithOther interactWithOther;


    private void Update()
    {
        fakeRigidbody.Tick();
        interactWithOther.Tick();
        movement.Tick();
        playerAnimator.Tick();
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Portal"))
        {
            movement.ReverseGravity();
        }

        if (other.CompareTag("ObstacleKillTrigger"))
        {
            ObstacleKillTrigger killTrigger = other.GetComponent<ObstacleKillTrigger>();
            TWEAKS.PlayParticleFromPool(0, killTrigger.particlePos.position);
            killTrigger.Trigger();
        }

        if (other.CompareTag("Obstacle"))
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log("Die");
        GameManager.Instance.ChangeGameState(CONSTANTS.LoseState);
    }
}