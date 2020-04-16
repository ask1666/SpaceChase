using System;
using System.Collections;
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
        if (collision.gameObject.tag.Equals("Player") || collision.gameObject.tag.Equals("ShieldEffect")) {
            StartCoroutine(doExplosion());
            if (this.gameObject.tag.Equals("Coin")) {
                Coin();
            } else if (this.gameObject.tag.Equals("Fuel")) {
                Fuel();
            } else if (this.gameObject.tag.Equals("Ammo")) {
                Ammo();
            } else if (this.gameObject.tag.Equals("Magnet")) {
                Magnet(collision.gameObject);
            } else if (this.gameObject.tag.Equals("Shield")) {
                Shield(collision.gameObject);
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

        GameObject.Find("GameControl").GetComponent<Score>().RefillAmmo();
        
    }

    void Fuel() {
        GameObject.Find("JetPackPanel").GetComponent<JetPackBar>().RefillJetPack();
    }

    void Coin() {
        GameObject.Find("GameControl").GetComponent<Score>().earnedCash += 5;
        GameObject.Find("GameControl").GetComponent<Score>().cash += 5;
    }

    void Magnet(GameObject player) {
        PlayerController playerController;
        if (player.tag.Equals("ShieldEffect")) {
            playerController = player.GetComponentInParent<PlayerController>();
        } else {
            playerController = player.GetComponent<PlayerController>();
        }
        if (playerController.magnetActive) {
            GameObject.Find("MagnetPanel").GetComponent<MagnetBarPanel>().magnetRefill();
        } else {
            playerController.magnetActive = true;
        }
    }

    void Shield(GameObject player) {
        PlayerController playerController;
        if (player.tag.Equals("ShieldEffect")) {
            playerController = player.GetComponentInParent<PlayerController>();
        } else {
            playerController = player.GetComponent<PlayerController>();
        }
        if (playerController.shieldActive) {
            GameObject.Find("ShieldPanel").GetComponent<ShieldPanel>().refillShield();
        } else {
            playerController.shieldActive = true;
        }
    }

    
}
