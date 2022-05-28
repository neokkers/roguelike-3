using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack2Ability : PlayerAbilityState
{
    private AbilityStateListener manager;
    public PlayerAttack2Ability(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName, AbilityStateListener manager) : base(player, stateMachine, playerData, animBoolName, manager)
    {
        this.manager = manager;
    }

    public override void Enter()
    {
        base.Enter();
        player.InputHandler.StopAttacking();
        manager.isAttacking2 = true;
        manager.isDashing = false;

    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        /*if (Time.time - startTime > playerData.attack2Time)
        {
            isAbilityDone = true;
            manager.isAttacking2 = false;
        }*/


    }

    public void StopAttack2()
    {
        isAbilityDone = true;
        manager.isAttacking2 = false;
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
        player.SetVelocityX(playerData.attack2Velocity * player.FacingDirection);
    }
}
