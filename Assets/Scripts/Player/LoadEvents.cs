using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LoadEvents : MonoBehaviour
{
    [SerializeField] private UnityEvent whenLoad;
    [SerializeField] private UnityEvent whenStart;
    [SerializeField] private UnityEvent whenStop;

    public void WhenSceneLoad()
    {
        whenLoad?.Invoke();
    }

    public void WhenGameStart()
    {
        whenStart?.Invoke();
    }

    public void WhenStop()
    {
        whenStop?.Invoke();
    }
}