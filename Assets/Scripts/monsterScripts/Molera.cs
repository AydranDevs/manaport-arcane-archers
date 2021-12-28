using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Molera : MonoBehaviour, IPlayerDamageable {
    
    public float hitPointsMax = 10f;
    public float hitPoints;

    public float dps;
    public float dpsTimer = 1f;

    public int dpsCountMax = 20;
    public int dpsCount = 20;

    public bool isOnFire = false;
    public bool isFreezing = false;
    public bool isZapped = false;
    public bool isPoisoned = false;

    private bool fireParActive = false;
    private bool iceParActive = false;
    private bool toxicParActive = false;

    public Transform parent;

    [SerializeField]
    private Transform pfDust;
    [SerializeField]
    private Transform pfFire;
    [SerializeField]
    private Transform pfIce;
    [SerializeField]
    private Transform pfLightning;
    [SerializeField]
    private Transform pfToxic;
    [SerializeField]
    private Transform pfCrit;

    private void Awake() {
        hitPoints = hitPointsMax;
    }
    
    // When this Monster takes damage, this function is called.
    // it brings in baseDamage, critDamage, statusType and dps 
    // from the bullet that hit it.

    public void Damage(float damage, float critDamage, bool crit, bool status, string statusType, float dps) {

        // Logs the bullet stats on hit.

       Debug.Log("Damage: " + damage + " | Crit Damage: " + critDamage + "| Crit? " + crit + " | Status? " + status + " | Element: " + statusType + " | Damage/sec: " + dps); 

       // Applies debuffs.

        if (statusType == "Pyro") {isOnFire = true;}
        if (statusType == "Cryo") {isFreezing = true;}
        if (statusType == "Bolt") {isZapped = true;}
        if (statusType == "Toxi") {isPoisoned = true;}

        this.dps = dps;

       // Subtracts the bullet damage from hp.

       hitPoints -= damage;

       // Logs final hp calc.

       Debug.Log("Health: " + hitPoints);

       HandleParticles(statusType, crit);

       if (hitPoints <= 0f) Die();
    }

    // This function is only called if this Monster
    // need to take damage from a status effect.

    public void DamageOverTime() {
        if (hitPoints <= 0f) {
            Die();
            return;
        }

        hitPoints -= dps;
        dpsCount -= 1;

        Debug.Log("Damage/sec: " + dps);
        Debug.Log("Health " + hitPoints);
    }

    // this function spawns particles when needed.

    private void HandleParticles(string statusType, bool isCrit) {
        if (isCrit) {
            Transform crit = Instantiate(pfCrit, GetPosition(), Quaternion.identity, parent);
        }
        
        if (statusType == "Arcane") { 
            Transform dust = Instantiate(pfDust, GetPosition(), Quaternion.identity, parent);
        }else if (isOnFire && !fireParActive) {
            Transform fire = Instantiate(pfFire, GetPosition(), new Quaternion(-1f, 0f, 0f, 1f), parent);
            fireParActive = true;
        }else if (isFreezing && !iceParActive) {
            Transform ice = Instantiate(pfIce, GetPosition(), Quaternion.identity, parent);
            iceParActive = true;
        }else if (isZapped) {
            Transform lightning = Instantiate(pfLightning, GetPosition(), Quaternion.identity, parent);
        }else if (isPoisoned && !toxicParActive) {
            Transform toxic = Instantiate(pfToxic, GetPosition(), Quaternion.identity, parent);
            toxicParActive = true;
        }
        
    }

    private void Update() {

        /* 
        This is a 1s timer. every time this timer hits 0,
        it is reset back to 1, and the DamageOverTime method 
        is called. essentially, there is a 1 in 20 chance that
        the debuff is removed on the first tick of damage. with
        every tick of damage, the chance of the debuff getting
        removed is higher, until the dpsCount is zero, where 20s
        have passed and the debuff is removed. 
        */

        float timerMax = 1f;
        
        if (hitPoints <= 0f) {
            Die();
            return;
        }
        
        dpsTimer = dpsTimer - Time.deltaTime;
        if (dpsTimer <= 0) {
            if(isOnFire) {DamageOverTime();}
            if(isFreezing) {DamageOverTime();}
            if(isZapped) {DamageOverTime();}
            if(isPoisoned) {DamageOverTime();}

            int dpsRand = Random.Range(1,dpsCount);
            if(dpsRand == 1) {

                // remove all debuffs
                isOnFire = false;
                isFreezing = false;
                isZapped = false;
                isPoisoned = false;

                // reset dpsCount
                dpsCount = dpsCountMax;
            }
            dpsTimer = timerMax;
        }
    }

    public Vector3 GetPosition() {
        return transform.position;
    }

    public void Die() {
        Destroy(gameObject);
    }
}
