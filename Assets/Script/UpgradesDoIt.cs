using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradesDoIt : MonoBehaviour {

    public float gunRangeIncrease;
    public float gunReloadTimeDecrease;
    public int gunRangeIncreaseCost;
    public int gunReloadTimeDecreaseCost;
    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }

    public void onClickGunRange() {
        Score score = GameObject.Find("GameControl").GetComponent<Score>();
        UpgradesProperties UP = GameObject.Find("GameControl").GetComponent<UpgradesProperties>();
        PlayerData playerData = new PlayerData(score.highScore, UP.gunCooldown, UP.gunRange + gunRangeIncrease, score.cash - gunRangeIncreaseCost);
        SaveSystem.SavePlayerData(playerData);
        Debug.Log("saved");
    }

    public void onClickGunReloadTime() {
        Score score = GameObject.Find("GameControl").GetComponent<Score>();
        UpgradesProperties UP = GameObject.Find("GameControl").GetComponent<UpgradesProperties>();
        PlayerData playerData = new PlayerData(score.highScore, UP.gunCooldown - gunReloadTimeDecrease, UP.gunRange, score.cash - gunReloadTimeDecreaseCost);
        SaveSystem.SavePlayerData(playerData);
        Debug.Log("saved");
    }
}
