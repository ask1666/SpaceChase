using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Numerics;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

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
            GameObject gun = GameObject.Find("Gun");
            gameControl.GetComponent<Score>().highScore = data.highScore;
            gameControl.GetComponent<Score>().cash = data.cash;
            GameObject.Find("GameControl").GetComponent<UpgradesProperties>().gunRange = data.gunRange;
            GameObject.Find("GameControl").GetComponent<UpgradesProperties>().gunCooldown = data.gunReloadTime;


        } else {
            Debug.LogError("Save file not found in" + path);


        }
    }
}
