using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;


/**
 * Class for holding player data.
 */
[System.Serializable]
public class PlayerData {

    public int highScore;
    public float jetpackDuration;
    public int cash;
    public string playerPrefab;
    public float movementSpeed;
    public int startAmmo;
    public float magnetTime, shieldTime;

    public PlayerData(int highScore, float jetpackDuration, int cash, string playerPrefab, float movementSpeed, int startAmmo, float magnetTime, float shieldTime) {
        this.highScore = highScore;
        this.jetpackDuration = jetpackDuration;
        this.cash = cash;
        this.playerPrefab = playerPrefab;
        this.movementSpeed = movementSpeed;
        this.startAmmo = startAmmo;
        this.magnetTime = magnetTime;
        this.shieldTime = shieldTime;
    }

    
}
