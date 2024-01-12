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



    void Start()
    {
        _falling = new Falling(this);
        _idle = new Idle(this);
        _moving = new Moving(this);
        _jumping = new Jumping(this);
        ChangeState(_idle);
    }
}
