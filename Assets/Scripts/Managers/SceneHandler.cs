using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneHandler : Manager<SceneHandler>
{
    public override void Initialize()
    {
    }


    public void ResetScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
    }
}