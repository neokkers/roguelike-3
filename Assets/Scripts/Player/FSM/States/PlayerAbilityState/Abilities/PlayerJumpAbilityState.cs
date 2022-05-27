using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpAbilityState : PlayerAbilityState
{
    public PlayerJumpAbilityState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName, AbilityStateListener stateListener) : base(player, stateMachine, playerData, animBoolName, stateListener)
    {
    }

    public override void Enter()
    {
        base.Enter();
        player.InputHandler.StopJumping();
        player.SetVelocityY(playerData.jumpVelocity);
        isAbilityDone = true;
    }
}
