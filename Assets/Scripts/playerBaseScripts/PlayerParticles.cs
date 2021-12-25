using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerParticles : MonoBehaviour {
    private PlayerMovement playerMovement;

    private void Start() {
        playerMovement = GetComponent<PlayerMovement>();

        playerMovement.OnDashStart += SummonParticles_OnDashStart;
    }

    public void SummonParticles_OnDashStart(object sender, PlayerMovement.OnDashStartEventArgs e) {
        Debug.Log("Dash started");
    }
}
