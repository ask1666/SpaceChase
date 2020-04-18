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
            }
        }

        
    }

    private void DoPause() {
        ObstacleExplosion.pause = true;
        Shoot.pause = true;
        Gun.pause = true;
        PlayerController.pause = true;
        SkyBoxScroll.pause = true;
        Score.pause = true;
        EnemyBullet.pause = true;
        Bullet.pause = true;
        Time.timeScale = 0;
        continueButton.SetActive(true);
        mainMenuButton.SetActive(true);
        paused = true;

    }

    public void onClick() {
        ObstacleExplosion.pause = false;
        Shoot.pause = false;
        Gun.pause = false;
        PlayerController.pause = false;
        SkyBoxScroll.pause = false;
        Score.pause = false;
        EnemyBullet.pause = false;
        Bullet.pause = false;
        continueButton.SetActive(false);
        mainMenuButton.SetActive(false);
        Time.timeScale = 1;
        paused = false;
    }
}
