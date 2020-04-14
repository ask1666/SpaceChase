using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyBoxScroll : MonoBehaviour {

    public GameObject skyBox1, skyBox2, skyBoxToSpawn;
    private float speed, speed2;
    private GameObject currentSkyBox = null;
    private GameObject newSkyBox = null;

    public ParticleSystem spaceDust;
    public float maxSpeed2, minSpeed2, tt2;

    public float maxSpeed, minSpeed, tt;
    private float t;
    public static bool pause;
    public float startPos, endPos;
    Score score;

    // Start is called before the first frame update
    void Start() {

        pause = false;
        skyBoxToSpawn = skyBox1;
        newSkyBox = Instantiate(skyBoxToSpawn, new Vector3(0, -endPos, 1f), Quaternion.identity);
        currentSkyBox = null;

        score = GameObject.Find("GameControl").GetComponent<Score>();
    }

    // Update is called once per frame
    void Update() {

        ParticleSystem.MainModule spaceDustMain = spaceDust.main;

        t += Time.deltaTime;
        speed = Mathf.Lerp(minSpeed, maxSpeed, t * tt);
        speed2 = Mathf.Lerp(maxSpeed2, minSpeed2, t * tt2);
        spaceDustMain.startSpeed = new ParticleSystem.MinMaxCurve(speed2);

        if (score.score >= 200) {
            skyBoxToSpawn = skyBox2;
        }

        if (newSkyBox.transform.position.y <= endPos) {
            currentSkyBox = newSkyBox;
            newSkyBox = Instantiate(skyBoxToSpawn, new Vector3(0, startPos, 1f), Quaternion.identity);

        }

        if (!pause)
            newSkyBox.transform.Translate(Vector2.down * speed);

        try {
            if (!pause)
                currentSkyBox.transform.Translate(Vector2.down * speed);

            if (currentSkyBox.transform.position.y <= -startPos) {
                Destroy(currentSkyBox);
            }
        } catch (MissingReferenceException) {

        } catch (NullReferenceException) {

        }
    }
}
