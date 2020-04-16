using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/**
 * Class for handling score and cash.
 */
public class Score : MonoBehaviour {

    private TextMeshProUGUI scoreText;
    private TextMeshProUGUI highScoreText;
    private TextMeshProUGUI cashText;
    private TextMeshProUGUI EarnedCashNrText;
    public TextMeshProUGUI ammoText;

    private Button shootBtn;

    public static int startAmmo = 5;
    public int ammoRefillAmount;
    public int ammo, maxAmmo;
    public int score;
    public int previousScore;
    private float timer;
    public static bool pause;
    private float multiplierTimer;
    public float multiplierSpeed; //less for more score
    public int highScore;
    public int cash;
    public int earnedCash; //cash earned current round
    public string previousScene;

    private void Awake() {

        DontDestroyOnLoad(this.gameObject);

        highScoreText = GameObject.Find("HighScoreText").GetComponent<TextMeshProUGUI>();
        cashText = GameObject.Find("CashText").GetComponent<TextMeshProUGUI>();
        SaveSystem.LoadPlayerData();

    }

    private void Start() {
        SceneManager.sceneLoaded += OnSceneLoaded;
        setText();
    }

    public void OnSceneLoaded(Scene scene, LoadSceneMode mode) {
        if (scene.name.Equals("MainMenu")) {
            setText();
            Time.timeScale = 1;
            GameObject[] gameControl = GameObject.FindGameObjectsWithTag("GameControl");

            for (int i = 0; i < gameControl.Length; i++) {
                if (gameControl[i] != this.gameObject) {
                    Destroy(gameControl[i]);

                }
            }
        } else if (scene.name.Equals("MainGame")) {
            setText();
            previousScene = scene.name;
            earnedCash = 0;
            ammoText = GameObject.Find("AmmoNrText").GetComponent<TextMeshProUGUI>();
            ammo = startAmmo;
        } else if (scene.name.Equals("DeathScreen")) {
            setText();
            scoreText = GameObject.Find("ScoreText").GetComponent<TextMeshProUGUI>();
            scoreText.text = "Score:\n" + Mathf.RoundToInt(score);
            EarnedCashNrText = GameObject.Find("EarnedCashNrText").GetComponent<TextMeshProUGUI>();
            EarnedCashNrText.text = "" + earnedCash;
            //timer = Time.deltaTime;
        } else if (scene.name.Equals("Controls")) {
            setText();
        } else if (scene.name.Equals("Upgrades")) {
            setText();
        } else if (scene.name.Equals("PlayerSelect")) {
            setText();
        }

    }

    public void RefillAmmo() {

        if ((ammo + ammoRefillAmount) <= maxAmmo) {
            ammo += ammoRefillAmount;
        } else {
            ammo = maxAmmo;
        }

    }

    public void setText() {
        highScoreText = GameObject.Find("HighScoreText").GetComponent<TextMeshProUGUI>();
        cashText = GameObject.Find("CashText").GetComponent<TextMeshProUGUI>();
        highScoreText.text = "HighScore:\n" + highScore;
        cashText.text = "Cash:\n" + cash;
    }


    void Update() {



        if (SceneManager.GetActiveScene().name.Equals("MainGame") && !pause) {
            
            multiplierTimer = Mathf.Lerp(0f, 4f, Time.timeSinceLevelLoad / multiplierSpeed);
            score = Mathf.RoundToInt(Time.timeSinceLevelLoad * multiplierTimer);
            if (previousScore != score || previousScore == 0) {
                previousScore = score;
                ammoText.text = "" + ammo;
                scoreText = GameObject.Find("ScoreText").GetComponent<TextMeshProUGUI>();
                scoreText.text = "Score:\n" + Mathf.RoundToInt(score);
                highScoreText.text = "HighScore:\n" + highScore;
                cashText.text = "Cash:\n" + cash;
                if (score > highScore) {
                    highScore = Mathf.RoundToInt(score);
                }
            }

        } else {
            if (Input.GetKeyDown(KeyCode.Escape)) {
                SceneManager.LoadScene("MainMenu");
            }
        }

        if (Time.frameCount % 30 == 0) {
            System.GC.Collect();
        }


    }




}
