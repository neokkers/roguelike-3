using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFallState : PlayerAirState
{
    public PlayerFallState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName, AbilityStateListener stateListener) : base(player, stateMachine, playerData, animBoolName, stateListener)
    {
    }

    public override void DoChecks()
    {
        base.DoChecks();
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if (player.RB.velocity.y >= 0f) player.StateMachine.ChangeState(player.JumpState);

    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}