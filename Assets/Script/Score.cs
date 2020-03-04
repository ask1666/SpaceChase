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

    public float score;
    private float timer;
    private float multiplierTimer;
    public float multiplierSpeed; //less for more score
    public int highScore;
    public int cash;
    public int earnedCash; //cash earned current round

    private void Awake() {

        DontDestroyOnLoad(this.gameObject);

        highScoreText = GameObject.Find("HighScoreText").GetComponent<TextMeshProUGUI>();
        cashText = GameObject.Find("CashText").GetComponent<TextMeshProUGUI>();
        SaveSystem.LoadPlayerData();

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
        }
        if (scene.name.Equals("Game")) {
            earnedCash = 0;
        }

    }


    void Update() {
        SceneManager.sceneLoaded += OnSceneLoaded;
        if (SceneManager.GetActiveScene().name.Equals("Game")) {
            scoreText = GameObject.Find("ScoreText").GetComponent<TextMeshProUGUI>();
            scoreText.text = "Score:\n" + Mathf.RoundToInt(score);
            timer = Time.timeSinceLevelLoad;
            multiplierTimer = Mathf.Lerp(0f, 4f, timer / multiplierSpeed);
        } else if (SceneManager.GetActiveScene().name.Equals("DeathScreen")) {
            scoreText = GameObject.Find("ScoreText").GetComponent<TextMeshProUGUI>();
            scoreText.text = "Score:\n" + Mathf.RoundToInt(score);
            EarnedCashNrText = GameObject.Find("EarnedCashNrText").GetComponent<TextMeshProUGUI>();
            EarnedCashNrText.text = "" + earnedCash;
        }

        try {
            highScoreText = GameObject.Find("HighScoreText").GetComponent<TextMeshProUGUI>();
            cashText = GameObject.Find("CashText").GetComponent<TextMeshProUGUI>();
        } catch (System.NullReferenceException) {
        }

        if (score > highScore) {
            highScore = Mathf.RoundToInt(score);
        }

        score = timer * multiplierTimer;

        highScoreText.text = "HighScore:\n" + highScore;
        cashText.text = "Cash:\n" + cash;




    }




}
