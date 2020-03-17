using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Class for spawning asteroids.
 */
public class ObstacleSpawn : MonoBehaviour {

    public GameObject[] obstacles;

    private float releaseObstacleTimer;
    public float releaseObstacleCooldoown;
    public bool dontSpawn = true;
    public float speed;
    private float cooldownTimer;

    
    void Update() {
        releaseObstacleTimer += Time.deltaTime;
        cooldownTimer += Time.deltaTime * speed;
        releaseObstacleCooldoown = Mathf.Lerp(4, 0.8f, cooldownTimer);
        if (releaseObstacleTimer > releaseObstacleCooldoown) {
            Vector3 spawnPosition = new Vector3(Random.Range(-1.7f, 1.7f), 6.34f, 0);
            GameObject obstacleSpawned = Instantiate(obstacles[Random.Range(0,obstacles.Length)], spawnPosition, Quaternion.identity);
            obstacleSpawned.GetComponent<Rigidbody2D>().AddTorque(Random.Range(0,8), ForceMode2D.Impulse);
            if (!obstacleSpawned.gameObject.tag.Equals("Mine")) {
                obstacleSpawned.transform.localScale = Vector3.one * Random.Range(0.3f, 1.2f);
            }
            releaseObstacleTimer = Time.deltaTime;
        }

    }
}
