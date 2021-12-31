using System;
using CpuMisc;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int PlayerId => playerId;
    public int playerId;
    [SerializeField] private PlayerMovement movement;
    [SerializeField] private PlayerPhysics playerPhysics;
    [SerializeField] private PlayerAnimator playerAnimator;
    [SerializeField] private InteractWithOther interactWithOther;
    [SerializeField] private PlayerParticle playerParticle;

    private bool isGameFinished;

    private void Update()
    {
        playerPhysics.Tick();
        interactWithOther.Tick();
        movement.Tick();
        playerAnimator.Tick();
    }

    private void LateUpdate()
    {
        playerPhysics.PhysicsUpdate();
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
            playerParticle.DestroyTrap(killTrigger.particlePos.position);
            killTrigger.Trigger();
        }

        if (other.CompareTag("Obstacle"))
        {
            Die();
        }

        if (other.CompareTag("Finish"))
        {
            Finish();
        }
    }

    private void Finish()
    {
        GameManager.Instance.ChangeGameState(CONSTANTS.WinState);
    }

    private void Die()
    {
        GameManager.Instance.ChangeGameState(CONSTANTS.LoseState);
    }


    //This functions is calling from StateMachine events
    public void WinGame()
    {
        if (isGameFinished) return;
        isGameFinished = true;
        movement.ResetVel();
    }

    //This functions is calling from StateMachine events
    public void LoseGame()
    {
        if (isGameFinished) return;
        playerParticle.Die(transform.position);
        isGameFinished = true;
        gameObject.SetActive(false);
    }
}