using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveState : PlayerGroundState
{
    public PlayerMoveState(PlayerFSM _owner, StateMachine<PlayerFSM, PlayerStateEnum> _stateMachine, string _animationBoolName) : base(_owner, _stateMachine, _animationBoolName)
    {
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
        float xInput = owner.PlayerInput.XInput;

        owner.SetVelocity(xInput * owner.MoveSpeed, rigidbody.velocity.y);

        if (Mathf.Abs(xInput) < 0.05f) // float no no == and !=
        {
            stateMachine.ChangeState(PlayerStateEnum.Idle);
        }
    }
}
