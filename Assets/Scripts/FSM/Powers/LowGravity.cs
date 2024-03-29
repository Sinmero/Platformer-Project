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

    public LowGravity(StateMachineHandler stateMachineHandler, AudioClip audioOnEnter = null, AudioClip audioOnExit = null, AudioClip audioAuxClip = null) : base(stateMachineHandler)
    {
        _playercontroller = stateMachineHandler as PlayerController;
        _rb = _playercontroller.GetComponent<Rigidbody2D>();
        _gravScale = _rb.gravityScale;
        _initialJumpForce = _playercontroller._jumpForce;
        _playercontroller._falling.OnLanded += OnLanded;

        _audioClipOnEnter = audioOnEnter;
        _audioClipOnExit = audioOnExit;
        _audioClipAux = audioAuxClip;

    }
  


    public void OnLanded(RaycastHit2D raycastHit2D)
    {
        var hit = raycastHit2D.transform.GetComponent<PlatformBaseBlue>();
        _rb.gravityScale = _gravScale;
        _playercontroller._jumpForce = _initialJumpForce;
        if (hit == null)
        {
            if(GlobalMaterials.instance._lowGrav.GetFloat("_Alpha") < 1) return;
            GlobalMaterials.instance.SmoothShaderTransition(GlobalMaterials.instance._lowGrav, "_Alpha", 0, false, 0.2f);
            _playercontroller._lowGravParticles.Stop();
            return;
        }
        AudioManager.instance.PlaySoundClip(_audioClipAux);
        _rb.gravityScale = 1f;
        _playercontroller._jumpForce = 10;
        GlobalMaterials.instance.SmoothShaderTransition(GlobalMaterials.instance._lowGrav, "_Alpha", 1, false, 0.2f);
        _playercontroller._lowGravParticles.Play();
    }
}
