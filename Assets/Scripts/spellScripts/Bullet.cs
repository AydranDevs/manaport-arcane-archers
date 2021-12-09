using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
    private Burston burston;
    
    private Vector3 shootDir;

    public float damage;
    public float cooldown;
    public int cost;
    public float critChance;
    public float critDamage;

    public bool status;
    public string element;
    public float statusChance;
    public float dps;

    private void Awake() {
        burston = GameObject.FindGameObjectWithTag("Spellcaster").GetComponent<Burston>();

        burston.OnBurstonCast += BurstonBullet_OnBurstonCast;
    }

    public void BurstonBullet_OnBurstonCast(object sender, Burston.OnBurstonCastEventArgs e) {
        // Destroy(gameObject, 2f);
        
        shootDir = e.shootDir;

        damage = e.baseDamage;
        cooldown = e.baseCooldown;
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
        Dummy dummy = collider.GetComponent<Dummy>();
        if (dummy != null) {
            // Hit a dummy
            dummy.Damage(damage, critDamage, status, element, dps);
            Destroy(gameObject);
        }
        
    }
}
