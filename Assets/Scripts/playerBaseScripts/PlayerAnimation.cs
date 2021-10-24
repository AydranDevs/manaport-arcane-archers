using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private GameStateManager gameStateManager;
    private Animator animator;
    private Player Player;

    void Start()
    {
        gameStateManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameStateManager>();
        Player = GetComponent<Player>();
        animator = GameObject.FindGameObjectWithTag("PlayerAnimator").GetComponent<Animator>(); //instantiates Animator GameObject
    }

    void Update()
    {
        if (gameStateManager.state == GameState.Main)
        {
            AnimatePlayer();
        }
    }

    public void AnimatePlayer()
    {
        if (Player.move.sqrMagnitude > 0f) {
            animator.SetFloat("y", Player.move.y);
            animator.SetFloat("x", Player.move.x);
        }

        if (Player.movementType == MovementState.Idle)
        {
            animator.SetInteger("mode", 0);
        }
        else if (Player.movementType == MovementState.Walk) {
            animator.SetInteger("mode", 1);
        }
        else if (Player.movementType == MovementState.Run) {
            animator.SetInteger("mode", 2);
        }
    }
}
