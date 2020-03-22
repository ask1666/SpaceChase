using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour {

    public GameObject playerPrefab;

    // Start is called before the first frame update
    void Awake() {
        
        try {
            playerPrefab = GameObject.Find("GameControl").GetComponent<UpgradesProperties>().playerPrefab;
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            if (player == null) {
                //Spawn Selected Loadout
                Instantiate(playerPrefab);

            }
        } catch (NullReferenceException) {
            playerPrefab = Resources.Load<GameObject>("Player2");
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            if (player == null) {
                //Spawn Selected Loadout
                Instantiate(playerPrefab);
                Debug.Log("no exception");
            }
        }
    }

    // Update is called once per frame
    void Update() {
        
        
    }
}
