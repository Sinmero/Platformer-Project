using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachineHandler : MonoBehaviour
{
    [HideInInspector] public State _currentState;



    void Update()
    {
        OnUpdate();
    }

    public virtual void OnUpdate() {
        _currentState.Execute();
    }



    public void ChangeState(State newState) {
        SystemLogger.instance.Log($"Changing state from {_currentState} to {newState}", this);
        _currentState?.OnStateLeave();
        _currentState = newState;
        _currentState.OnStateEnter();
    }
}
