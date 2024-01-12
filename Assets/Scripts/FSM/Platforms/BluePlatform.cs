using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BluePlatform : State
{
    private PlatformController _platformController;
    public delegate void OnToggle();
    public OnToggle onEnable;
    public OnToggle onDisable;
    public BluePlatform(StateMachineHandler stateMachineHandler) : base(stateMachineHandler)
    {
        _platformController = _stateMachineHandler as PlatformController;
    }



    public override void OnStateEnter()
    {
        base.OnStateEnter();
        onEnable?.Invoke();
        GameplayLogger.instance.Log($"Blue activated", _platformController);
        ActivateColor();
    }



    public override void OnStateLeave()
    {
        base.OnStateLeave();
        onDisable?.Invoke();
        DeactivateColor();
    }



    public override void Execute()
    {
        base.Execute();
        if (Input.GetKeyDown(Controls.keys._red))
        {
            _stateMachineHandler.ChangeState(_platformController._redPlatform);
        }
        if (Input.GetKeyDown(Controls.keys._green))
        {
            _stateMachineHandler.ChangeState(_platformController._greenPlatform);
        }
    }



    private void ActivateColor() {
        GlobalMaterials.instance._blue.SetFloat("_OutlineTransition", 0);
    }



    private void DeactivateColor(){
        GlobalMaterials.instance._blue.SetFloat("_OutlineTransition", 1);
    }
}
