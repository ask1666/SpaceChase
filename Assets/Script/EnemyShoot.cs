using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour {

    public GameObject bullet;
    public Transform bulletSpawnPos;
    public float shootColdown;
    private float timer;


    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        timer += Time.deltaTime;
        if (timer > shootColdown) {
            Instantiate(bullet, bulletSpawnPos.position, Quaternion.identity);
            timer = Time.deltaTime;
        }
    }
}
