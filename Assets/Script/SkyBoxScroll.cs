using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyBoxScroll : MonoBehaviour {

    public GameObject skyBox1, skyBox2, skyBoxToSpawn;
    private float speed;
    private GameObject currentSkyBox = null;
    private GameObject newSkyBox = null;


    public float maxSpeed, minSpeed, tt;
    private float t;

    public float startPos, endPos;
    Score score;

    // Start is called before the first frame update
    void Start() {
        skyBoxToSpawn = skyBox1;
        newSkyBox = Instantiate(skyBoxToSpawn, new Vector3(0, -endPos, 1f), Quaternion.identity);
        currentSkyBox = null;

        score = GameObject.Find("GameControl").GetComponent<Score>();
    }

    // Update is called once per frame
    void Update() {

        t += Time.deltaTime;
        speed = Mathf.Lerp(minSpeed, maxSpeed, t * tt);

        if (score.score >= 200) {
            skyBoxToSpawn = skyBox2;
        }

        if (newSkyBox.transform.position.y <= endPos) {
            currentSkyBox = newSkyBox;
            newSkyBox = Instantiate(skyBoxToSpawn, new Vector3(0, startPos, 1f), Quaternion.identity);

        }

        newSkyBox.transform.Translate(Vector2.down * speed);

        try {
            currentSkyBox.transform.Translate(Vector2.down * speed);

            if (currentSkyBox.transform.position.y <= -startPos) {
                Destroy(currentSkyBox);
            }
        } catch (MissingReferenceException) {

        } catch (NullReferenceException) {

        }
    }
}
