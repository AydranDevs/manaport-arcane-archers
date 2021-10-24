using UnityEngine;

public enum MovementState { Idle, Walk, Run, Skid }
public enum DirectionState { North, NorthEast, East, SouthEast, South, SouthWest, West, NorthWest }
public enum FacingState { North, East, South, West }

// This class could hold all the values for player which would make for a nice singular place for everything
// to access them.  Sorta like the PlayerStateManager before

// But it might make more sense to move these values to the script that use them, like putting the speed in the
// PlayerMovement script
public class Player : MonoBehaviour
{
    // Movement
    public MovementState movementType = MovementState.Idle; // sets "isMoving" to None / Initializes MovementState
    public DirectionState direction = DirectionState.South; // sets "isDirection" to South / Initializes DirectionState
    public FacingState facing = FacingState.South; // sets "isFacing" to South / Initializes FacingState

    public Vector2 move = new Vector2(0, 0); // Used in playerMovement, determines the directin the player is moving
    public float speed = 0.1f; // Used in playerMovement, Units/sec
    public float sprintModifier = 1.25f; // Used in playerMovement, multiplies speed by value set here
    public float skidThreshold = 0f; // Used in playerMovement, how long the player must be sprinting for to make them skid to a stop and turn around upon stopping or pressing the opposite direction.
}
