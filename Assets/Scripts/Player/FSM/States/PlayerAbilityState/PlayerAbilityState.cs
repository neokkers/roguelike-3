using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAbilityState : PlayerState
{
    protected bool isAbilityDone;
    private AbilityStateListener stateListener;

    

    public PlayerAbilityState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName, AbilityStateListener stateListener) : base(player, stateMachine, playerData, animBoolName)
    {
        this.stateListener = stateListener;
    }

    public override void DoChecks()
    {
        base.DoChecks();
    }

    public override void Enter()
    {
        base.Enter();

        isAbilityDone = false;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (player.InputHandler.AttackInput && stateListener.isDashing)
        {
            player.InputHandler.StopAttacking();
            player.StateMachine.ChangeState(player.Attack2Ability);

        }
        else if (isAbilityDone)
        {
            if (player.isGrounded)
            {
                stateMachine.ChangeState(player.GroundState);
            }
            else
            {
               stateMachine.ChangeState(player.AirState);
            }
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
