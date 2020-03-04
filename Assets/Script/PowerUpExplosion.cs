﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpExplosion : MonoBehaviour {

    public ParticleSystem explosion;
    public GameObject graphic;
    public Collider2D theCollider;
    public Animator animator;
    public AudioSource sound;

    // Start is called before the first frame update
    void Start() {


    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag.Equals("Player")) {
            StartCoroutine(doExplosion());
            if (this.gameObject.tag.Equals("Coin")) {
                Coin();
            } else if (this.gameObject.tag.Equals("Fuel")) {
                Fuel();
            } else if (this.gameObject.tag.Equals("Ammo")) {
                Ammo();
            }
        }
    }

    IEnumerator doExplosion() {

        Destroy(graphic);
        GetComponent<Rigidbody2D>().freezeRotation = true;
        animator.enabled = false;
        theCollider.enabled = false;
        explosion.Play();
        sound.Play();
        yield return new WaitForSeconds(0.4f);
        Destroy(this.gameObject);

    }

    void Ammo() {
        GameObject.Find("Gun").GetComponent<Gun>().RefillAmmo();
    }

    void Fuel() {
        GameObject.Find("JetPackPanel").GetComponent<JetPackBar>().RefillJetPack();
    }

    void Coin() {
        GameObject.Find("GameControl").GetComponent<Score>().earnedCash += 5;
        GameObject.Find("GameControl").GetComponent<Score>().cash += 5;
    }
}
