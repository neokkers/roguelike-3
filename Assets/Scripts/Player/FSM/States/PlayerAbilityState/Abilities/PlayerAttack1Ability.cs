using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack1Ability : PlayerAbilityState
{
    private AbilityStateListener manager;
    public PlayerAttack1Ability(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName, AbilityStateListener manager) : base(player, stateMachine, playerData, animBoolName, manager)
    {
        this.manager = manager;
    }

    public override void Enter()
    {
        base.Enter();
        player.InputHandler.StopAttacking();


    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        
        if (player.isGrounded)
        {
            player.SetVelocityX(0);
        }

        if (player.InputHandler.AttackInput)
        {
            player.StateMachine.ChangeState(this);
        }


    }

    public void StopAttack1()
    {
        isAbilityDone = true;
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
