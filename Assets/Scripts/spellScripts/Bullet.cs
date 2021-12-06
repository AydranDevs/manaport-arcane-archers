using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
    private Burston burston;
    
    private Vector3 shootDir;

    // public void Setup(Vector3 shootDir) {
    //    this.shootDir = shootDir;
    //    Destroy(gameObject, 2f);
    // }

    private void Awake() {
        burston = GameObject.FindGameObjectWithTag("Spellcaster").GetComponent<Burston>();

        burston.OnBurstonCast += BurstonBullet_OnBurstonCast;
    }

    public void BurstonBullet_OnBurstonCast(object sender, Burston.OnBurstonCastEventArgs e) {
        shootDir = e.shootDir;

    }

    private void Update() {
        float moveSpeed = 50f;
        transform.position += shootDir * moveSpeed * Time.deltaTime;
    }
}
