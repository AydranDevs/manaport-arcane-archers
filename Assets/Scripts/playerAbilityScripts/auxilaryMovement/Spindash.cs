using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spindash : MonoBehaviour {
    private Player player;
    private PlayerAbilities playerAbilities;
    private Rigidbody2D rb;
    private PlayerMovement playerMovement;

    public float range; // default 5
    public float speed; // default 5
    public float time;
    public float timeLimiit;

    [SerializeField]
    public Vector3 dashTarget;

    private void Awake() {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        playerAbilities = GetComponent<PlayerAbilities>();
        playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        rb = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
        time = timeLimiit;
    }

    private void Update() {
        if (player.auxilaryType == AuxilaryMovementType.Spindash && player.ability == AbilityState.AuxilaryMovement) {
            dashTarget = player.transform.position + (Vector3)playerMovement.reconstructedMovement * range;

            time -= Time.deltaTime;

            float step =  speed * Time.deltaTime; // calculate distance to move
            player.transform.position = Vector3.MoveTowards(player.transform.position, dashTarget, step);

            if (time <= 0f) {
                playerAbilities.abilitiesAvailable = false;
                playerAbilities.abilityCooldown = playerAbilities.abilityCooldownLimit;
                time = timeLimiit;
            }
        }
    }

    
}
