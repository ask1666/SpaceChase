using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawn1 : MonoBehaviour {
    public GameObject[] obstacles;

    public float[] chances;
    public float minimum, maximum, releaseCooldown;
    public bool dontSpawn = true;
    private float timer;
    private float t;

    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {

        timer += Time.deltaTime;
        releaseCooldown = Mathf.Lerp(maximum, minimum, 0.01f * t);
        t += Time.deltaTime;
        if (timer > releaseCooldown) {
            if (Random.Range(0.0f, 1.0f) >= (1 - chances[Random.Range(0,chances.Length)])) {
                GameObject obstacleSpawned1 = Instantiate<GameObject>(obstacles[Random.Range(0, obstacles.Length)], new Vector3(-1.7f, 6.34f, 0), Quaternion.identity);
                if (!obstacleSpawned1.tag.Equals("Enemy")) {
                    obstacleSpawned1.GetComponent<Rigidbody2D>().AddTorque(Random.Range(0, 8), ForceMode2D.Impulse);
                }
                obstacleSpawned1.transform.localScale = Vector3.one * Random.Range(1f, 1f);
                
            }
            if (Random.Range(0.0f, 1.0f) >= (1 - chances[Random.Range(0, chances.Length)])) {
                GameObject obstacleSpawned2 = Instantiate<GameObject>(obstacles[Random.Range(0, obstacles.Length)], new Vector3(0, 6.34f, 0), Quaternion.identity);
                if (!obstacleSpawned2.tag.Equals("Enemy")) {
                    obstacleSpawned2.GetComponent<Rigidbody2D>().AddTorque(Random.Range(0, 8), ForceMode2D.Impulse);
                }
                obstacleSpawned2.transform.localScale = Vector3.one * Random.Range(1f, 1f);
                
            }
            if (Random.Range(0.0f, 1.0f) >= (1 - chances[Random.Range(0, chances.Length)])) {
                GameObject obstacleSpawned3 = Instantiate<GameObject>(obstacles[Random.Range(0, obstacles.Length)], new Vector3(1.7f, 6.34f, 0), Quaternion.identity);
                if (!obstacleSpawned3.tag.Equals("Enemy")) {
                    obstacleSpawned3.GetComponent<Rigidbody2D>().AddTorque(Random.Range(0, 8), ForceMode2D.Impulse);
                }
                obstacleSpawned3.transform.localScale = Vector3.one * Random.Range(1f, 1f);
                
            }

            timer = Time.deltaTime;

        }
    }

}
