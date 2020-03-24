using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Class for spawning powerups.
 */
public class PowerUpSpawner : MonoBehaviour {
    public GameObject[] powerUps;

    public float[] chances;
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
            if (Random.Range(0.0f, 1.0f) >= (1 - chances[Random.Range(0, chances.Length)])) {
                GameObject obstacleSpawned1 = Instantiate<GameObject>(powerUps[Random.Range(0, powerUps.Length)], new Vector3(-1.7f, 6.34f, 0), Quaternion.identity);
                obstacleSpawned1.GetComponent<Rigidbody2D>().AddTorque(Random.Range(0, 8), ForceMode2D.Impulse);
                obstacleSpawned1.transform.localScale = Vector3.one * Random.Range(1f, 1f);
                
            }
            if (Random.Range(0.0f, 1.0f) >= (1 - chances[Random.Range(0, chances.Length)])) {
                GameObject obstacleSpawned2 = Instantiate<GameObject>(powerUps[Random.Range(0, powerUps.Length)], new Vector3(0, 6.34f, 0), Quaternion.identity);
                obstacleSpawned2.GetComponent<Rigidbody2D>().AddTorque(Random.Range(0, 8), ForceMode2D.Impulse);
                obstacleSpawned2.transform.localScale = Vector3.one * Random.Range(1f, 1f);
                
            }
            if (Random.Range(0.0f, 1.0f) >= (1 - chances[Random.Range(0, chances.Length)])) {
                GameObject obstacleSpawned3 = Instantiate<GameObject>(powerUps[Random.Range(0, powerUps.Length)], new Vector3(1.7f, 6.34f, 0), Quaternion.identity);
                obstacleSpawned3.GetComponent<Rigidbody2D>().AddTorque(Random.Range(0, 8), ForceMode2D.Impulse);
                obstacleSpawned3.transform.localScale = Vector3.one * Random.Range(1f, 1f);
                
            }
            timer = Time.deltaTime;

        }
    }

   /** public GameObject coin;
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
            ArrayList positions = new ArrayList();
            positions.Add(-1.7f);
            positions.Add(0);
            positions.Add(1.7f);

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
    */
}
