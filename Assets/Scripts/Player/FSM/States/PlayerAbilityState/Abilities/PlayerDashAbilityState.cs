using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDashAbilityState : PlayerAbilityState
{
    private AbilityStateListener manager;
    public PlayerDashAbilityState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName, AbilityStateListener manager) : base(player, stateMachine, playerData, animBoolName, manager)
    {
        this.manager = manager;
    }

    public override void Enter()
    {
        base.Enter();
        player.InputHandler.StopDashing();
        manager.isDashing = true;


    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if (player.InputHandler.AttackBowInput)
        {
            player.AttackBowAbility.bowFromDash = true;
            player.StateMachine.ChangeState(player.AttackBowAbility);
        }
        else if (Time.time - startTime > playerData.dashTime && !player.InputHandler.AttackInput)
        {
            isAbilityDone = true;
            manager.isDashing = false;
        }
        
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
        player.SetVelocityX(playerData.dashVelocity * player.FacingDirection);
    }
}
