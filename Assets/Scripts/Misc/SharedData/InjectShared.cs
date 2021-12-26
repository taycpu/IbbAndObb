using UnityEngine;

public abstract class InjectShared : MonoBehaviour
{
    [SerializeField] protected SharedLevelData sharedLevelData;

    public SharedLevelData SharedLevelData
    {
        get => sharedLevelData;
    }

    
    public abstract void Inject();
}