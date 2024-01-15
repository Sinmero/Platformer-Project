using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Dashing : State
{
    public PlayerController _playerController;
    public Rigidbody2D _rb;
    public SpriteRenderer _spriteRenderer;
    public Vector2 _moveVector = new Vector2(0, 0);
    public int _totalDashes = 1;
    public Action
    _dashing,
    _afterDashing;
    public Dashing(StateMachineHandler stateMachineHandler) : base(stateMachineHandler)
    {
        _playerController = stateMachineHandler as PlayerController;
        _rb = _playerController.GetComponent<Rigidbody2D>();
        _playerController._falling.OnLanded += OnLanded;
        _spriteRenderer = _playerController.GetComponent<SpriteRenderer>();

        _dashing = () =>
        {
            _moveVector.y = 0;
            _moveVector.x = 0;
            _rb.velocity = _moveVector;

            var dir = 1;

            if (_spriteRenderer.flipX) dir = -1; //dashing in the direction the sprite is facing

            _moveVector.x = dir;
            _rb.gravityScale = 0;

            _rb.AddForce(_moveVector * 18, ForceMode2D.Impulse);
        };

        _afterDashing = () =>
        {
            _moveVector.x = 0;
            _moveVector.y = _rb.velocity.y;
            _rb.velocity = _moveVector;
            _rb.gravityScale = 3;
            _playerController.ChangeState(_playerController._falling);
        };
    }

    public override void OnStateEnter()
    {
        base.OnStateEnter();
        if (_totalDashes <= 0) {
            _playerController.ChangeState(_playerController._falling);
            return;
        }
        Debug.Log(_playerController._currentState);
        GameSystems.instance.CoroutineStart(_dashing, 0.2f, _afterDashing);
        _totalDashes -= 1;
    }



    public void OnLanded(RaycastHit2D raycastHit2D)
    {
        _totalDashes = 1;
    }
}
