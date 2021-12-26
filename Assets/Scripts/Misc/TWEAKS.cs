using UnityEngine;

namespace CpuMisc
{
    public static class TWEAKS
    {
        public static void PlayParticleFromPool(int index,Vector3 pos)
        {
            ParticleSystem particle = GenericPool.Instance.GetFromPool<ParticleSystem>(index);
            particle.transform.position = pos;
            particle.gameObject.SetActive(true);
        }
    }
}