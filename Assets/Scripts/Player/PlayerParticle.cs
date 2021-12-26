using System.Collections;
using System.Collections.Generic;
using CpuMisc;
using UnityEngine;

public class PlayerParticle : MonoBehaviour
{
    [SerializeField] private int dieParticleIndex;
    [SerializeField] private int destroyTrapIndex;
    
    public void Die(Vector3 pos)
    {
        TWEAKS.PlayParticleFromPool(dieParticleIndex, pos);
    }

    public void DestroyTrap(Vector3 pos)
    {
        TWEAKS.PlayParticleFromPool(destroyTrapIndex, pos);
    }
}