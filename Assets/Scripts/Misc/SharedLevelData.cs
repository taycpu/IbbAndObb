using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Datas/Create SharedLevelData", fileName = "SharedLevelData", order = 0)]
public class SharedLevelData : ScriptableObject
{
    public Camera mainCam;
    public Level currentLevel;
    public LoadEvents currentLoadEvents;
}