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
        playerStateManager.move = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")); 
        if(!playerStateManager.move.Equals(new Vector2(0,0))){
            playerStateManager.movementType = Input.GetKey(KeyCode.LeftShift) ? movementState.Run : movementState.Walk;   
        }else{
            playerStateManager.movementType = movementState.Idle;
        }
    }
}
