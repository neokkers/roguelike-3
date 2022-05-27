using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityStateListener: MonoBehaviour
{
    private Player player;
    public bool canDash = true;
    public float dashStarted;

    [SerializeField]
    private int jumpsLeft;
    


    

    private void Start()
    {
        this.player = GetComponent<Player>();
        ResetJumps();

    }

    private void Update()
    {
        CheckIfCanDash();
        ListenForAbility();
        if (player.isGrounded && player.RB.velocity.y <= 0.1f) ResetJumps();

    }

    public void ListenForAbility()
    {
        if (player.InputHandler.JumpInput && CanJump())
        {
            Jump();
        }
        else if (player.InputHandler.DashInput && canDash)
        {
            StartDash();
        }
    }

    public void CheckIfCanDash()
    {
        if (!canDash)
        {
            if (Time.time - dashStarted > player.playerData.dashCooldown) canDash = true;
        }
    }
    public bool CanJump()
    {
        return jumpsLeft > 0;
    }

    public void StartDash()
    {
        canDash = false;
        dashStarted = Time.time;
        player.StateMachine.ChangeState(player.DashAbilityState);
    }

    public void Jump()
    {
        
        player.StateMachine.ChangeState(player.JumpAbilityState);
        jumpsLeft--;

    }

    public void ResetJumps()
    {
        jumpsLeft = player.playerData.amountOfJumps;
    }
}
