using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newPlayerData", menuName = "Data/Player Data/Base Data")]
public class PlayerData : ScriptableObject
{
    [Header("Move State")]
    public float movementVelocity = 10f;

    [Header("Jump State")]
    public float jumpVelocity = 15f;
    public int amountOfJumps = 2;

    [Header("Dash State")]
    public float dashVelocity = 15f;
    public float dashTime = 0.3f;
    public float dashCooldown = 1f;

    [Header("Check Variables")]
    public float groundCheckRadius = 0.3f;
    public LayerMask whatIsGround;

    [Header("Attack State")]
    public float attack2Time = 3f;
    public float attack2Velocity = 5f;
}