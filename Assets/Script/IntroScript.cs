﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

/**
 * Class for handling intro animation etc.
 */
public class IntroScript : MonoBehaviour {

    private Animator SpaceShip;
    private Animator Player;
    private ParticleSystem playerJetPack;

    void Start() {
        Time.timeScale = 1;
        SpaceShip = GameObject.Find("SpaceShip").GetComponent<Animator>();
        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
        playerJetPack = GameObject.Find("JetPack").GetComponent<ParticleSystem>();
        ObstacleSpawn1 asteroidSpawner = GameObject.Find("Spawner").GetComponent<ObstacleSpawn1>();
        PowerUpSpawner powerUpSpawner = GameObject.Find("Spawner").GetComponent<PowerUpSpawner>();
        asteroidSpawner.dontSpawn = true;
        powerUpSpawner.dontSpawn = true;

        StartCoroutine(StartIntro());
        asteroidSpawner.dontSpawn = false;
        powerUpSpawner.dontSpawn = false;

    }


    IEnumerator StartIntro() {

        Player.applyRootMotion = false;
        SpaceShip.SetTrigger("SpaceShipIntroTrigger");
        Player.SetTrigger("playerIntroTrigger");
        yield return new WaitForSeconds(2.2f);
        playerJetPack.Play();
        yield return new WaitForSeconds(0.9f);
        Player.applyRootMotion = true;
    }
}
