using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour {

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
            
            GameObject powerupSpawned = Instantiate<GameObject>(powerUps[0], new Vector3(positions[Random.Range(0, 2)], 6.34f, 0), Quaternion.identity);
            powerupSpawned.GetComponent<Rigidbody2D>().AddTorque(Random.Range(0, 8), ForceMode2D.Impulse);
            powerupSpawned.transform.localScale = Vector3.one * Random.Range(1f, 1f);

            if (powerupSpawned.gameObject.tag.Equals("Fuel")) {
                fuelTimer = 0;
            }
            

            timer = Time.deltaTime;

        }
        
    }

}