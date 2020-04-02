using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour {

    public GameObject bullet;
    public Transform bulletSpawnPos;
    private float timer;
    public float maxT, minT, tt;
    private float shootCooldown, t;


    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {


        timer += Time.deltaTime;
        t += Time.deltaTime;
        shootCooldown = Mathf.Lerp(maxT, minT, t * tt);

        if (timer > shootCooldown) {
            Instantiate(bullet, bulletSpawnPos.position, Quaternion.identity);
            timer = Time.deltaTime;
        }
    }
}
