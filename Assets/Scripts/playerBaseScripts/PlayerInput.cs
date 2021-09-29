using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script, as it exsits now, might be better to just put in the PlayerMovement script instead.
public class PlayerInput : MonoBehaviour
{
    private GameStateManager gameStateManager;
    private PlayerMovement playerMovement;

    void Start()
    {
        gameStateManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameStateManager>();
        playerMovement = GetComponent<PlayerMovement>();
    }

    void Update()
    {
        if (gameStateManager.state == GameState.Main)
        {
            playerMovement.Move(Time.fixedDeltaTime);
        }
    }
}
