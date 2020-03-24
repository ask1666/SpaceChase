using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Class for handling button clicks on Upgrade buttons.
 */
public class UpgradesOnClick : MonoBehaviour {

    public float jetpackDurationIncrease;
    public int jetpackDurationCost;
    
    public void onClickJetpackDuration() {
        Score score = GameObject.Find("GameControl").GetComponent<Score>();
        UpgradesProperties UP = GameObject.Find("GameControl").GetComponent<UpgradesProperties>();
        PlayerData playerData = new PlayerData(score.highScore, UP.jetpackDuration + jetpackDurationIncrease, score.cash - jetpackDurationCost, UP.playerPrefab.name);
        SaveSystem.SavePlayerData(playerData);
        SaveSystem.LoadPlayerData();
        Debug.Log("saved");
    }

    


}
