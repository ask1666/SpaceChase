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

    public int startAmmo;
    public int ammoRefillAmount;
    public int ammo;
    public float score;
    private float timer;
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
        
    }

    public void OnSceneLoaded(Scene scene, LoadSceneMode mode) {
        if (scene.name.Equals("MainMenu")) {
            Time.timeScale = 1;
            GameObject[] gameControl = GameObject.FindGameObjectsWithTag("GameControl");

            for (int i = 0; i < gameControl.Length; i++) {
                if (gameControl[i] != this.gameObject) {
                    Destroy(gameControl[i]);
                    
                }
            }
        } else if (scene.name.Equals("Game") || scene.name.Equals("Game2") || scene.name.Equals("Game3")) {
            previousScene = scene.name;
            earnedCash = 0;
            ammoText = GameObject.Find("AmmoNrText").GetComponent<TextMeshProUGUI>();
            ammo = startAmmo;
        } else if (scene.name.Equals("DeathScreen")) {
            scoreText = GameObject.Find("ScoreText").GetComponent<TextMeshProUGUI>();
            scoreText.text = "Score:\n" + Mathf.RoundToInt(score);
            EarnedCashNrText = GameObject.Find("EarnedCashNrText").GetComponent<TextMeshProUGUI>();
            EarnedCashNrText.text = "" + earnedCash;
            timer = Time.deltaTime;
        }

    }

    public void RefillAmmo() {
        ammo += ammoRefillAmount;
    }


    void Update() {
        

        SceneManager.sceneLoaded += OnSceneLoaded;
        if (SceneManager.GetActiveScene().name.Equals("Game") || SceneManager.GetActiveScene().name.Equals("Game2") || SceneManager.GetActiveScene().name.Equals("Game3")) {
            ammoText.text = "" + ammo;
            scoreText = GameObject.Find("ScoreText").GetComponent<TextMeshProUGUI>();
            scoreText.text = "Score:\n" + Mathf.RoundToInt(score);
            timer = Time.timeSinceLevelLoad;
            multiplierTimer = Mathf.Lerp(0f, 4f, timer / multiplierSpeed);
            if (score > highScore) {
                highScore = Mathf.RoundToInt(score);
            }
        } 

        try {
            highScoreText = GameObject.Find("HighScoreText").GetComponent<TextMeshProUGUI>();
            cashText = GameObject.Find("CashText").GetComponent<TextMeshProUGUI>();
        } catch (System.NullReferenceException) {
        }

        

        score = timer * multiplierTimer;

        highScoreText.text = "HighScore:\n" + highScore;
        cashText.text = "Cash:\n" + cash;




    }




}
