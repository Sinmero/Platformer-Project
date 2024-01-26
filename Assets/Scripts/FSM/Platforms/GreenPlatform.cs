using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenPlatform : State
{
    private PlatformController _platformController;
    public delegate void OnToggle();
    public OnToggle onEnable;
    public OnToggle onDisable;
    public delegate void OnGreen();
    public event OnGreen onGreen;
    public GreenPlatform(StateMachineHandler stateMachineHandler) : base(stateMachineHandler)
    {
        _platformController = _stateMachineHandler as PlatformController;
    }
    


    public override void OnStateEnter()
    {
        base.OnStateEnter();
        onEnable?.Invoke();
        GameplayLogger.instance.Log($"Green activated", _platformController);
        GlobalMaterials.instance.ClearCoroutines();
        ActivateColor();
        onGreen?.Invoke();
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
        if (Input.GetKeyDown(Controls.keys._blue))
        {
            _stateMachineHandler.ChangeState(_platformController._bluePlatform);
        }
    }



    private void ActivateColor() {
        GlobalMaterials.instance.SmoothShaderTransition(GlobalMaterials.instance._greenPlatform, "_OutlineTransition", 0, false, 0.2f);
    }



    private void DeactivateColor(){
        GlobalMaterials.instance.SmoothShaderTransition(GlobalMaterials.instance._greenPlatform, "_OutlineTransition", 1, false, 0.2f);
    }
}
