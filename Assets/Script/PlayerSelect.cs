using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerSelect : MonoBehaviour {

    private UpgradesProperties UP;

    public void Start() {
        UP = GameObject.Find("GameControl").GetComponent<UpgradesProperties>();
    }

    public void OnPlayerClick() {
        PlayerData playerData = new PlayerData(0, UP.jetpackDuration, 0, "Player");
        SaveSystem.SavePlayerData(playerData);
        SceneManager.LoadScene("MainMenu"); 
    }

    public void OnPlayer2Click() {
        PlayerData playerData = new PlayerData(0, UP.jetpackDuration, 0, "Player2");
        SaveSystem.SavePlayerData(playerData);
        SceneManager.LoadScene("MainMenu");
    }

    public void OnPlayer3Click() {
        PlayerData playerData = new PlayerData(0, UP.jetpackDuration, 0, "Player3");
        SaveSystem.SavePlayerData(playerData);
        SceneManager.LoadScene("MainMenu");
    }

    public void OnPlayer4Click() {
        PlayerData playerData = new PlayerData(0, UP.jetpackDuration, 0, "Player4");
        SaveSystem.SavePlayerData(playerData);
        SceneManager.LoadScene("MainMenu");
    }
}
