using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoleraAI : MonoBehaviour {

    /*
    Molera is a like a turret. It stays stationary
    whilst using midrange claw attacks to harm
    Laurie and her party.
    */

    // This list holds every instance of a target within the monster's view radius
    // private static List<EnemyTarget> targets;

    private Molera molera;

    // This monster can see this far in units. 
    [SerializeField]
    private float viewRadius;
    


    private void Awake() {
        molera = GetComponent<Molera>();
    }

   




}
