using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    #region State Variables
    public PlayerStateMachine StateMachine { get; private set; }


    [SerializeField]
    public PlayerData playerData;
    public bool isGrounded;
    public PlayerMovementState MovementState { get; private set; }
    public PlayerGroundState GroundState { get; private set; }
    public PlayerAirState AirState { get; private set; }
    public PlayerAbilityState AbilityState { get; private set; }

    public PlayerJumpAbilityState JumpAbilityState { get; private set; }


    public AbilityStateListener StateListener { get; private set; }

    public PlayerDashAbilityState DashAbilityState { get; private set; }
    #endregion

    #region Components
    public Animator Anim { get; private set; }
    public PlayerInputHandler InputHandler { get; private set; }
    public Rigidbody2D RB { get; private set; }
    #endregion

    #region Check Transforms

    [SerializeField]
    private Transform groundCheck;


    #endregion

    #region Other Variables
    public int FacingDirection { get; private set; }
   
    #endregion

    #region Unity Callback Functions
    private void Awake()
    {

        StateListener = GetComponent<AbilityStateListener>();


        StateMachine = new PlayerStateMachine();
        GroundState = new PlayerGroundState(this, StateMachine, playerData, "ground", StateListener);
        AirState = new PlayerAirState(this, StateMachine, playerData, "air", StateListener);
        MovementState = new PlayerMovementState(this, StateMachine, playerData, "null", StateListener);
        AbilityState = new PlayerAbilityState(this, StateMachine, playerData, "null");
        JumpAbilityState = new PlayerJumpAbilityState(this, StateMachine, playerData, "null");
        DashAbilityState = new PlayerDashAbilityState(this, StateMachine, playerData, "dash", StateListener);

        
    }

    private void Start()
    {
        Anim = GetComponent<Animator>();
        InputHandler = GetComponent<PlayerInputHandler>();
        RB = GetComponent<Rigidbody2D>();
        FacingDirection = 1;

        StateMachine.Initialize(GroundState);
    }

    private void Update()
    {
        StateMachine.CurrentState.LogicUpdate();
    }

    private void FixedUpdate()
    {
        StateMachine.CurrentState.PhysicsUpdate();
        
        CheckIfGrounded();

    }
    #endregion

    #region Set Functions

    public void SetVelocity(Vector2 velocity)
    {
        RB.velocity = velocity;
    }
    public void SetVelocityX(float velocityX)
    {
        RB.velocity = new Vector2(velocityX, RB.velocity.y);
    }
    public void SetVelocityY(float velocityY)
    {
        RB.velocity = new Vector2(RB.velocity.x, velocityY);
    }


    #endregion

    #region Check Functions

    public void CheckIfGrounded()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, playerData.groundCheckRadius, playerData.whatIsGround);
    }

    public void CheckIfShouldFlip()
    {
        int xInput = InputHandler.NormInputX;
        if (xInput != 0 && xInput != FacingDirection)
        {
            Flip();
        }
    }

    #endregion

    #region Other Functions



    private void AnimationTrigger() => StateMachine.CurrentState.AnimationTrigger();

    private void AnimtionFinishTrigger() => StateMachine.CurrentState.AnimationFinishTrigger();

    private void Flip()
    {
        FacingDirection *= -1;
        transform.Rotate(0.0f, 180.0f, 0.0f);
    }
    #endregion

    void OnDrawGizmos()
    {
        // Draw a yellow sphere at the transform's position
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(groundCheck.transform.position, playerData.groundCheckRadius);
    }
}