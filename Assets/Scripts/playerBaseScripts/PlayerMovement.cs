using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;
    private Player Player;
    private GameStateManager gameStateManager;
    public VectorValue vectorValue;

    public Vector2 reconstructedMovement;
    public float angle;

    public float runDuration;

    void Start() {
        rb = GetComponent<Rigidbody2D>();
        Player = GetComponent<Player>();
        Player.transform.position = vectorValue.initialValue;
    }

    public void Move(float d) {
        Player.move = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        if (!Player.move.Equals(new Vector2(0, 0))) {
            Player.movementType = Input.GetKey(KeyCode.LeftShift) ? MovementState.Run : MovementState.Walk;
        }else {
            Player.movementType = MovementState.Idle;
        }

        if (Player.move.Equals(new Vector2(0, 0))) return;

        Vector3 position = Player.transform.position;


        float xDiff = Player.move.x;
        float yDiff = Player.move.y;
        angle = (float)(Mathf.Atan2(yDiff, xDiff));

        float dist;
        if (Player.movementType == MovementState.Run) {
            dist = Player.sprintModifier;
        }else {
            dist = 1;
        }

        reconstructedMovement = new Vector2(Mathf.Cos(angle) * dist, Mathf.Sin(angle) * dist);
        rb.MovePosition(new Vector2(position.x, position.y) + ((reconstructedMovement * Player.speed) * d));        
    }
}