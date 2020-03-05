using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyBoxScroll : MonoBehaviour {

    public GameObject skyBox;
    public float speed;
    private GameObject currentSkyBox = null;
    private GameObject newSkyBox = null;

    public float startPos, endPos;

    // Start is called before the first frame update
    void Start() {
        newSkyBox = Instantiate(skyBox, new Vector3(0, -endPos, 1f), Quaternion.identity);
        currentSkyBox = null;
    }

    // Update is called once per frame
    void Update() {
        
        if (newSkyBox.transform.position.y <= endPos) {
            currentSkyBox = newSkyBox;
            newSkyBox = Instantiate(skyBox, new Vector3(0, startPos, 1f), Quaternion.identity);

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
