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
    public int _totalDashes = 0;
    public Action
    _dashing,
    _afterDashing;

    private AudioClip _audioClipOnEnter;
    private AudioClip _audioClipOnExit;
    private AudioClip _audioClipAux;

    public Dashing(StateMachineHandler stateMachineHandler, AudioClip audioOnEnter = null, AudioClip audioOnExit = null, AudioClip audioAuxClip = null) : base(stateMachineHandler)
    {
        _playerController = stateMachineHandler as PlayerController;
        _rb = _playerController.GetComponent<Rigidbody2D>();
        _playerController._falling.OnLanded += OnLanded;
        _spriteRenderer = _playerController.GetComponent<SpriteRenderer>();

        _audioClipOnEnter = audioOnEnter;
        _audioClipOnExit = audioOnExit;
        _audioClipAux = audioAuxClip;

        _dashing = () =>
        {
            _moveVector.y = 0;
            _moveVector.x = 0;
            _rb.velocity = _moveVector;

            var dir = 1;

            if (_spriteRenderer.flipX) dir = -1; //dashing in the direction the sprite is facing

            GlobalMaterials.instance._dashing.SetInt("_Flip", Convert.ToInt32(_spriteRenderer.flipX));

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
            GameplayLogger.instance.Log($"Out of dash charges.", _playerController);
            _playerController.ChangeState(_playerController._falling);
            return;
        }
        _playerController._dashingParticles.Play();
        GameSystems.instance.CoroutineStart(_dashing, 0.2f, _afterDashing);
        AudioManager.instance.PlaySoundClip(_audioClipOnEnter);
        _totalDashes -= 1;
    }



    public override void OnStateLeave()
    {
        base.OnStateLeave();
        _playerController._dashingParticles.Stop();
    }



    public void OnLanded(RaycastHit2D raycastHit2D)
    {
        var redPlatform = raycastHit2D.transform.GetComponent<PlatformBaseRed>();
        _totalDashes = 0;
        if(redPlatform == null) return; //only reset dash ability when player lands on a red platform
        AudioManager.instance.PlaySoundClip(_audioClipAux);
        _totalDashes = 1;
    }
}
