using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementState : PlayerState
{
    protected int xInput;
    protected int yInput;

    private bool JumpInput;
    private bool isGrounded;

    private AbilityStateListener stateListener;

    public PlayerMovementState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName, AbilityStateListener stateListener) : base(player, stateMachine, playerData, animBoolName)
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
        

    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        UpdateMovement(playerData.movementVelocity);

        if (player.InputHandler.AttackInput)
        {
            player.StateMachine.ChangeState(player.Attack1Ability);
        }
        else if (player.InputHandler.AttackBowInput)
        {
            player.StateMachine.ChangeState(player.AttackBowAbility);
        }


        

        

        
    }

    public void UpdateMovement(float movementVelocity)
    {
        player.CheckIfShouldFlip();
        player.SetVelocityX(player.InputHandler.NormInputX * movementVelocity);

        //stateListener.ListenForAbility();

        player.Anim.SetFloat("InputXAbs", Math.Abs(player.InputHandler.NormInputX));
        player.Anim.SetFloat("InputY", player.RB.velocity.y);
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
