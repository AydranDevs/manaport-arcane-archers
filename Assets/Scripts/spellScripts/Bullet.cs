using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
    private Burston burston;
    private Automa automa;
    
    private Vector3 shootDir;

    public float damage;
    public float cooldown;
    public float spread;
    public float fireCount;
    public int cost;
    public float critChance;
    public float critDamage;

    public bool crit;

    public bool status;
    public string element;
    public float statusChance;
    public float dps;

    private void Awake() {
        burston = GameObject.FindGameObjectWithTag("Spellcaster").GetComponent<Burston>();
        automa = GameObject.FindGameObjectWithTag("Spellcaster").GetComponent<Automa>();

        burston.OnBurstonCast += BurstonBullet_OnBurstonCast;
        automa.OnAutomaCast += AutomaBullet_OnAutomaCast;
    }

    public void BurstonBullet_OnBurstonCast(object sender, Burston.OnBurstonCastEventArgs e) {
        // Destroy(gameObject, 2f);
        
        shootDir = e.shootDir;

        damage = e.baseDamage;
        cooldown = e.baseCooldown;
        cost = e.baseCost;
        critChance = e.critChance;
        critDamage = e.critDamage;

        crit = e.crit;

        status = e.status;
        element = e.element;
        
        statusChance = e.statusChance;
        dps = e.dps;

        if (crit) damage = critDamage;
    }

    public void AutomaBullet_OnAutomaCast(object sender, Automa.OnAutomaCastEventArgs e) {
        shootDir = e.shootDir;

        damage = e.baseDamage;
        cooldown = 0f;
        spread = e.baseDamage;
        fireCount = e.baseFireCount;
        cost = e.baseCost;
        critChance = e.critChance;
        critDamage = e.critDamage;

        status = e.status;
        element = e.element;

        statusChance = e.statusChance;
        dps = e.dps;
    }

    private void Update() {
        float moveSpeed = 50f;
        transform.position += shootDir * moveSpeed * Time.deltaTime;

        /* float hitDetectionSize = 3f;
        Dummy dummy = Dummy.GetClosest(transform.position, hitDetectionSize);
        if (dummy != null) {
            Debug.Log("Bullet hit something!");
            dummy.Damage();
            Destroy(gameObject);
        }*/
    }

    private void OnTriggerEnter2D(Collider2D collider) {
        IDamageable damageable = collider.GetComponent<IDamageable>();
        if (damageable != null) {
            // Hit a damagable entity
            damageable.Damage(damage, critDamage, crit, status, element, dps);
            Destroy(gameObject);
        }
        
    }
}
