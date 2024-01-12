using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving : Grounded
{
    public Moving(StateMachineHandler stateMachineHandler) : base(stateMachineHandler) {}



    public override void Execute()
    {
        base.Execute();
        if(_rb.velocity.x == 0) {
            _stateMachineHandler.ChangeState(_playerController._idle);
        }
    }
}
