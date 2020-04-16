using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/**
 * Class for setting and holding correct upgrade properties upon entering game.
 */
public class UpgradesProperties : MonoBehaviour {

    public float jetpackDuration;
    public float movementSpeed;
    public string playerName;
    public GameObject[] playerModels;
    public GameObject selectedPlayer;
    public float magnetTime, shieldTime;

    // Start is called before the first frame update
    void Start() {
        SceneManager.activeSceneChanged += ChangedActiveScene;
        for (int i = 0; i < playerModels.Length; i++) {
            if (playerModels[i].name.Equals(playerName)) {
                selectedPlayer = playerModels[i];
            }
        }
    }

    // Update is called once per frame
    void Update() {

        
        

    }

    private void ChangedActiveScene(Scene previous, Scene current) {
        if (current.name.Equals("MainGame")) {
            JetPackBar.maxJetTime = jetpackDuration;
            PlayerController.speed = movementSpeed;
            PlayerController.magnetTime = magnetTime;
            PlayerController.shieldTime = shieldTime;
        } else if (current.name.Equals("MainMenu")) {
            for (int i = 0; i < playerModels.Length; i++) {
                if (playerModels[i].name.Equals(playerName)) {
                    selectedPlayer = playerModels[i];
                }
            }
        }
    }

    
}
