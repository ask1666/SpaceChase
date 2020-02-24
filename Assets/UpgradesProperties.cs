using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UpgradesProperties : MonoBehaviour {

    public float gunRange;
    public float gunCooldown;

    // Start is called before the first frame update
    void Start() {

        if (SceneManager.GetActiveScene().name.Equals("Game")) {
            GameObject.Find("Gun").GetComponent<Gun>().gunCooldown = gunCooldown;
            GameObject.Find("Gun").GetComponent<Gun>().beamRange = gunRange;
        }
    }

    // Update is called once per frame
    void Update() {

        

    }
}
