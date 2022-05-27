using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpAbilityState : PlayerAbilityState
{
    public PlayerJumpAbilityState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
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
