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

    public float score;
    private float timer;
    private float multiplierTimer;
    public float multiplierSpeed; //less for more score
    public int highScore;
    public int cash;

    private void Awake() {

        DontDestroyOnLoad(this.gameObject);

        scoreText = GameObject.Find("ScoreText").GetComponent<TextMeshProUGUI>();
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
    }


    void Update() {
        SceneManager.sceneLoaded += OnSceneLoaded;
        if (SceneManager.GetActiveScene().name.Equals("Game")) {
            

            timer = Time.timeSinceLevelLoad;
            multiplierTimer = Mathf.Lerp(0f, 4f, timer / multiplierSpeed);
        }

        try {
            if (scoreText == null) {
                scoreText = GameObject.Find("ScoreText").GetComponent<TextMeshProUGUI>();
                highScoreText = GameObject.Find("HighScoreText").GetComponent<TextMeshProUGUI>();
                cashText = GameObject.Find("CashText").GetComponent<TextMeshProUGUI>();
            }
        } catch (System.NullReferenceException) {

        }

        if (score > highScore) {
            highScore = Mathf.RoundToInt(score);

        }

        score = timer*multiplierTimer;
        scoreText.text = "Score:\n" + Mathf.RoundToInt(score);
        highScoreText.text = "HighScore:\n" + highScore;
        cashText.text = "Cash:\n" + cash;



    }




}
