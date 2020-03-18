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
    public float gunReloadTime;
    public float gunRange;
    public int cash;
    public string playerPrefab;

    public PlayerData (int highScore, float gunReloadTime, float gunRange, int cash, string playerPrefab) {
        this.highScore = highScore;
        this.gunReloadTime = gunReloadTime;
        this.gunRange = gunRange;
        this.cash = cash;
        this.playerPrefab = playerPrefab;
    }

    
}
