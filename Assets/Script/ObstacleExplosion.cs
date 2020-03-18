using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/**
 * Class for handling death of asteroids.
 */
public class ObstacleExplosion : MonoBehaviour {

    public bool explode;
    public ParticleSystem explosion;
    public GameObject graphic;
    public AudioSource sound;
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
        GetComponent<Collider2D>().enabled = false;
        explosion.Play();
        sound.Play();
        yield return new WaitForSeconds(0.4f);
        Destroy(this.gameObject);

    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (!(this.gameObject.tag.Equals("Garbage")) && collision.gameObject.tag.Equals("Player")) {
            collision.gameObject.GetComponent<AudioSource>().Play();
            killPlayer();
        } else if (this.gameObject.tag.Equals("Garbage") && collision.gameObject.tag.Equals("Player")) {
            collision.gameObject.GetComponent<AudioSource>().Play();
            this.gameObject.GetComponent<BoxCollider2D>().enabled = false;
            Garbage();
        }
    }

    public static void killPlayer() {
        Score score = GameObject.Find("GameControl").GetComponent<Score>();
        score.cash += Mathf.RoundToInt(score.score) / 10;
        score.earnedCash += Mathf.RoundToInt(score.score) / 10;
        UpgradesProperties UP = GameObject.Find("GameControl").GetComponent<UpgradesProperties>();
        PlayerData playerData = new PlayerData(score.highScore, UP.gunCooldown, UP.gunRange, score.cash, UP.playerPrefab.name);
        SaveSystem.SavePlayerData(playerData);
        SceneManager.LoadScene("DeathScreen");
    }

    void Garbage() {
        
        GameObject player = GameObject.Find("Player");
        player.transform.Translate(Vector2.down * 0.5f);
    }
}
