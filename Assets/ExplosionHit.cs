using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionHit : MonoBehaviour {

    public Collider2D explosionCollider;

    // Start is called before the first frame update
    

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag.Equals("Player")) {
            ObstacleExplosion.killPlayer();
        } 
    }
}
