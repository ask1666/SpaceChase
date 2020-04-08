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
    public static float speed;

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

        GetComponent<Rigidbody2D>().AddForce(Vector2.down * speed, ForceMode2D.Impulse);

    }

    IEnumerator doExplosion() {

        
        GetComponent<Rigidbody2D>().freezeRotation = true;
        GetComponent<Collider2D>().enabled = false;
        explosion.Play();
        sound.Play();
        
        Destroy(this.graphic);
        yield return new WaitForSeconds(0.4f);

        
        Destroy(this.gameObject);
        
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (!(this.gameObject.tag.Equals("Garbage")) && collision.gameObject.tag.Equals("Player")) {
            collision.gameObject.GetComponent<AudioSource>().Play();
            collision.gameObject.GetComponent<Animator>().applyRootMotion = false;
            collision.gameObject.GetComponent<Animator>().SetTrigger("NoFuel");
            StartCoroutine(killPlayer());
        } else if (this.gameObject.tag.Equals("Garbage") && collision.gameObject.tag.Equals("Player")) {
            collision.gameObject.GetComponent<AudioSource>().Play();
            this.gameObject.GetComponent<BoxCollider2D>().enabled = false;
            Garbage();
        } else if (collision.gameObject.tag.Equals("ShieldEffect")) {
            explode = true;
        } 
    }

    public static IEnumerator killPlayer() {
        Score score = GameObject.Find("GameControl").GetComponent<Score>();
        yield return new WaitForSeconds(0.5f);
        score.cash += Mathf.RoundToInt(score.score) / 10;
        score.earnedCash += Mathf.RoundToInt(score.score) / 10;
        UpgradesProperties UP = GameObject.Find("GameControl").GetComponent<UpgradesProperties>();
        PlayerData playerData = new PlayerData(score.highScore, UP.jetpackDuration, score.cash, UP.playerName, UP.movementSpeed, Score.startAmmo, UP.magnetTime, UP.shieldTime);
        SaveSystem.SavePlayerData(playerData);
        SceneManager.LoadScene("DeathScreen");
    }

    void Garbage() {
        
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        player.transform.Translate(Vector2.down * 1f);
    }
}
