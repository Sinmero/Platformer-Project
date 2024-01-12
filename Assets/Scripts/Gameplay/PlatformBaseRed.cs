using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformBaseRed : PlatformBase
{
    void Start()
    {
        PlatformController.instance._redPlatform.onEnable += OnEnable;
        PlatformController.instance._redPlatform.onDisable += OnDisable;
        OnDisable();
    }
}
