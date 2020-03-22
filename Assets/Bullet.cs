using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public float bulletSpeed;

    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        this.gameObject.transform.Translate(Vector2.up * bulletSpeed);
    }

    

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag.Equals("Asteroid") || collision.gameObject.tag.Equals("Garbage")) {
            collision.gameObject.GetComponent<ObstacleExplosion>().explode = true;
        } else if (collision.gameObject.tag.Equals("Mine")) {
            collision.gameObject.GetComponent<MineExplosion>().explode = true;
        }
    }


}
