using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Score : MonoBehaviour {



    private TextMeshProUGUI scoreText;
    private TextMeshProUGUI highScoreText;

    public float score;
    private float timer;
    public int highScore;
    public int cash;

    // Start is called before the first frame update
    void Start() {

        scoreText = GameObject.Find("ScoreText").GetComponent<TextMeshProUGUI>();
        highScoreText = GameObject.Find("HighScoreText").GetComponent<TextMeshProUGUI>();

        GameObject[] gc = GameObject.FindGameObjectsWithTag("GameControl");
        if (gc.Length > 1) {
            Destroy(gc[1]);
        }
        DontDestroyOnLoad(this.gameObject);
        SaveSystem.LoadPlayerData();
    }



    // Update is called once per frame
    void Update() {

        if (SceneManager.GetActiveScene().name.Equals("Game")) {

            timer = Time.timeSinceLevelLoad;
        }

        try {
            if (scoreText == null) {
                scoreText = GameObject.Find("ScoreText").GetComponent<TextMeshProUGUI>();
                highScoreText = GameObject.Find("HighScoreText").GetComponent<TextMeshProUGUI>();
            }
        } catch (System.NullReferenceException) {

        }

        if (score > highScore) {
            highScore = Mathf.RoundToInt(score);

        }

        score = timer;
        scoreText.text = "" + Mathf.RoundToInt(score);
        highScoreText.text = "" + highScore;



    }




}
