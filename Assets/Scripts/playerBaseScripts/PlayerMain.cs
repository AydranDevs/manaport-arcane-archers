using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// public enum movementState { Idle, Walk, Run, Skid }
// public enum directionState { North, NorthEast, East, SouthEast, South, SouthWest, West, NorthWest }
// public enum facingState { North, East, South, West }

public class PlayerMain : MonoBehaviour{
    public Animator animator; // Instantiates "animator" GameObject
    public PlayerMain player; // Instantiates playerMain as "player" for inheriting scripts
    public GameStateManager gameStateManager; // Instantiates gameManager script for gamestates such as menus
    public PlayerStateManager playerStateManager; // Instantiates playerManager script for playerstates such as movementtype, direction, and facingdirection

    // public menuState inMenu = menuState.None; // sets "inMenu" to None / Initializes menuState
    // public movementState isMoving = movementState.Idle; // sets "isMoving" to None / Initializes movementState

    // public Vector2 move = new Vector2(0, 0); // Used in playerMovement, determines the directin the player is moving
    // public float speed = 0.1f; // Used in playerMovement, Units/sec
    // public float sprintModifier = 1.25f; // Used in playerMovement, multiplies speed by value set here
    // public float skidThreshold = 0f; // Used in playerMovement, how long the player must be sprinting for to make them skid to a stop and turn around upon stopping or pressing the opposite direction.

    public PlayerInput playerInput; 
    public PlayerMovement playerMovement;
    public PlayerAnimation playerAnimation;

    private bool initialized = true;
    public bool Initialized{
        get { return initialized; }
        //set { initialized = value; }
    }

    public static PlayerMain INSTANCE;

    void Awake(){
        INSTANCE = this;
        animator = GameObject.FindGameObjectWithTag("PlayerAnimator").GetComponent<Animator>(); //instantiates Animator GameObject
        
        // Script instantiation - Managers
        gameStateManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameStateManager>(); 
        playerStateManager = GameObject.FindGameObjectWithTag("PlayerManager").GetComponent<PlayerStateManager>();
        
        // Script instantiation - Actual base playercontroller shit
        playerInput = GetComponent<PlayerInput>();
        playerMovement = GetComponent<PlayerMovement>();
        playerAnimation = GetComponent<PlayerAnimation>();


        // keyIndicator = GameObject.FindGameObjectWithTag("KeyText").GetComponent<TMPro.TextMeshProUGUI>();

        // Disabling loading of data for christmas demo
        // consumableInv.Load();
        // equipmentInv.Load();
        // mainAttr.Load();
    }
    void OnApplicationQuit(){

        // consumableInv.Save();
        // equipmentInv.Save();
        // mainAttr.Save();
    }
    void Update(){
        if (gameStateManager.inMenu == menuState.None){
        //    PlayerAnimation.update();
        //    PlayerInput.update();
        }
    }
}
