using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSpawner : MonoBehaviour {

    public GameObject coin;
    public GameObject ammo;
    public GameObject fuel;

    private float releaseTimer;
    private float randomNr;
    public float coinChance;
    public float ammoChance;
    public float fuelChance;
    public float releaseCooldown;
    public bool dontSpawn = true;

    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {

        releaseTimer += Time.deltaTime;
        if (releaseTimer > releaseCooldown) {
            randomNr = Random.Range(0.0f, 1.0f);
            Vector3 spawnPosition = new Vector3(Random.Range(-1.7f, 1.7f), 6.34f, 0);
            if (randomNr >= (1 - coinChance)) {
                GameObject coinSpawned = Instantiate(coin, spawnPosition, Quaternion.identity);
            } else if (randomNr >= (1 - ammoChance)) {
                GameObject ammoSpawned = Instantiate(ammo, spawnPosition, Quaternion.identity);
            } else if (randomNr >= (1 - fuelChance)) {
                GameObject fuelSpawned = Instantiate(fuel, spawnPosition, Quaternion.identity);
            }
            releaseTimer = Time.deltaTime;
        }
    }
}
