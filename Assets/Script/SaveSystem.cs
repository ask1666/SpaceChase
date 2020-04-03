using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Numerics;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

/**
 * Class for handling saving and loading playerdata.
 */
public static class SaveSystem {
    public static void SavePlayerData(PlayerData data) {


        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/player.txt";
        FileStream stream = new FileStream(path, FileMode.Create);


        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static void LoadPlayerData() {
        string path = Application.persistentDataPath + "/player.txt";
        if (File.Exists(path)) {

            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            PlayerData data = formatter.Deserialize(stream) as PlayerData;
            stream.Close();

            GameObject gameControl = GameObject.Find("GameControl");
            gameControl.GetComponent<Score>().highScore = data.highScore;
            gameControl.GetComponent<Score>().cash = data.cash;
            Score.startAmmo = data.startAmmo;
            gameControl.GetComponent<UpgradesProperties>().jetpackDuration = data.jetpackDuration;
            gameControl.GetComponent<UpgradesProperties>().playerName = data.playerPrefab;
            gameControl.GetComponent<UpgradesProperties>().movementSpeed = data.movementSpeed;
            

        } else {
            Debug.LogError("Save file not found in" + path);


        }
    }
}
