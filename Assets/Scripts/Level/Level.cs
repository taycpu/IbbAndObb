using UnityEngine;
using UnityEngine.Events;

public class Level : MonoBehaviour
{
    [SerializeField] private UnityEvent whenLevelLoad;
    [SerializeField] private UnityEvent whenLevelStart;

    public void WhenLevelLoad()
    {
        whenLevelLoad?.Invoke();
    }

    public void WhenLevelStart()
    {
        whenLevelStart?.Invoke();
    }
}