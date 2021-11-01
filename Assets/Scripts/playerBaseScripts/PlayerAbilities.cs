using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAbilities : MonoBehaviour {

    private Player player;
    private Controls controls;
    private Spindash spindash;
    private Lightspeed lightspeed;
    
    public float abilityCooldownLimit = 10; // The default cooldown time after using an ability
    public float abilityCooldown; // Set to the CooldownLimit, default 10 seconds
    public bool abilitiesAvailable = false; // Set to true when the cooldown is over

    private void Awake() {
        abilityCooldown = abilityCooldownLimit; // Sets cooldown time to whatever CooldownLimit is set to
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        controls = GameObject.FindGameObjectWithTag("Player").GetComponent<Controls>();
        spindash = GetComponent<Spindash>();
        lightspeed = GetComponent<Lightspeed>();
    }

    private void Update() {
        abilityCooldown = abilityCooldown - Time.deltaTime; // uses Time.deltaTime to make cooldown a consistent x seconds.

        if (abilityCooldown <= 0f) {
            abilitiesAvailable = true;  
        }else {
            abilitiesAvailable = false;
            player.ability = AbilityState.None;
        }

        if (controls.buttonAuxilaryMovement == true && abilitiesAvailable == true) {
            player.ability = AbilityState.AuxilaryMovement;
        }



        
    }

}