using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleState : PlayerState
{
    public PlayerIdleState(StateMachine<PlayerFSM,PlayerStateEnum> _stateMachine, PlayerFSM _owner, string _animationBoolName) : base(_stateMachine, _owner, _animationBoolName)
    {
    }

    public override void Enter()
    {

    }

    public override void Exit()
    {
        
    }

    public override void Update()
    {
        
    }
}
