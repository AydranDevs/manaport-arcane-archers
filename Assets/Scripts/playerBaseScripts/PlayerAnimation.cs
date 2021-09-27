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

        animator.SetBool("walking", (Mathf.Abs(move.x) < 0.05 && Mathf.Abs(move.y) < 0.05));
        if (!(Mathf.Abs(move.x) < 0.05 && Mathf.Abs(move.y) < 0.05)){
            animator.SetFloat("y", move.y);
            animator.SetFloat("x", move.x);
        }
        
       float isSprinting;
        if(isMoving == movementState.Run){
                isSprinting=sprintModifier;
            }else{
            isSprinting = 1;
            }

        if(isSprinting == 2){
                animator.SetBool("running", true);
            }else{
                animator.SetBool("running", false);
            }

        //if(Input.GetKeyDown(KeyCode.E))
        //    {
        //        animator.SetBool("isSkidding", true);
        //    }else
        //    {
        //        animator.SetBool("isSkidding", false);
        //    }
    }
}
