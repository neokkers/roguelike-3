using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityStateListener
{
    private Player player;
    private PlayerData playerData;
    public bool canDash = true;
    public float dashStarted;
    
    public AbilityStateListener(Player player, PlayerData playerData)
    {
        this.player = player;
        this.playerData = playerData;
    }

    public void ListenForAbility()
    {
        if (player.InputHandler.JumpInput)
        {
            player.StateMachine.ChangeState(player.JumpAbilityState);
        }
        else if (player.InputHandler.DashInput && canDash)
        {
            player.StateMachine.ChangeState(player.DashAbilityState);
        }
    }

    public void CheckIfCanDash()
    {
        if (!canDash)
        {
            if (Time.time - dashStarted > playerData.dashCooldown) canDash = true;
        }
    }
}
