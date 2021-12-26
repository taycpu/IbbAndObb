using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InjectCamera : InjectShared
{
    public override void Inject()
    {
        sharedLevelData.mainCam = GetComponent<Camera>();
    }
}
