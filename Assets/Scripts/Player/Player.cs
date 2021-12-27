using System;
using CpuMisc;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int PlayerId => playerId;
    public int playerId;
    [SerializeField] private PlayerMovement movement;
    [SerializeField] private FakeRigidbody fakeRigidbody;
    [SerializeField] private PlayerAnimator playerAnimator;
    [SerializeField] private InteractWithOther interactWithOther;
    [SerializeField] private PlayerParticle playerParticle;
    
    private bool isDead;

    private void Update()
    {
        fakeRigidbody.Tick();
        interactWithOther.Tick();
        movement.Tick();
        playerAnimator.Tick();
    }

    private void LateUpdate()
    {
        fakeRigidbody.PhysicsUpdate();
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
    }

    private void Die()
    {
        GameManager.Instance.ChangeGameState(CONSTANTS.LoseState);
    }

    public void FinishGame()
    {
        if (isDead) return;
        playerParticle.Die(transform.position);
        isDead = true;
        gameObject.SetActive(false);
    }
}