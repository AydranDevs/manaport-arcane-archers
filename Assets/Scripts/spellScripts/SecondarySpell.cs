using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondarySpell : Spell {
    private Player player;
    private GameStateManager gameStateManager;

    private Blasteur blasteur;
    private Burston burston;
    private Automa automa;

    private void Start() {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        gameStateManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameStateManager>();

        automa = GetComponent<Automa>();
        burston = GetComponent<Burston>();
        blasteur = GetComponent<Blasteur>();
    }

    /* This doesnt have to happen in LateUpdate()! Planning 
    to call the functions here when a spellstone change is 
    detected. For now it stays in LateUpdate. */

    private void LateUpdate() {
        if (gameStateManager.state == GameState.Main) {
            CheckSpellType();
            CheckElementType();

            if (player.ability == AbilityState.SpellcastSecondary) {
                // burston.SetStats(false);
                automa.SetStats(false);
                blasteur.SetStats(false);
            }
        }

        // Debug.Log((spellInfo.type) + (spellInfo.element));
    }

    // Checks Primary Spell Type enum in Player.cs whenever this function is called
    
    private void CheckSpellType() {
        if (player.primary == PrimarySpellType.Automa) {
            spellInfo.type = "Automa";
        }else if (player.primary == PrimarySpellType.Blasteur) {
            spellInfo.type = "Blasteur";
        }else if (player.primary == PrimarySpellType.Burston) {
            spellInfo.type = "Burston";
        }
    }

    // Check Primary Spell Element enum in Player.cs whenever this function is called

    private void CheckElementType() {
        if (player.primaryElement == PrimarySpellElement.Pyro) {
            spellInfo.element = "Pyro";
        }else if (player.primaryElement == PrimarySpellElement.Cryo) {
            spellInfo.element = "Cryo";
        }else if (player.primaryElement == PrimarySpellElement.Toxi) {
            spellInfo.element = "Toxi";
        }else if (player.primaryElement == PrimarySpellElement.Bolt) {
            spellInfo.element = "Bolt";
        }else { // Assumes element type as "Arcane" if not overriden by the other elements. (This may be a little small brained)
            spellInfo.element = "Arcane";
        }
    }
}
