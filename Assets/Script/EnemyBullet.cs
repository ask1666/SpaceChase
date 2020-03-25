﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour {

    public float speed;

    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        transform.Translate(Vector2.down * speed);
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag.Equals("Player")) {
            collision.gameObject.GetComponent<AudioSource>().Play();
            collision.gameObject.GetComponent<Animator>().applyRootMotion = false;
            collision.gameObject.GetComponent<Animator>().SetTrigger("NoFuel");
            StartCoroutine(ObstacleExplosion.killPlayer());
        }
    }
}