using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State<T,U> where T : class where U : Enum
{
    protected StateMachine<T,U> stateMachine;
    protected T owner;

    protected int animBoolHash;

    public State(StateMachine<T,U> _stateMachine, T _owner, string _animationBoolName)
    {
        owner = _owner;
        stateMachine = _stateMachine;
        animBoolHash = Animator.StringToHash(_animationBoolName);
    }
    public virtual void Enter() { }

    public virtual void Update() { }

    public virtual void Exit() { }
}
