using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputHandler : MonoBehaviour
{

    public Vector2 RawMovementInput { get; private set; }
    public int NormInputX { get; private set; }
    public int NormInputY { get; private set; }

    public bool JumpInput { get; private set; } = false;

    public bool DashInput { get; private set; } = false;
    public bool AttackInput { get; private set; } = false;

    private float jumpInputThreshold = 0.1f;
    private float jumpInputStart;

    public void OnMoveInput(InputAction.CallbackContext context)
    {
        RawMovementInput = context.ReadValue<Vector2>();

        if (Mathf.Abs(RawMovementInput.x) > 0.5f)
        {
            NormInputX = (int)(RawMovementInput * Vector2.right).normalized.x;
        }
        else
        {
            NormInputX = 0;
        }

        if (Mathf.Abs(RawMovementInput.y) > 0.5f)
        {
            NormInputY = (int)(RawMovementInput * Vector2.up).normalized.y;
        }
        else
        {
            NormInputY = 0;
        }
    }

    public void OnJumpInput(InputAction.CallbackContext context)
    {
       
        if (context.started)
        {
            JumpInput = true;
            jumpInputStart = Time.time;
        }
    }

    private void Update()
    {
        if (Time.time > jumpInputStart + jumpInputThreshold) JumpInput = false;
    }

    public void OnDashInput(InputAction.CallbackContext context)
    {

        if (context.started)
        {
            DashInput = true;
        }
    }
    public void OnAttackInput(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            AttackInput = true;

        }
        if (context.canceled)
        {
            AttackInput = false;

        }
    }

    public void StopJumping() => JumpInput = false;
    public void StopDashing() => DashInput = false;
    public void StopAttacking() => AttackInput = false;
}
