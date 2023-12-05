using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerChargeState : PlayerState
{
    public PlayerChargeState(PlayerFSM _owner, StateMachine<PlayerFSM, PlayerStateEnum> _stateMachine, string _animationBoolName) : base(_owner, _stateMachine, _animationBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        owner.PlayerInput.AttackEvent += HandleAttackEvent;
    }

    public void HandleAttackEvent()
    {
        stateMachine.ChangeState(PlayerStateEnum.Idle);
    }

    public override void Exit()
    {
        owner.PlayerInput.AttackEvent -= HandleAttackEvent;
        base.Exit();
    }

    public override void Update()
    {
        base.Update();
    }
}
