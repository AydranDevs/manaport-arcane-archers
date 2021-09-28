using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : PlayerMain{

    void Update(){
        if (gameStateManager.inMenu == menuState.None){
            update();
        }
    }

    public void update(){
    if (!(Mathf.Abs(playerStateManager.move.x) < 0.05 && Mathf.Abs(playerStateManager.move.y) < 0.05)){
    animator.SetFloat("y", playerStateManager.move.y);
    animator.SetFloat("x", playerStateManager.move.x);
    }
    
    if(playerStateManager.movementType == movementState.Idle){
        animator.SetBool("idle", true);
    }else{
        animator.SetBool("idle", false);
    }

    if(playerStateManager.movementType == movementState.Walk){
        animator.SetBool("walking", true);
    }else{
        animator.SetBool("walking", false);
    }
    
    if(playerStateManager.movementType == movementState.Run){
        animator.SetBool("running", true);
    }else{
        animator.SetBool("running", false);
    }

    if(playerStateManager.movementType == movementState.Skid){
        animator.SetBool("skidding", true);
    }else{
        animator.SetBool("skidding", false);
    }

    animator.SetFloat("y", playerStateManager.move.y);
    animator.SetFloat("x", playerStateManager.move.x);

    switch (playerStateManager.facing){
        case facingState.North:
                animator.SetFloat("facing", 0f);
            break;
        case facingState.East:
                animator.SetFloat("facing", 1f);
            break;
        case facingState.South:
                animator.SetFloat("facing", 2f);
            break;
        case facingState.West:
                animator.SetFloat("facing", 3f);
            break;
    }

    //     animator.SetBool("walking", (Mathf.Abs(playerStateManager.move.x) < 0.05 && Mathf.Abs(playerStateManager.move.y) < 0.05));
    //     if (!(Mathf.Abs(playerStateManager.move.x) < 0.05 && Mathf.Abs(playerStateManager.move.y) < 0.05)){
    //         animator.SetFloat("y", playerStateManager.move.y);
    //         animator.SetFloat("x", playerStateManager.move.x);
    //     }
        
    //    float isSprinting;
    //     if(playerStateManager.movementType == movementState.Run){
    //             isSprinting = playerStateManager.sprintModifier;
    //         }else{
    //         isSprinting = 1;
    //         }

    //     if(isSprinting == 2){
    //             animator.SetBool("running", true);
    //         }else{
    //             animator.SetBool("running", false);
    //         }

        //if(Input.GetKeyDown(KeyCode.E))
        //    {
        //        animator.SetBool("isSkidding", true);
        //    }else
        //    {
        //        animator.SetBool("isSkidding", false);
        //    }
    }
}
