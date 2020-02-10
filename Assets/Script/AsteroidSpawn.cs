using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawn : MonoBehaviour {

    public GameObject asteroid;

    private float releaseAsteroidTimer;
    public float releaseAsteroidCooldoown;

    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        releaseAsteroidTimer += Time.deltaTime;

        if (releaseAsteroidTimer > releaseAsteroidCooldoown) {
            Vector3 spawnPosition = new Vector3(Random.Range(-1.7f, 1.7f), 6.34f, 0);
            Instantiate(asteroid, spawnPosition, Quaternion.identity);
            releaseAsteroidTimer = Time.deltaTime;
        }

    }
}
