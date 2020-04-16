using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Class for spawning powerups.
 */
public class PowerUpSpawner : MonoBehaviour {
    public GameObject[] powerUps;
    public float RareChance;
    public float[] chances;
    public float releaseCooldown;
    public bool dontSpawn = true;
    float timer;

    private float fuelTimer;     //time since spawned last

    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        fuelTimer += Time.deltaTime;
        timer += Time.deltaTime;

        if (timer > releaseCooldown) {
            if (Random.Range(0.0f, 1.0f) >= (1 - chances[Random.Range(0, chances.Length)])) {
                GameObject powerupSpawned = Instantiate<GameObject>(powerUps[Random.Range(0, powerUps.Length-2)], new Vector3(-1.7f, 6.34f, 0), Quaternion.identity);
                powerupSpawned.GetComponent<Rigidbody2D>().AddTorque(Random.Range(0, 8), ForceMode2D.Impulse);
                powerupSpawned.transform.localScale = Vector3.one * Random.Range(1f, 1f);

                if (powerupSpawned.gameObject.tag.Equals("Fuel")) {
                    fuelTimer = 0;
                }
            }
            if (Random.Range(0.0f, 1.0f) >= (1 - chances[Random.Range(0, chances.Length)])) {
                GameObject powerupSpawned = Instantiate<GameObject>(powerUps[Random.Range(0, powerUps.Length-2)], new Vector3(0, 6.34f, 0), Quaternion.identity);
                powerupSpawned.GetComponent<Rigidbody2D>().AddTorque(Random.Range(0, 8), ForceMode2D.Impulse);
                powerupSpawned.transform.localScale = Vector3.one * Random.Range(1f, 1f);

                if (powerupSpawned.gameObject.tag.Equals("Fuel")) {
                    fuelTimer = 0;
                }

            } else if (Random.Range(0.0f, 1.0f) >= (1 - RareChance)) {      //Shield or Magnet
                GameObject powerupSpawned = Instantiate<GameObject>(powerUps[Random.Range(powerUps.Length - 2, powerUps.Length)], new Vector3(0, 6.34f, 0), Quaternion.identity);
                powerupSpawned.GetComponent<Rigidbody2D>().AddTorque(Random.Range(0, 8), ForceMode2D.Impulse);
                powerupSpawned.transform.localScale = Vector3.one * Random.Range(1f, 1f);

            }
            if (Random.Range(0.0f, 1.0f) >= (1 - chances[Random.Range(0, chances.Length)])) {
                GameObject powerupSpawned = Instantiate<GameObject>(powerUps[Random.Range(0, powerUps.Length-2)], new Vector3(1.7f, 6.34f, 0), Quaternion.identity);
                powerupSpawned.GetComponent<Rigidbody2D>().AddTorque(Random.Range(0, 8), ForceMode2D.Impulse);
                powerupSpawned.transform.localScale = Vector3.one * Random.Range(1f, 1f);

                if (powerupSpawned.gameObject.tag.Equals("Fuel")) {
                    fuelTimer = 0;
                }
            }

            timer = Time.deltaTime;

        }
        if (fuelTimer >= (JetPackBar.maxJetTime - 7)) {     //spawn fuel if jetpack is almost out of fuel. In other words if you can pick up ever fuel dropping, you will never run out of fuel.
            GameObject powerupSpawned = Instantiate<GameObject>(powerUps[2], new Vector3(0, 6.34f, 0), Quaternion.identity);
            powerupSpawned.GetComponent<Rigidbody2D>().AddTorque(Random.Range(0, 8), ForceMode2D.Impulse);
            powerupSpawned.transform.localScale = Vector3.one * Random.Range(1f, 1f);
            fuelTimer = 0;
        }
    }

}
