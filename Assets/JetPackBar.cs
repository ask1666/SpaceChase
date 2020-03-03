using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class JetPackBar : MonoBehaviour {

    public Image jetPackBar;

    public float maxJetTime;
    float timer;

    // Start is called before the first frame update
    void Start() {
        jetPackBar.fillAmount = 1;
    }

    // Update is called once per frame
    void Update() {
        
        timer += Time.deltaTime;

        float percent = timer / maxJetTime;
        jetPackBar.fillAmount = Mathf.Lerp(1, 0, percent); ;

        if (jetPackBar.fillAmount == 0.0f) {
            AsteroidExplosion.killPlayer();
        }
    }

    public void RefillJetPack() {
        timer = Time.deltaTime;
    }
}
