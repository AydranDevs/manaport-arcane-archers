using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controls : MonoBehaviour {
    public bool buttonSpellcastPrimary = false;
    public bool buttonSpellcastSecondary = false;
    public bool buttonAuxilaryMovement = false;
    public bool buttonInventory = false;
    public bool buttonEquipment = false;
    public bool buttonBestiary = false;
    public bool buttonSlot1 = false;
    public bool buttonSlot2 = false;
    public bool buttonPause = false;
    public bool buttonMap = false;
    
    // primary default : left click; R1; RB
    // secondary default : left click; L1; LB
    // auxilary default : spacebar; X; A
    // inv default : B; triangle; Y
    // equip default : E; square; X
    // bestiary default : R; circle; B
    // slot1 default : 1; R2; RT
    // slot2 default : 2; L2; LT
    // pause default : esc; options; menu
    // map default : tab; touchpad; view

    public void Update() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            buttonAuxilaryMovement = true;
        }
        if (Input.GetKeyUp(KeyCode.Space)) {
            buttonAuxilaryMovement = false;
        }
    }
}