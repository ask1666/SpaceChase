using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineExplosion : MonoBehaviour {
    private float timeSinceExploded = 0.4f;
    public GameObject graphic;
    public Animator explodeAnimator;
    public Collider2D theCollider;
    public Animator animator;
    public AudioSource sound;
    public bool explode;

    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        timeSinceExploded += Time.deltaTime;
        if (explode == true && timeSinceExploded > 1f) {
            timeSinceExploded = 0;
            StartCoroutine(doExplosion());
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag.Equals("Player") && timeSinceExploded > 1f) {
            timeSinceExploded = 0;
            StartCoroutine(doExplosion());
            
        }
    }

    IEnumerator doExplosion() {

        Destroy(graphic);
        GetComponent<Rigidbody2D>().freezeRotation = true;
        animator.enabled = false;
        theCollider.enabled = false;
        explodeAnimator.SetTrigger("explode");
        sound.Play();
        yield return new WaitForSeconds(1f);
        Destroy(this.gameObject);
        ObstacleExplosion.killPlayer();

    }
}
