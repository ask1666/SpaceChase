using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShieldPanel : MonoBehaviour {


    public Image shieldPanel;
    public static bool shieldActive;
    private float maxTime;
    float timer;

    // Start is called before the first frame update
    void Start() {
        shieldPanel.fillAmount = 0;
        maxTime = PlayerController.shieldTime;
    }

    // Update is called once per frame
    void Update() {
        shield();
    }

    private void shield() {
        if (shieldActive) {
            timer += Time.deltaTime;

            float percent = timer / maxTime;
            shieldPanel.fillAmount = Mathf.Lerp(1, 0, percent);
        }
    }

    public void refillShield() {
        timer = Time.deltaTime;
    }
}
