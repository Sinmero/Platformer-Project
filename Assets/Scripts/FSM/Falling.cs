using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Falling : InAir
{
    private LayerMask _layerMask;
    private Vector2 _colliderSize = new Vector2(0, 0);
    private CapsuleCollider2D _capsuleCollider2D;

    public Falling(StateMachineHandler stateMachineHandler) : base(stateMachineHandler) { 
        _layerMask = LayerMask.GetMask("Solid");
        _capsuleCollider2D = _stateMachineHandler.GetComponent<CapsuleCollider2D>();
        _colliderSize.x = _capsuleCollider2D.size.x * _stateMachineHandler.transform.localScale.x;
        _colliderSize.y = _capsuleCollider2D.size.y * _stateMachineHandler.transform.localScale.y;
    }



    public override void Execute()
    {
        base.Execute();
        BoxCast();
    }



    public void BoxCast()
    {
        Debug.DrawRay(_playerController.transform.position - new Vector3(0, _colliderSize.y * 0.5f, 0), new Vector3(0, -0.1f, 0), Color.red);
        RaycastHit2D[] collisions = Physics2D.BoxCastAll(_stateMachineHandler.transform.position, _colliderSize, 0, Vector2.down, 0.1f, _layerMask);

        if (collisions.Length > 0)
        {
            PhysicsLogger.instance.Log($"Landed on {collisions[0].transform.name}", _playerController);
            _stateMachineHandler.ChangeState(_playerController._idle); //changing state to grounded when colliding with solid object with out bottom
        }
    }
}
