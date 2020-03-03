using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/**
 * Class for handling death of asteroids.
 */
public class AsteroidExplosion : MonoBehaviour {

    public bool explode;
    public ParticleSystem explosion;
    public GameObject graphic;
    private float timeSinceExploded = 0.4f;

    // Start is called before the first frame update
    void Start() {

        explode = false;

    }

    // Update is called once per frame
    void Update() {
        timeSinceExploded += Time.deltaTime;
        if (explode == true && timeSinceExploded > 0.4f) {
            timeSinceExploded = 0;
            StartCoroutine(doExplosion());
        }

    }

    IEnumerator doExplosion() {

        Destroy(graphic);
        GetComponent<Rigidbody2D>().freezeRotation = true;
        GetComponent<CircleCollider2D>().enabled = false;
        explosion.Play();
        yield return new WaitForSeconds(0.4f);
        Destroy(this.gameObject);

    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag.Equals("Player")) {
            Score score = GameObject.Find("GameControl").GetComponent<Score>();
            UpgradesProperties UP = GameObject.Find("GameControl").GetComponent<UpgradesProperties>();
            PlayerData playerData = new PlayerData(score.highScore, UP.gunCooldown, UP.gunRange, score.cash);
            SaveSystem.SavePlayerData(playerData);
            SceneManager.LoadScene("DeathScreen");
        }
    }

    public static void killPlayer() {
        Score score = GameObject.Find("GameControl").GetComponent<Score>();
        UpgradesProperties UP = GameObject.Find("GameControl").GetComponent<UpgradesProperties>();
        PlayerData playerData = new PlayerData(score.highScore, UP.gunCooldown, UP.gunRange, score.cash);
        SaveSystem.SavePlayerData(playerData);
        SceneManager.LoadScene("DeathScreen");
    }
}
