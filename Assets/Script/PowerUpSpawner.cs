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

    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {

        timer += Time.deltaTime;

        if (timer > releaseCooldown) {
            if (Random.Range(0.0f, 1.0f) >= (1 - chances[Random.Range(0, chances.Length)])) {
                GameObject obstacleSpawned = Instantiate<GameObject>(powerUps[Random.Range(0, powerUps.Length-2)], new Vector3(-1.7f, 6.34f, 0), Quaternion.identity);
                obstacleSpawned.GetComponent<Rigidbody2D>().AddTorque(Random.Range(0, 8), ForceMode2D.Impulse);
                obstacleSpawned.transform.localScale = Vector3.one * Random.Range(1f, 1f);
                
            }
            if (Random.Range(0.0f, 1.0f) >= (1 - chances[Random.Range(0, chances.Length)])) {
                GameObject obstacleSpawned = Instantiate<GameObject>(powerUps[Random.Range(0, powerUps.Length-2)], new Vector3(0, 6.34f, 0), Quaternion.identity);
                obstacleSpawned.GetComponent<Rigidbody2D>().AddTorque(Random.Range(0, 8), ForceMode2D.Impulse);
                obstacleSpawned.transform.localScale = Vector3.one * Random.Range(1f, 1f);
                
            } else if (Random.Range(0.0f, 1.0f) >= (1 - RareChance)) {      //Shield or Magnet
                GameObject obstacleSpawned = Instantiate<GameObject>(powerUps[Random.Range(powerUps.Length - 2, powerUps.Length)], new Vector3(0, 6.34f, 0), Quaternion.identity);
                obstacleSpawned.GetComponent<Rigidbody2D>().AddTorque(Random.Range(0, 8), ForceMode2D.Impulse);
                obstacleSpawned.transform.localScale = Vector3.one * Random.Range(1f, 1f);

            }
            if (Random.Range(0.0f, 1.0f) >= (1 - chances[Random.Range(0, chances.Length)])) {
                GameObject obstacleSpawned = Instantiate<GameObject>(powerUps[Random.Range(0, powerUps.Length-2)], new Vector3(1.7f, 6.34f, 0), Quaternion.identity);
                obstacleSpawned.GetComponent<Rigidbody2D>().AddTorque(Random.Range(0, 8), ForceMode2D.Impulse);
                obstacleSpawned.transform.localScale = Vector3.one * Random.Range(1f, 1f);
                
            }

            
            timer = Time.deltaTime;

        }
    }

}
