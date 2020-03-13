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
            StartCoroutine(KillPlayer());
        }
    }

    public void RefillJetPack() {
        timer = Time.deltaTime;
    }

    IEnumerator KillPlayer() {
        GameObject.Find("Player").GetComponent<CapsuleCollider2D>().enabled = false;
        GameObject.Find("Player").GetComponent<Animator>().applyRootMotion = false;
        GameObject.Find("JetPack").GetComponent<ParticleSystem>().Stop();
        GameObject.Find("Player").GetComponent<Animator>().SetTrigger("NoFuel");
        yield return new WaitForSeconds(0.8f);
        ObstacleExplosion.killPlayer();
    }
}
