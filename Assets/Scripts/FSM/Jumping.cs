using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumping : InAir
{
    private bool _releasedJump = false;
    private float lowJumpMulti = 5f;
    public Jumping(StateMachineHandler stateMachineHandler) : base(stateMachineHandler) { }



    public override void Execute()
    {
        base.Execute();
        ReleaseJumpEarly();

        if (_rb.velocity.y <= 0)
        { // cant break jump if already falling
            _stateMachineHandler.ChangeState(_playerController._falling);
        }

        if (Input.GetKeyUp(Controls.keys._jump))
        { //if the player releases jump button break the jump
            _releasedJump = true;
        }
    }



    public override void OnStateLeave()
    {
        base.OnStateLeave();
        GameplayLogger.instance.Log(Physics2D.gravity.y, _playerController);
        _releasedJump = false;
    }



    private void ReleaseJumpEarly()
    {
        if (_releasedJump)
        {
            _moveVector += Vector2.up * Physics2D.gravity.y * (lowJumpMulti - 1) * Time.deltaTime;
            _moveVector.x = _rb.velocity.x;
            _rb.velocity = _moveVector;
        }
    }
}
