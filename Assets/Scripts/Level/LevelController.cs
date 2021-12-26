using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField] private FloatVariable levelIndex;

    [SerializeField] private List<Level> levels;

    private int lastLevelIndex;

    public Level GetLevel()
    {
        int levelInd = levelIndex.Value;
        if (levelInd > levels.Count - 1)
        {
            bool haveLevel = levels.Count > 1;
            while (levelInd != lastLevelIndex && haveLevel)
            {
                levelInd = Random.Range(0, levels.Count - 1);
            }
        }

        lastLevelIndex = levelInd;
        return levels[levelInd];
    }
}