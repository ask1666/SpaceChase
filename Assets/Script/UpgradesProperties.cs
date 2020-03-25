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

    // Start is called before the first frame update
    void Start() {

        
    }

    // Update is called once per frame
    void Update() {

        SceneManager.activeSceneChanged += ChangedActiveScene;
        for (int i = 0; i < playerModels.Length; i++) {
            if (playerModels[i].name.Equals(playerName)) {
                selectedPlayer = playerModels[i];
            }
        }

    }

    private void ChangedActiveScene(Scene previous, Scene current) {
        if (current.name.Equals("Game") || current.name.Equals("Game2") || current.name.Equals("Game3") || current.name.Equals("MainGame")) {
            JetPackBar.maxJetTime = jetpackDuration;
            PlayerController.speed = movementSpeed;
        }
    }

    
}
