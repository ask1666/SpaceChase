using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Class for spawning asteroids.
 */
public class ObstacleSpawn : MonoBehaviour {

    public GameObject[] obstacles;

    private float releaseObstacleTimer;
    public float startReleaseObstacleCooldoown;
    private float releaseObstacleCD;
    public bool dontSpawn = true;
    public float speed;
    public float minimumReleaseObstacleCooldown;
    private float cooldownTimer;


    void Update() {
        releaseObstacleTimer += Time.deltaTime;
        cooldownTimer += Time.deltaTime * speed;
        releaseObstacleCD = Mathf.Lerp(startReleaseObstacleCooldoown, minimumReleaseObstacleCooldown, cooldownTimer);
        if (releaseObstacleTimer > releaseObstacleCD) {
            Vector3 spawnPosition = new Vector3(Random.Range(-1.7f, 1.7f), 6.34f, 0);
            GameObject obstacleSpawned = Instantiate(obstacles[Random.Range(0, obstacles.Length)], spawnPosition, Quaternion.identity);
            obstacleSpawned.GetComponent<Rigidbody2D>().AddTorque(Random.Range(0, 8), ForceMode2D.Impulse);
            if (!obstacleSpawned.gameObject.tag.Equals("Mine")) {
                obstacleSpawned.transform.localScale = Vector3.one * Random.Range(0.3f, 1.2f);
            }
           
        releaseObstacleTimer = Time.deltaTime;
    
        }
    }
}
