﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MagnetBarPanel : MonoBehaviour {


    public Image magnetPanel;
    public static bool magnetActive;
    private float maxTime;
    float timer;

    // Start is called before the first frame update
    void Start() {
        magnetPanel.fillAmount = 0;
        maxTime = PlayerController.magnetTime;
        magnetActive = false;
    }

    // Update is called once per frame
    void Update() {
        magnet();
    }

    private void magnet() {
        if (magnetActive) {
            timer += Time.deltaTime;

            float percent = timer / maxTime;
            magnetPanel.fillAmount = Mathf.Lerp(1, 0, percent);

        } else {
            timer = 0;
            magnetPanel.fillAmount = 0;
        }
    }

    public void magnetRefill() {
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().magnetTimer = 0;
        timer = Time.deltaTime;
    }
}
