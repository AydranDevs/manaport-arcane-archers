using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : PlayerMain{
    void Update(){
        if (gameStateManager.inMenu == menuState.None){
           // Debug.Log("No menus open (PlayerInput)");
            update();
        }
    }
    
    public void update(){
        move = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")); 
        if(!move.Equals(new Vector2(0,0))){
            isMoving = Input.GetKey(KeyCode.LeftShift) ? movementState.Run : movementState.Walk;   
        }

        // Debug.Log(move);
    }
}
