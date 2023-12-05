using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : State<PlayerFSM,PlayerStateEnum>
{
    protected Rigidbody2D rigidbody;
    protected Animator animator;
    public PlayerState(StateMachine<PlayerFSM,PlayerStateEnum> _stateMachine, PlayerFSM _owner, string _animationBoolName) : base(_stateMachine, _owner, _animationBoolName)
    {
        rigidbody = owner.RigidbodyCompo;
        animator = owner.AnimatorCompo;
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();
    }
}
