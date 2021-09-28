using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum movementState { Idle, Walk, Run, Skid }
public enum directionState { North, NorthEast, East, SouthEast, South, SouthWest, West, NorthWest }
public enum facingState { North, East, South, West }

public class PlayerStateManager : MonoBehaviour{

    // Movement
    public movementState movementType = movementState.Idle; // sets "isMoving" to None / Initializes movementState
    public directionState direction = directionState.South; // sets "isDirection" to South / Initializes directionState
    public facingState facing = facingState.South; // sets "isFacing" to South / Initializes facingState

    public Vector2 move = new Vector2(0, 0); // Used in playerMovement, determines the directin the player is moving
    public float speed = 0.1f; // Used in playerMovement, Units/sec
    public float sprintModifier = 1.25f; // Used in playerMovement, multiplies speed by value set here
    public float skidThreshold = 0f; // Used in playerMovement, how long the player must be sprinting for to make them skid to a stop and turn around upon stopping or pressing the opposite direction.
}
