using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class IntroScript : MonoBehaviour {

    private Animator SpaceShip;
    private Animator Player;
    private ParticleSystem playerJetPack;

    // Start is called before the first frame update
    void Start() {
        Time.timeScale = 1;
        SpaceShip = GameObject.Find("SpaceShip").GetComponent<Animator>();
        Player = GameObject.Find("Player").GetComponent<Animator>();
        playerJetPack = GameObject.Find("JetPack").GetComponent<ParticleSystem>();
        AsteroidSpawn asteroidSpawner = GameObject.Find("Spawner").GetComponent<AsteroidSpawn>();
        PowerUpSpawner powerUpSpawner = GameObject.Find("Spawner").GetComponent<PowerUpSpawner>();
        PlayerController playercontroller = GameObject.Find("Player").GetComponent<PlayerController>();
        asteroidSpawner.dontSpawn = true;
        powerUpSpawner.dontSpawn = true;
        playercontroller.blockPlayerControl = true;

        StartCoroutine(StartIntro());
        asteroidSpawner.dontSpawn = false;
        powerUpSpawner.dontSpawn = false;
        playercontroller.blockPlayerControl = false;

    }

    // Update is called once per frame
    void Update() {

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
