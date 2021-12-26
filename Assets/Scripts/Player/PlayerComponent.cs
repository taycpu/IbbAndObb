using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerComponent : MonoBehaviour
{
    [HideInInspector]public bool isActive;


    //public abstract void Configure();
    public void Activate(bool _isActive)
    {
        isActive = _isActive;
    }

    public abstract void Tick();
}