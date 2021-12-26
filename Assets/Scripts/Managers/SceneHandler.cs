using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneHandler : Manager<SceneHandler>
{
    public override void Initialize()
    {
        throw new System.NotImplementedException();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(0);
        }
    }
}