using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionOnTrigger : MonoBehaviour {
    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag.Equals("Mine")) {
            collision.gameObject.GetComponent<MineExplosion>().explode = true;
        } else if (collision.gameObject.tag.Equals("Asteroid")) {
            collision.gameObject.GetComponent<ObstacleExplosion>().explode = true;
        } else if (collision.gameObject.tag.Equals("Garbage")) {
            collision.gameObject.GetComponent<ObstacleExplosion>().explode = true;
        } 
    }
}
