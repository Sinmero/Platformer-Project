using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformBaseGreen : PlatformBase
{
    void Start()
    {
        PlatformController.instance._greenPlatform.onEnable += OnEnable;
        PlatformController.instance._greenPlatform.onDisable += OnDisable;
        OnDisable();
    }
}
