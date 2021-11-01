using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lightspeed : MonoBehaviour {
    private Player player;
    private PlayerAbilities playerAbilities;
    private Rigidbody2D rb;
    private PlayerMovement playerMovement;

    public float range; // default 5
    public float speed; // default 5
    public float angle;
    public float dist;

    private void Awake() {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        playerAbilities = GetComponent<PlayerAbilities>();
        playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        rb = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
    }

    private void Update() {
        if (player.auxilaryType == AuxilaryMovementType.Lightspeed && player.ability == AbilityState.AuxilaryMovement) {
            
            player.transform.position += (Vector3)playerMovement.reconstructedMovement * range;
            playerAbilities.abilitiesAvailable = false;
            playerAbilities.abilityCooldown = playerAbilities.abilityCooldownLimit;
        }
    }
}
