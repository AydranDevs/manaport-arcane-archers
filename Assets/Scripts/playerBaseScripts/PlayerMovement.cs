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
        Debug.Log(move);

        if (move.Equals(new Vector2(0, 0))) return;

        Vector3 position = player.transform.position;
        
        // lastPosition = position;
        // var direction = position - lastPosition;
        // var localDirection = position.InverseTransformDirection(direction);
        

        float xDiff = move.x;
        float yDiff = move.y;
        float angle = (float)(Mathf.Atan2(yDiff, xDiff));

        float dist;
        if(isMoving == movementState.Run){
            dist=sprintModifier;
        }else{
        dist = 1;
        }

        // if(isMoving == movementState.Skid){
        //
        // }

        Vector2 reconstructedMovement = new Vector2(Mathf.Cos(angle) * dist, Mathf.Sin(angle) * dist);
        player.GetComponent<Rigidbody2D>().MovePosition(new Vector2(position.x, position.y) + ((reconstructedMovement * speed) * d));
    }

}
