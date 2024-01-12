using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InAir : State
{
    public Vector2 _moveVector = new Vector2(0, 0);
    public PlayerController _playerController;
    public Rigidbody2D _rb;
    private SpriteRenderer _spriteRenderer;


    public InAir(StateMachineHandler stateMachineHandler) : base(stateMachineHandler)
    {
        _playerController = _stateMachineHandler as PlayerController;
        _rb = _stateMachineHandler.gameObject.GetComponent<Rigidbody2D>();
        _spriteRenderer = stateMachineHandler.GetComponent<SpriteRenderer>();
    }



    public override void OnStateEnter()
    {
        base.OnStateEnter();
    }



    public override void Execute()
    {
        base.Execute();

        if (Input.GetKey(Controls.keys._left))
        {
            _moveVector.y = _rb.velocity.y;
            _moveVector.x = -1 * _playerController._moveSpeed;
            _rb.velocity = _moveVector;

            if(!_spriteRenderer.flipX) _spriteRenderer.flipX = true;
        }
        if (Input.GetKey(Controls.keys._right))
        {
            _moveVector.y = _rb.velocity.y;
            _moveVector.x = _playerController._moveSpeed;
            _rb.velocity = _moveVector;

            if(_spriteRenderer.flipX) _spriteRenderer.flipX = false;
        }
    }



    public override void OnStateLeave()
    {
        base.OnStateLeave();
    }
}
