using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GreyPlatform : State
{
    private PlatformController _platformController;
    public GreyPlatform(StateMachineHandler stateMachineHandler) : base(stateMachineHandler)
    {
        _platformController = _stateMachineHandler as PlatformController;
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
        if (Input.GetKeyDown(Controls.keys._blue))
        {
            _stateMachineHandler.ChangeState(_platformController._bluePlatform);
        }
    }
}
