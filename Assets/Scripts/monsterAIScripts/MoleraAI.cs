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
    private static List<EnemyTarget> targets;

    // This list holds every instance of enemy type Molera.
    private static List<MoleraAI> moleraList;

    private Molera molera;
    private CircleCollider2D detRange;

    // This monster can see this far in units. 
    [SerializeField]
    private float viewRadius;
    


    private void Awake() {
        molera = GetComponent<Molera>();
        detRange = GetComponent<CircleCollider2D>();

        // create lists if they dont exist
        if (targets == null) targets = new List<EnemyTarget>();
        if (moleraList == null) moleraList = new List<MoleraAI>();

        // Add this instance of molera to the list
        moleraList.Add(this);

        // set the detection range to viewRadius
        detRange.radius = viewRadius;
    }

    private void OnTriggerEnter2D(Collider2D target) {
        EnemyTarget enemyTarget = target.GetComponent<EnemyTarget>();

        if (enemyTarget != null) {
            // a target has entered the detection range

            // add the target to the list!
            targets.Add(enemyTarget);
            Debug.Log("target detected (molera)");
        }
    }

    private Vector3 GetPosition() {
        return transform.position;
    }

    // private Vector3 GetTargetPosition() {
    //    return EnemyTarget.transform.position;
    // }

   




}
