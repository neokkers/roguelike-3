using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDashAbilityState : PlayerAbilityState
{
    private AbilityStateListener manager;
    public PlayerDashAbilityState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName, AbilityStateListener manager) : base(player, stateMachine, playerData, animBoolName)
    {
        this.manager = manager;
    }

    public override void Enter()
    {
        base.Enter();
        player.InputHandler.StopDashing();
        manager.canDash = false;
        manager.dashStarted = Time.time;
        
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if (Time.time - startTime > playerData.dashTime)
        {
            isAbilityDone = true;
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
        player.SetVelocityX(playerData.dashVelocity * player.FacingDirection);
    }
}
