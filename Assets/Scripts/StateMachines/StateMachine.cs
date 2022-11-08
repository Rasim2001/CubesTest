using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine<T> where T : IState
{
    public T CurrentState;
    public void Init(T newState)
    {
        CurrentState = newState;
        CurrentState.Enter();
    }

    public void ChangeState(T newState)
    {
        CurrentState.Exit();
        CurrentState = newState;
        CurrentState.Enter();
    }
}
