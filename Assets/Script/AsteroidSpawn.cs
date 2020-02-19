using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawn : MonoBehaviour {

    public GameObject asteroid;

    private float releaseAsteroidTimer;
    public float releaseAsteroidCooldoown;
    public bool dontSpawn = true;

    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        releaseAsteroidTimer += Time.deltaTime;

        if (releaseAsteroidTimer > releaseAsteroidCooldoown) {
            Vector3 spawnPosition = new Vector3(Random.Range(-1.7f, 1.7f), 6.34f, 0);
            GameObject asteroidSpawned = Instantiate(asteroid, spawnPosition, Quaternion.identity);
            asteroidSpawned.GetComponent<Rigidbody2D>().AddTorque(Random.Range(0,8), ForceMode2D.Impulse);
            asteroidSpawned.transform.localScale = Vector2.one * Random.Range(0.2f, 0.6f);
            releaseAsteroidTimer = Time.deltaTime;
        }

    }
}
