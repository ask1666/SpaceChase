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
    private List<float> positions;
    public float minSpeed, maxSpeed, tt;
    float timer, lerpTimer;

    private float fuelTimer;     //time since spawned last

    // Start is called before the first frame update
    void Start() {
        positions = new List<float>();
        positions.Add(-1.7f);
        positions.Add(0);
        positions.Add(1.7f);
    }

    // Update is called once per frame
    void Update() {
        fuelTimer += Time.deltaTime;
        timer += Time.deltaTime;
        lerpTimer += Time.deltaTime;

        releaseCooldown = Mathf.Lerp(maxSpeed, minSpeed, lerpTimer * tt);

        if (timer > releaseCooldown) {
            if (Random.Range(0.0f, 1.0f) >= chances[3]) {
                GameObject powerupSpawned = Instantiate<GameObject>(powerUps[0], new Vector3(positions[Random.Range(0, 2)], 6.34f, 0), Quaternion.identity);
                powerupSpawned.GetComponent<Rigidbody2D>().AddTorque(Random.Range(0, 8), ForceMode2D.Impulse);
                powerupSpawned.transform.localScale = Vector3.one * Random.Range(1f, 1f);

                if (powerupSpawned.gameObject.tag.Equals("Fuel")) {
                    fuelTimer = 0;
                }
            } else if (Random.Range(0.0f, 1.0f) >= chances[2]) {
                GameObject powerupSpawned = Instantiate<GameObject>(powerUps[1], new Vector3(positions[Random.Range(0, 2)], 6.34f, 0), Quaternion.identity);
                powerupSpawned.GetComponent<Rigidbody2D>().AddTorque(Random.Range(0, 8), ForceMode2D.Impulse);
                powerupSpawned.transform.localScale = Vector3.one * Random.Range(1f, 1f);

                if (powerupSpawned.gameObject.tag.Equals("Fuel")) {
                    fuelTimer = 0;
                }
            }
            if (Random.Range(0.0f, 1.0f) >= RareChance) {      //Shield or Magnet
                StartCoroutine(spawnRare());

            }

            timer = Time.deltaTime;

        }
        if (fuelTimer >= (JetPackBar.maxJetTime - 7)) {     //spawn fuel if jetpack is almost out of fuel. In other words if you can pick up ever fuel dropping, you will never run out of fuel.
            GameObject powerupSpawned = Instantiate<GameObject>(powerUps[0], new Vector3(0, 6.34f, 0), Quaternion.identity);
            powerupSpawned.GetComponent<Rigidbody2D>().AddTorque(Random.Range(0, 8), ForceMode2D.Impulse);
            powerupSpawned.transform.localScale = Vector3.one * Random.Range(1f, 1f);
            fuelTimer = 0;
        }
    }

    IEnumerator spawnRare() {
        yield return new WaitForSeconds(1.5f);
        GameObject powerupSpawned = Instantiate<GameObject>(powerUps[Random.Range(powerUps.Length - 2, powerUps.Length)], new Vector3(positions[Random.Range(0, 2)], 6.34f, 0), Quaternion.identity);
        powerupSpawned.GetComponent<Rigidbody2D>().AddTorque(Random.Range(0, 8), ForceMode2D.Impulse);
        powerupSpawned.transform.localScale = Vector3.one * Random.Range(1f, 1f);
    }

}
