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
        UpgradesProperties UP = GameObject.Find("GameControl").GetComponent<UpgradesProperties>();
        if (File.Exists(path)) {

            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            PlayerData data = formatter.Deserialize(stream) as PlayerData;
            stream.Close();

            GameObject gameControl = GameObject.Find("GameControl");
            gameControl.GetComponent<Score>().highScore = data.highScore;
            gameControl.GetComponent<Score>().cash = data.cash;
            
            Score.startAmmo = data.startAmmo;
            
            UP.jetpackDuration = data.jetpackDuration;
            UP.playerName = data.playerPrefab;
            UP.movementSpeed = data.movementSpeed;
            UP.magnetTime = data.magnetTime;
            UP.shieldTime = data.shieldTime;

        } else {
            Debug.Log("Save file not found in" + path + "\n setting start values.");
            PlayerData playerData = new PlayerData(0, 30, 0, "Player2", 5f, 5, 30, 5);
            SavePlayerData(playerData);
            LoadPlayerData();


        }
    }
}
