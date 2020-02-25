using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpExplosion : MonoBehaviour {

    public ParticleSystem explosion;
    public GameObject graphic;
    public Collider2D theCollider;
    public Animator animator;

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
        yield return new WaitForSeconds(0.4f);
        Destroy(this.gameObject);

    }

    void Ammo() {

    }

    void Fuel() {

    }

    void Coin() {
        GameObject.Find("GameControl").GetComponent<Score>().cash += 1;
    }
}
