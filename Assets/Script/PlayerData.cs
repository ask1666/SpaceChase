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

    public PlayerData(int highScore, float jetpackDuration, int cash, string playerPrefab, float movementSpeed) {
        this.highScore = highScore;
        this.jetpackDuration = jetpackDuration;
        this.cash = cash;
        this.playerPrefab = playerPrefab;
        this.movementSpeed = movementSpeed;
    }

    
}
