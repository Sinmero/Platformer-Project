using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class PlayerController : StateMachineHandler
{
    public float _jumpForce, _moveSpeed;
    [HideInInspector] public Falling _falling;
    [HideInInspector] public Idle _idle;
    [HideInInspector] public Moving _moving;
    [HideInInspector] public Jumping _jumping;
    [HideInInspector] public DoubleJump _doubleJump;
    [HideInInspector] public Dashing _dashing;
    [HideInInspector] public LowGravity _lowGravity;
    [HideInInspector] public CheckpointReturning _checkpointReturning;

    [HideInInspector] public AnimationMaker _animationMaker;
    public List<Sprite> _idleAnimation = new List<Sprite>();
    public List<Sprite> _runningAnimation = new List<Sprite>();
    public List<Sprite> _jumpingAnimation = new List<Sprite>();
    public List<AudioClip> _audioClips = new List<AudioClip>();
    
    public delegate void OnExecute();
    public event OnExecute onExecute;
    




    void Start()
    {
        _falling = new Falling(this, _audioClips[3]);
        _idle = new Idle(this);
        _moving = new Moving(this);
        _jumping = new Jumping(this, _audioClips[2]);
        _doubleJump = new DoubleJump(this, _audioClips[2], null, _audioClips[4]);
        _dashing = new Dashing(this, _audioClips[0], null, _audioClips[4]);
        _lowGravity = new LowGravity(this, null, null, _audioClips[4]);

        _animationMaker = GetComponent<AnimationMaker>();


        ChangeState(_idle);
    }



    public override void OnUpdate()
    {
        base.OnUpdate();
        onExecute?.Invoke();
    }
}
