using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformBaseBlue : PlatformBase
{
    void Start()
    {
        PlatformController.instance._bluePlatform.onEnable += OnEnable;
        PlatformController.instance._bluePlatform.onDisable += OnDisable;
        OnDisable();
    }
}
