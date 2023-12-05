using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGroundState : PlayerState
{
    public PlayerGroundState(PlayerFSM _owner, StateMachine<PlayerFSM, PlayerStateEnum> _stateMachine, string _animationBoolName) : base(_owner, _stateMachine, _animationBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        owner.PlayerInput.ChargeEvent += HandleChargeEvent;
    }

    public void HandleChargeEvent()
    {
        stateMachine.ChangeState(PlayerStateEnum.Charge);
    }
    public override void Exit()
    {
        owner.PlayerInput.ChargeEvent -= HandleChargeEvent;
        base.Exit();
    }

    public override void Update()
    {
        base.Update();
    }
}
