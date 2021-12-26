public class InjectLevel : InjectShared
{
    public override void Inject()
    {
        sharedLevelData.currentLevel = GetComponent<Level>();
    }
}