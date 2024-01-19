using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointReturning : State
{
    private PlayerController _playerController;
    private Rigidbody2D _rb;
    public Vector3 _lastCheckpointPosition;


    public CheckpointReturning(StateMachineHandler stateMachineHandler) : base(stateMachineHandler)
    {
        _playerController = stateMachineHandler as PlayerController;
        _rb = _playerController.GetComponent<Rigidbody2D>();
        _playerController.onExecute += Execute;
    }



    public override void Execute()
    {
        base.Execute();
        if (Input.GetKeyDown(Controls.keys._returnToCheckpoint))
        {
            _rb.velocity = Vector2.zero;
            _rb.transform.position = _lastCheckpointPosition;
        }
    }
}
