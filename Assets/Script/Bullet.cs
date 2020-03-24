﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public float bulletSpeed;
    public AudioSource impactSound;
    public Animator explosion;
    public GameObject graphic;
    public bool explode;
    public float speed;

    // Start is called before the first frame update
    void Start() {
        explode = false;
    }

    // Update is called once per frame
    void Update() {
        if (!explode) {
            this.gameObject.transform.Translate(Vector2.up * bulletSpeed);
        } else {
            this.gameObject.transform.Translate(Vector2.down * speed);
        }
    }

    

    private void OnTriggerEnter2D(Collider2D collision) {
        try {
            if (collision.gameObject.tag.Equals("Asteroid") || collision.gameObject.tag.Equals("Garbage")) {
                collision.gameObject.GetComponent<ObstacleExplosion>().explode = true;
                explosion.SetTrigger("explode");
                impactSound.Play();
                explode = true;
                Destroy(graphic);
            } else if (collision.gameObject.tag.Equals("Mine")) {
                collision.gameObject.GetComponent<MineExplosion>().explode = true;
                impactSound.Play();
                explosion.SetTrigger("explode");
                explode = true;
                Destroy(graphic);
            } else if (collision.gameObject.tag.Equals("Enemy")) {
                collision.gameObject.GetComponent<EnemyController>().Die();
                impactSound.Play();
                explosion.SetTrigger("explode");
                explode = true;
            }
        } catch (UnassignedReferenceException) {
            if (collision.gameObject.tag.Equals("Asteroid") || collision.gameObject.tag.Equals("Garbage")) {
                collision.gameObject.GetComponent<ObstacleExplosion>().explode = true;
            } else if (collision.gameObject.tag.Equals("Mine")) {
                collision.gameObject.GetComponent<MineExplosion>().explode = true;
            }
        }
    }


}
