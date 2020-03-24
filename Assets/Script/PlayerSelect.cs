using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerSelect : MonoBehaviour {

    private UpgradesProperties UP;
    private Score score;

    public void Start() {
        UP = GameObject.Find("GameControl").GetComponent<UpgradesProperties>();
        score = GameObject.Find("GameControl").GetComponent<Score>();
    }

    public void OnPlayerClick() {
        PlayerData playerData = new PlayerData(score.highScore, UP.jetpackDuration, score.cash, "Player", UP.movementSpeed);
        SaveSystem.SavePlayerData(playerData);
        SceneManager.LoadScene("MainMenu"); 
    }

    public void OnPlayer2Click() {
        PlayerData playerData = new PlayerData(score.highScore, UP.jetpackDuration, score.cash, "Player2", UP.movementSpeed);
        SaveSystem.SavePlayerData(playerData);
        SceneManager.LoadScene("MainMenu");
    }

    public void OnPlayer3Click() {
        PlayerData playerData = new PlayerData(score.highScore, UP.jetpackDuration, score.cash, "Player3", UP.movementSpeed);
        SaveSystem.SavePlayerData(playerData);
        SceneManager.LoadScene("MainMenu");
    }

    public void OnPlayer4Click() {
        PlayerData playerData = new PlayerData(score.highScore, UP.jetpackDuration, score.cash, "Player4", UP.movementSpeed);
        SaveSystem.SavePlayerData(playerData);
        SceneManager.LoadScene("MainMenu");
    }
}
