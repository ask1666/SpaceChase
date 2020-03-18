using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Class for handling button clicks on Upgrade buttons.
 */
public class UpgradesOnClick : MonoBehaviour {

    public float gunRangeIncrease;
    public float gunReloadTimeDecrease;
    public int gunRangeIncreaseCost;
    public int gunReloadTimeDecreaseCost;
    
    public void onClickGunRange() {
        Score score = GameObject.Find("GameControl").GetComponent<Score>();
        UpgradesProperties UP = GameObject.Find("GameControl").GetComponent<UpgradesProperties>();
        PlayerData playerData = new PlayerData(score.highScore, UP.gunCooldown, UP.gunRange + gunRangeIncrease, score.cash - gunRangeIncreaseCost, UP.playerPrefab.name);
        SaveSystem.SavePlayerData(playerData);
        SaveSystem.LoadPlayerData();
        Debug.Log("saved");
    }

    public void onClickGunReloadTime() {
        Score score = GameObject.Find("GameControl").GetComponent<Score>();
        UpgradesProperties UP = GameObject.Find("GameControl").GetComponent<UpgradesProperties>();
        PlayerData playerData = new PlayerData(score.highScore, UP.gunCooldown - gunReloadTimeDecrease, UP.gunRange, score.cash - gunReloadTimeDecreaseCost, UP.playerPrefab.name);
        SaveSystem.SavePlayerData(playerData);
        SaveSystem.LoadPlayerData();
        Debug.Log("saved");
    }


}
