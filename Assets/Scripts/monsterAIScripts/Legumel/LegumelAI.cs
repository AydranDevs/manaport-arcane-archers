using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
This script actually does AI things.
*/

public class LegumelAI : MonoBehaviour, IEnemyAI {

    public event EventHandler<OnRoamWaitOverArgs> OnRoamWaitOver;
    public class OnRoamWaitOverArgs : EventArgs { public float dist; }
    
    // minimum and maximum possible legnths the AI can roam
    private const float MIN_ROAM_DIST = 3f;
    private const float MAX_ROAM_DIST = 6f;
    
    // minimum and maximum possible times the AI can wait before roaming a random distance
    private const float MIN_ROAM_WAIT = 1f;
    private const float MAX_ROAM_WAIT = 7.5f;

    public Vector2 move = new Vector2(0, 0);

    private float waitTime = 0f;
    private bool awaitingWaitTime = true;
    
    private float roamDist = 0f;
    
    public LegumelAIStateHandler stateHandler;

    private bool currentlyWaiting = false; // pretty much used to check if lil nut boy is roaming

    private void Awake() {
        
        stateHandler = GetComponent<LegumelAIStateHandler>();

    }

    private void Update() {
        if (stateHandler.aIState == AIState.Roam) {
            if (!currentlyWaiting) {
                roamDist = GetRandomRoamDist();
                // stateHandler.aIMovementState = AIMovementState.Walk;
                currentlyWaiting = true;
            } else {
                RoamWaitUpdate();
                // stateHandler.aIMovementState = AIMovementState.Idle;
            }
        }
    }

    private void RoamWaitUpdate() {
        
        
        if (awaitingWaitTime) {
            waitTime = GetRandomRoamWaitTime();
            awaitingWaitTime = false;
        }

        waitTime = waitTime - Time.deltaTime;
        if (waitTime <= 0f) {
            OnRoamWaitOver?.Invoke(this, new OnRoamWaitOverArgs { dist = roamDist });
            
            currentlyWaiting = false;
            awaitingWaitTime = true;
        }
    }

    private float GetRandomRoamWaitTime() {
        return UnityEngine.Random.Range(MIN_ROAM_WAIT, MAX_ROAM_WAIT);
    }

    private float GetRandomRoamDist() {
        return UnityEngine.Random.Range(MIN_ROAM_DIST, MAX_ROAM_DIST);
    }
}
