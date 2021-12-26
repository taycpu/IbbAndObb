using System.Collections;
using UnityEngine;

public class LevelManager : Manager<LevelManager>
{
    [SerializeField] private LevelController levelController;
    private Level currentLevel;

    public override void Initialize()
    {
        currentLevel = Instantiate(levelController.GetLevel());
        currentLevel.WhenLevelLoad();
    }

    public void LoadLevel()
    {
        currentLevel.WhenLevelLoad();
    }

    public void StartLevel()
    {
        currentLevel.WhenLevelStart();
    }
}