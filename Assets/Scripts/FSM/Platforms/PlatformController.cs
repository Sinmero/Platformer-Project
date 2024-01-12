using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : StateMachineHandler
{
    [HideInInspector] public RedPlatform _redPlatform;
    [HideInInspector] public GreenPlatform _greenPlatform;
    [HideInInspector] public BluePlatform _bluePlatform;
    [HideInInspector] public GreyPlatform _greyPlatform;
    private static PlatformController platformController;
    public static PlatformController instance {get {return platformController;}}

    void Awake()
    {
        _redPlatform = new RedPlatform(this);
        _greenPlatform = new GreenPlatform(this);
        _bluePlatform = new BluePlatform(this);
        _greyPlatform = new GreyPlatform(this);
        _currentState = _greyPlatform;
        platformController = this;
    }
}
