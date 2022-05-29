using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackBowAbility : PlayerAbilityState
{
    private AbilityStateListener manager;
    private float critStartTime;
    public bool bowFromDash = false;
    private float lastShotTime;
   
    public PlayerAttackBowAbility(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName, AbilityStateListener manager) : base(player, stateMachine, playerData, animBoolName, manager)
    {
        this.manager = manager;
    }

    public override void Enter()
    {
        base.Enter();
        manager.isAttackingBow = true;

        if (bowFromDash) player.Anim.SetFloat("bowSpeed", 2);

    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (!player.InputHandler.AttackBowInput && Time.time - lastShotTime > 0.4f)
        {
            StopAttackBow();
        }

        player.MovementState.UpdateMovement(playerData.bowMovementVelocity);



        


    }
    public override void Exit()
    {
        base.Exit();
        player.Anim.SetFloat("bowSpeed", 1);
        bowFromDash = false;



    }

    public void StopAttackBow()
    {
        lastShotTime = Time.time;

        bool isCrit = Time.time - critStartTime <= player.playerData.bowCritTime;
        
        isAbilityDone = true;
        manager.isAttackingBow = false;
        if (isCrit) manager.CritFire();
        else manager.Fire();

        player.InputHandler.StopAttackingBow();
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    public void OnCritEvent()
    {
        if (Time.time - lastShotTime < 0.4f) return;
        critStartTime = Time.time;
    }
}
