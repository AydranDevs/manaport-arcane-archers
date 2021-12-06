using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Automa : Spell {
    private PrimarySpell primary;
    private SecondarySpell secondary;

    private Player player;

    public float baseDamage;
    public float baseSpread;
    public float baseFireRate;
    public int baseCost;
    public float critChance;
    public float critDamage;

    public bool status;
    public float statusChance;
    public float dps;


    private void Start() {
        primary = GetComponent<PrimarySpell>();
        secondary = GetComponent<SecondarySpell>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    public override void SetStats(bool isPrimary) {
        // Debug.Log("Spell cast!");
        
        if (isPrimary) {
            if (player.primaryElement == PrimarySpellElement.Arcane) { // Base stats for an Arcane Automa spellstone
                baseDamage = 2f;
                baseSpread = 5f;
                baseFireRate = 0.2f;
                baseCost = 1;
                critChance = 0.10f;
                critDamage = 3f;
                status = false;

                statusChance = 0f;
                dps = 0f;
            }else { // Base stats for an Elemental Automa spellstone
                baseDamage = 3f;
                baseSpread = 5f;
                baseFireRate = 0.2f;
                baseCost = 1;
                critChance = 0.10f;
                critDamage = 6f;
                status = true;

                statusChance = 0.15f;
                dps = 2f;
            }
        }else {
            if (player.primaryElement == PrimarySpellElement.Arcane) { // Secondary stats for an Arcane Automa spellstone
                baseDamage = 1.5f;
                baseSpread = 5f;
                baseFireRate = 0.2f;
                baseCost = 1;
                critChance = 0.10f;
                critDamage = 2f;
                status = false;

                statusChance = 0f;
                dps = 0f;
            }else { // Secondary stats for an Elemental Automa spellstone
                baseDamage = 2f;
                baseSpread = 5f;
                baseFireRate = 0.2f;
                baseCost = 1;
                critChance = 0.10f;
                critDamage = 3f;
                status = true;

                statusChance = 0.15f;
                dps = 2f;
            }
        }
    }
}
