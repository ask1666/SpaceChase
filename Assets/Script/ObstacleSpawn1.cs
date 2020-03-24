using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawn1 : MonoBehaviour {
    public GameObject[] obstacles;

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
        float timer1 = Mathf.Lerp(timer + 0.5f, timer - 0.5f, 0.01f);
        if (timer1 > releaseCooldown) {
            if (Random.Range(0.0f, 1.0f) >= (1 - chances[Random.Range(0,chances.Length)])) {
                GameObject obstacleSpawned1 = Instantiate<GameObject>(obstacles[Random.Range(0, obstacles.Length)], new Vector3(-1.7f, 6.34f, 0), Quaternion.identity);
                obstacleSpawned1.GetComponent<Rigidbody2D>().AddTorque(Random.Range(0, 8), ForceMode2D.Impulse);
                if (!obstacleSpawned1.gameObject.tag.Equals("Mine")) {
                    obstacleSpawned1.transform.localScale = Vector3.one * Random.Range(1f, 1f);
                }
            }
            if (Random.Range(0.0f, 1.0f) >= (1 - chances[Random.Range(0, chances.Length)])) {
                GameObject obstacleSpawned2 = Instantiate<GameObject>(obstacles[Random.Range(0, obstacles.Length)], new Vector3(0, 6.34f, 0), Quaternion.identity);
                obstacleSpawned2.GetComponent<Rigidbody2D>().AddTorque(Random.Range(0, 8), ForceMode2D.Impulse);
                if (!obstacleSpawned2.gameObject.tag.Equals("Mine")) {
                    obstacleSpawned2.transform.localScale = Vector3.one * Random.Range(1f, 1f);
                }
            }
            if (Random.Range(0.0f, 1.0f) >= (1 - chances[Random.Range(0, chances.Length)])) {
                GameObject obstacleSpawned3 = Instantiate<GameObject>(obstacles[Random.Range(0, obstacles.Length)], new Vector3(1.7f, 6.34f, 0), Quaternion.identity);
                obstacleSpawned3.GetComponent<Rigidbody2D>().AddTorque(Random.Range(0, 8), ForceMode2D.Impulse);
                if (!obstacleSpawned3.gameObject.tag.Equals("Mine")) {
                    obstacleSpawned3.transform.localScale = Vector3.one * Random.Range(1f, 1f);
                }
            }
            timer = Time.deltaTime;

        }
    }

}
