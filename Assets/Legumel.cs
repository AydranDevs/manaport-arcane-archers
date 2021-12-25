using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Legumel : MonoBehaviour, IDamageable {
    
    public float hitPointsMax = 100f;
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

    public void DamageOverTime() {
        hitPoints -= dps;
        dpsCount -= 1;

        Debug.Log("Damage/sec: " + dps);
        Debug.Log("Health " + hitPoints);
    }

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
        float timerMax = 1f;

        dpsTimer = dpsTimer - Time.deltaTime;
        if (dpsTimer <= 0) {
            if(isOnFire) {DamageOverTime();}
            if(isFreezing) {DamageOverTime();}
            if(isZapped) {DamageOverTime();}
            if(isPoisoned) {DamageOverTime();}

            int dpsRand = Random.Range(1,dpsCount);
            if(dpsRand == 1) {
                isOnFire = false;
                isFreezing = false;
                isZapped = false;
                isPoisoned = false;

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
