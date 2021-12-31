using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenManager : Manager<ScreenManager>
{
    [SerializeField] private List<UIPanel> panels;

    public override void Initialize()
    {
        panels[0].SetActive();
    }


    public void ChangeScreen(int index)
    {
        for (int i = 0; i < panels.Count; i++)
        {
            if (index != i)
            {
                panels[i].SetDeactive();
            }
        }
        panels[index].SetActive();
    }
}