using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Class for destroying asteroids and other interactables that fall out of cameraview.
 */
public class AsteroidDestroyer : MonoBehaviour {


    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag.Equals("Player")) {
            StartCoroutine(ObstacleExplosion.killPlayer());
        } else {
            Destroy(collision.gameObject);
        }
    }
}
