using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidExplosion : MonoBehaviour {

    public bool explode;
    public ParticleSystem explosion;
    public GameObject graphic;
    private float timeSinceExploded = 0.4f;

    // Start is called before the first frame update
    void Start() {

        explode = false;

    }

    // Update is called once per frame
    void Update() {
        timeSinceExploded += Time.deltaTime;
        if (explode == true && timeSinceExploded > 0.4f) {
            timeSinceExploded = 0;
            StartCoroutine(doExplosion());
        }

    }

    IEnumerator doExplosion() {

        Destroy(graphic);
        explosion.Play();
        yield return new WaitForSeconds(0.4f);
        Destroy(this.gameObject);

    }
}
