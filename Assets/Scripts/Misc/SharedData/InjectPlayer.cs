using System.Collections;
using System.Collections.Generic;


public class InjectPlayer : InjectShared
{
    public override void Inject()
    {
        sharedLevelData.currentLoadEvents = GetComponent<LoadEvents>();
    }
}