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
        GlobalMaterials.instance.ClearCoroutines();
        ActivateColor();
        GlobalMaterials.instance.SmoothShaderTransition(GlobalMaterials.instance._colorSplitter, "_Red", 0.4f);
        GlobalMaterials.instance.SmoothShaderTransition(GlobalMaterials.instance._colorSplitter, "_Green", 0.5f);
        GlobalMaterials.instance.SmoothShaderTransition(GlobalMaterials.instance._colorSplitter, "_Blue", 1f);
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
        GlobalMaterials.instance.SmoothShaderTransition(GlobalMaterials.instance._bluePlatform, "_OutlineTransition", 0, false, 0.2f);
    }



    private void DeactivateColor(){
        GlobalMaterials.instance.SmoothShaderTransition(GlobalMaterials.instance._bluePlatform, "_OutlineTransition", 1, false, 0.2f);
    }
}
