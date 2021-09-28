using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : PlayerMain{
    Rigidbody2D rb;

    void Start(){
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate(){
        if (gameStateManager.inMenu == menuState.None){
            update(Time.fixedDeltaTime);
        }
    }

    public void update(float d){

        // Debug.Log("moving update working");
        // Debug.Log(move);

        if (playerStateManager.move.Equals(new Vector2(0, 0))) return;

        Vector3 position = playerStateManager.transform.position;
        
        // lastPosition = position;
        // var direction = position - lastPosition;
        // var localDirection = position.InverseTransformDirection(direction);
        

        float xDiff = playerStateManager.move.x;
        float yDiff = playerStateManager.move.y;
        float angle = (float)(Mathf.Atan2(yDiff, xDiff));

        float dist;
        if(playerStateManager.movementType == movementState.Run){
            dist=playerStateManager.sprintModifier;
        }else{
        dist = 1;
        }

        // if(isMoving == movementState.Skid){
        //
        // }

        Vector2 reconstructedMovement = new Vector2(Mathf.Cos(angle) * dist, Mathf.Sin(angle) * dist);
        rb.MovePosition(new Vector2(position.x, position.y) + ((reconstructedMovement * playerStateManager.speed) * d));
    }

}
