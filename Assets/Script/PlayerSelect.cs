using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerSelect : MonoBehaviour {

    private UpgradesProperties UP;
    private Score score;
    public Button player2, player3, player4, player;

    public void Start() {
        UP = GameObject.Find("GameControl").GetComponent<UpgradesProperties>();
        score = GameObject.Find("GameControl").GetComponent<Score>();

        if (score.highScore >= 200) {
            player2.interactable = true;
            player3.interactable = true;
            player3.gameObject.GetComponentInChildren<Text>().gameObject.SetActive(false);
            player4.interactable = false;
            player.interactable = false;
        } if (score.highScore >= 500) {
            player2.interactable = true;
            player3.interactable = true;
            player4.interactable = true;
            player4.gameObject.GetComponentInChildren<Text>().gameObject.SetActive(false);
            player.interactable = false;
        } if (score.highScore >= 1000) {
            player2.interactable = true;
            player3.interactable = true;
            player4.interactable = true;
            player.interactable = true;
            player.gameObject.GetComponentInChildren<Text>().gameObject.SetActive(false);
        } if (score.highScore < 200) {
            player2.interactable = true;
            player3.interactable = false;
            player4.interactable = false;
            player.interactable = false;
        }
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
