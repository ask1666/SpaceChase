using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

/**
 * Class for handling button clicks on Upgrade buttons.
 */
public class UpgradesOnClick : MonoBehaviour {

    public TextMeshProUGUI jetpackText;
    public TextMeshProUGUI speedText;

    public float jetpackDurationIncrease;
    private int jetpackDurationCost;
    private bool jetPackMaxed;
    public float movementSpeedIncrease;
    private int movementSpeedCost;
    private bool movementSpeedMaxed;

    private UpgradesProperties UP;
    private Score score;

    public void Start() {
        score = GameObject.Find("GameControl").GetComponent<Score>();
        UP = GameObject.Find("GameControl").GetComponent<UpgradesProperties>();
        movementSpeedMaxed = false;
        jetPackMaxed = false;

        
    }

    private void Update() {
        switch (UP.movementSpeed) {
            case 5f:
                movementSpeedCost = 100;
                break;
            case 6f:
                movementSpeedCost = 300;
                break;
            case 7f:
                movementSpeedCost = 500;
                break;
            case 8f:
                movementSpeedCost = 1000;
                break;
            default:
                movementSpeedMaxed = true;
                break;
        }

        switch (UP.jetpackDuration) {
            case 30f:
                jetpackDurationCost = 100;
                break;
            case 35f:
                jetpackDurationCost = 300;
                break;
            case 40f:
                jetpackDurationCost = 500;
                break;
            case 45f:
                jetpackDurationCost = 1000;
                break;
            default:
                jetPackMaxed = true;
                break;
        }

        if (movementSpeedMaxed) {
            speedText.text = "MAX";
        } else {
            speedText.text = "$" + movementSpeedCost;
        }

        if (jetPackMaxed) {
            jetpackText.text = "MAX";
        } else {
            jetpackText.text = "$" + jetpackDurationCost;
        }

        
    }

    public void onClickJetpackDuration() {
        if (!jetPackMaxed || score.cash >= jetpackDurationCost) {
            PlayerData playerData = new PlayerData(score.highScore, UP.jetpackDuration + jetpackDurationIncrease, score.cash - jetpackDurationCost, UP.playerName, UP.movementSpeed);
            SaveSystem.SavePlayerData(playerData);
            SaveSystem.LoadPlayerData();
            Debug.Log("saved");
            
        } 
    }

    public void onClickMovementSpeed() {
        if (!movementSpeedMaxed || score.cash >= movementSpeedCost) {
            PlayerData playerData = new PlayerData(score.highScore, UP.jetpackDuration, score.cash - movementSpeedCost, UP.playerName, UP.movementSpeed + movementSpeedIncrease);
            SaveSystem.SavePlayerData(playerData);
            SaveSystem.LoadPlayerData();
            Debug.Log("saved");
            
        } 
    }

    


}
