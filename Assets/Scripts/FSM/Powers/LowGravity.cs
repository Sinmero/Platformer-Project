using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LowGravity : State
{
    public PlayerController _playercontroller;
    public Rigidbody2D _rb;
    public int _totalLowGrav = 0;
    public float 
    _gravScale,
    _initialJumpForce;

    private AudioClip _audioClipOnEnter;
    private AudioClip _audioClipOnExit;
    private AudioClip _audioClipAux;

    public LowGravity(StateMachineHandler stateMachineHandler, AudioClip audioOnEnter = null, AudioClip audioOnExit = null, AudioClip audioAuxClip = null) : base(stateMachineHandler){
        _playercontroller = stateMachineHandler as PlayerController;
        _rb = _playercontroller .GetComponent<Rigidbody2D>();
        _gravScale = _rb.gravityScale;
        _initialJumpForce = _playercontroller._jumpForce;
        _playercontroller._falling.OnLanded += OnLanded;
        _playercontroller.onExecute += OnLowGrav;

        _audioClipOnEnter = audioOnEnter;
        _audioClipOnExit = audioOnExit;
        _audioClipAux = audioAuxClip;
    }



    public void OnLowGrav() {
        // if(Input.GetKeyDown(Controls.keys._dash)) {
        //     if(_totalLowGrav == 0) return;
        //     _rb.gravityScale = 1f;
        //     _playercontroller._jumpForce = 10;
        //     _totalLowGrav -= 1;
        // }
    }



    public void OnLanded(RaycastHit2D raycastHit2D){
        var hit = raycastHit2D.transform.GetComponent<PlatformBaseBlue>();
        _rb.gravityScale = _gravScale;
        _playercontroller._jumpForce = _initialJumpForce;
        // _totalLowGrav = 0;
        if(hit == null) return;
        _rb.gravityScale = 1f;
        _playercontroller._jumpForce = 10;
        // _totalLowGrav -= 1;
        // _totalLowGrav = 1;
    }
}
