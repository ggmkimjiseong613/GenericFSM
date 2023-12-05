using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleState : PlayerGroundState
{
    public PlayerIdleState(PlayerFSM _owner, StateMachine<PlayerFSM,PlayerStateEnum> _stateMachine, string _animationBoolName) : base(_owner, _stateMachine, _animationBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        owner.StopImmediately(false);
    }

    public override void Update()
    {
        base.Update();
        float xInput = owner.PlayerInput.XInput;

        if(Mathf.Abs(xInput) > 0.05f) // float no no == and !=
        {
            stateMachine.ChangeState(PlayerStateEnum.Move);
        }
    }
    public override void Exit()
    {
        base.Exit();
    }

}
