using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;
using UnityEngine;

/**
 * Class for pausing game.
 */
public class Pause : MonoBehaviour
{

    public GameObject continueButton;
    public GameObject mainMenuButton;
    private bool paused = false;

    void Start()
    {
        continueButton.SetActive(false);
        mainMenuButton.SetActive(false);
        paused = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            if (paused) {
                onClick();
            } else {
                DoPause();
                Debug.Log("doPause");
            }
        }

        
    }

    private void DoPause() {
        Time.timeScale = 0;
        continueButton.SetActive(true);
        mainMenuButton.SetActive(true);
        paused = true;

    }

    public void onClick() {
        continueButton.SetActive(false);
        mainMenuButton.SetActive(false);
        Time.timeScale = 1;
        paused = false;
    }
}
