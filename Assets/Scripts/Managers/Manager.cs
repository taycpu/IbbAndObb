using System.Collections;
using System.Collections.Generic;
using CustomFeatures;
using UnityEngine;

public abstract class Manager<T> : Singleton<T> where T:Component
{
    public abstract void Initialize();
 
}