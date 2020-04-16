﻿using System.Collections;
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
    public TextMeshProUGUI startAmmoText;
    public TextMeshProUGUI magnetTimeText;
    public TextMeshProUGUI shieldTimeText;

    public float jetpackDurationIncrease;
    public float movementSpeedIncrease;
    public float magnetTimeIncrease;
    public float shieldTimeIncrease;
    public int startAmmoIncrease;

    private int jetpackDurationCost;
    private int movementSpeedCost;
    private int startAmmoCost;
    private int magnetTimeCost;
    private int shieldTimeCost;

    private bool jetPackMaxed;
    private bool movementSpeedMaxed;
    private bool startAmmoMaxed;
    private bool magnetTimeMaxed;
    private bool shieldTimeMaxed;

    private UpgradesProperties UP;
    private Score score;

    public void Start() {
        score = GameObject.Find("GameControl").GetComponent<Score>();
        UP = GameObject.Find("GameControl").GetComponent<UpgradesProperties>();
        movementSpeedMaxed = false;
        jetPackMaxed = false;
        startAmmoMaxed = false;
        magnetTimeMaxed = false;
        shieldTimeMaxed = false;
        
    }

    private void Update() {

        jetpackDurationHandler();
        movementSpeedHandler();
        startAmmoHandler();
        magnetTimeHandler();
        shieldTimeHandler();

    }

    public void onClickJetpackDuration() {
        if (!jetPackMaxed && score.cash >= jetpackDurationCost) {
            PlayerData playerData = new PlayerData(score.highScore, UP.jetpackDuration + jetpackDurationIncrease, score.cash - jetpackDurationCost, UP.playerName, UP.movementSpeed, Score.startAmmo, UP.magnetTime, UP.shieldTime);
            SaveSystem.SavePlayerData(playerData);
            SaveSystem.LoadPlayerData();
            Debug.Log("saved");
            GameObject.Find("GameControl").GetComponent<Score>().setText();
            
        } 
    }

    public void onClickMovementSpeed() {
        if (!movementSpeedMaxed && score.cash >= movementSpeedCost) {
            PlayerData playerData = new PlayerData(score.highScore, UP.jetpackDuration, score.cash - movementSpeedCost, UP.playerName, UP.movementSpeed + movementSpeedIncrease, Score.startAmmo, UP.magnetTime, UP.shieldTime);
            SaveSystem.SavePlayerData(playerData);
            SaveSystem.LoadPlayerData();
            Debug.Log("saved");
            GameObject.Find("GameControl").GetComponent<Score>().setText();

        }
    }

    public void onClickStartAmmo() {
        if (!startAmmoMaxed && score.cash >= startAmmoCost) {
            PlayerData playerData = new PlayerData(score.highScore, UP.jetpackDuration, score.cash - startAmmoCost, UP.playerName, UP.movementSpeed, Score.startAmmo + startAmmoIncrease, UP.magnetTime, UP.shieldTime);
            SaveSystem.SavePlayerData(playerData);
            SaveSystem.LoadPlayerData();
            Debug.Log("saved");
            GameObject.Find("GameControl").GetComponent<Score>().setText();

        }
    }

    public void onClickMagnetTime() {
        if (!magnetTimeMaxed && score.cash >= magnetTimeCost) {
            PlayerData playerData = new PlayerData(score.highScore, UP.jetpackDuration, score.cash - magnetTimeCost, UP.playerName, UP.movementSpeed, Score.startAmmo, UP.magnetTime + magnetTimeIncrease, UP.shieldTime);
            SaveSystem.SavePlayerData(playerData);
            SaveSystem.LoadPlayerData();
            Debug.Log("saved");
            GameObject.Find("GameControl").GetComponent<Score>().setText();

        }
    }

    public void onClickShieldTime() {
        if (!shieldTimeMaxed && score.cash >= shieldTimeCost) {
            PlayerData playerData = new PlayerData(score.highScore, UP.jetpackDuration, score.cash - shieldTimeCost, UP.playerName, UP.movementSpeed, Score.startAmmo, UP.magnetTime, UP.shieldTime + shieldTimeIncrease);
            SaveSystem.SavePlayerData(playerData);
            SaveSystem.LoadPlayerData();
            Debug.Log("saved");
            GameObject.Find("GameControl").GetComponent<Score>().setText();

        }
    }

    private void jetpackDurationHandler() {
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

        if (jetPackMaxed) {
            jetpackText.text = "MAX";
        } else {
            jetpackText.text = "$" + jetpackDurationCost;
        }
    }

    private void movementSpeedHandler() {
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

        if (movementSpeedMaxed) {
            speedText.text = "MAX";
        } else {
            speedText.text = "$" + movementSpeedCost;
        }


    }

    private void startAmmoHandler() {
        switch (Score.startAmmo) {
            case 5:
                startAmmoCost = 100;
                break;
            case 6:
                startAmmoCost = 300;
                break;
            case 7:
                startAmmoCost = 500;
                break;
            case 8:
                startAmmoCost = 1000;
                break;
            default:
                jetPackMaxed = true;
                break;
        }

        if (startAmmoMaxed) {
            startAmmoText.text = "MAX";
        } else {
            startAmmoText.text = "$" + startAmmoCost;
        }
    }

    private void magnetTimeHandler() {
        switch (UP.magnetTime) {
            case 30f:
                magnetTimeCost = 100;
                break;
            case 35f:
                magnetTimeCost = 300;
                break;
            case 40f:
                magnetTimeCost = 500;
                break;
            case 45f:
                magnetTimeCost = 1000;
                break;
            default:
                magnetTimeMaxed = true;
                break;
        }

        if (magnetTimeMaxed) {
            magnetTimeText.text = "MAX";
        } else {
            magnetTimeText.text = "$" + magnetTimeCost;
        }
    }

    private void shieldTimeHandler() {
        switch (UP.shieldTime) {
            case 5f:
                shieldTimeCost = 100;
                break;
            case 7.5f:
                shieldTimeCost = 300;
                break;
            case 10f:
                shieldTimeCost = 500;
                break;
            case 12.5f:
                shieldTimeCost = 1000;
                break;
            default:
                shieldTimeMaxed = true;
                break;
        }

        if (shieldTimeMaxed) {
            shieldTimeText.text = "MAX";
        } else {
            shieldTimeText.text = "$" + shieldTimeCost;
        }
    }

    
}
