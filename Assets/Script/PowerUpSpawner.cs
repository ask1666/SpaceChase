using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Class for spawning powerups.
 */
public class PowerUpSpawner : MonoBehaviour {

    public GameObject coin;
    public GameObject ammo;
    public GameObject fuel;

    
    public float coinChance;
    public float ammoChance;
    public float fuelChance;
    public float releaseCooldown;
    public bool dontSpawn = true;
    float timer;

    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {

        timer += Time.deltaTime;
        
        if (timer > releaseCooldown) {
            if (Random.Range(0.0f, 1.0f) >= (1 - coinChance)) {
                GameObject coinSpawned = Instantiate(coin, new Vector3(Random.Range(-1.7f, 1.7f), 6.34f, 0), Quaternion.identity);
            }
            if (Random.Range(0.0f, 1.0f) >= (1 - ammoChance)) {
                GameObject ammoSpawned = Instantiate(ammo, new Vector3(Random.Range(-1.7f, 1.7f), 6.34f, 0), Quaternion.identity);
            }
            if (Random.Range(0.0f, 1.0f) >= (1 - fuelChance)) {
                GameObject fuelSpawned = Instantiate(fuel, new Vector3(Random.Range(-1.7f, 1.7f), 6.34f, 0), Quaternion.identity);
            }
            timer = Time.deltaTime;

        }
    }
}
