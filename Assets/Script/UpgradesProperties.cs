using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UpgradesProperties : MonoBehaviour {

    public float gunRange;
    public float gunCooldown;

    // Start is called before the first frame update
    void Start() {
        if (gunRange <= 3 || gunCooldown >= 1) {
            Score score = GameObject.Find("GameControl").GetComponent<Score>();
            PlayerData playerData = new PlayerData(score.highScore, 1, 3, score.cash);
            SaveSystem.SavePlayerData(playerData);
        }
        
    }

    // Update is called once per frame
    void Update() {

        SceneManager.sceneLoaded += OnSceneLoaded;

    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode) {
        if (SceneManager.GetActiveScene().name.Equals("Game")) {
            GameObject.Find("Gun").GetComponent<Gun>().gunCooldown = gunCooldown;
            GameObject.Find("Gun").GetComponent<Gun>().beamRange = gunRange;
        }
    }
}
