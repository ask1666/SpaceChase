using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Score : MonoBehaviour {



    private TextMeshProUGUI scoreText;
    private TextMeshProUGUI highScoreText;
    private TextMeshProUGUI cashText;

    public float score;
    private float timer;
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
            GameObject[] gameControl = GameObject.FindGameObjectsWithTag("GameControl");
            for (int i = 0; i < gameControl.Length; i++) {
                if (gameControl[i] != this.gameObject) {
                    Destroy(gameControl[i]);
                }
            }

            //SaveSystem.LoadPlayerData();

        }
    }



    // Update is called once per frame
    void Update() {
        SceneManager.sceneLoaded += OnSceneLoaded;
        if (SceneManager.GetActiveScene().name.Equals("Game")) {

            timer = Time.timeSinceLevelLoad;
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

        score = timer;
        scoreText.text = "Score:\n" + Mathf.RoundToInt(score);
        highScoreText.text = "HighScore:\n" + highScore;
        cashText.text = "Cash:\n" + cash;

        

    }




}
