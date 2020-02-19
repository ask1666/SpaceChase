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
        
            SpaceShip = GameObject.Find("SpaceShip").GetComponent<Animator>();
            Player = GameObject.Find("Player").GetComponent<Animator>();
            playerJetPack = GameObject.Find("JetPack").GetComponent<ParticleSystem>();
            AsteroidSpawn asteroidSpawner = GameObject.Find("AsteroidSpawner").GetComponent<AsteroidSpawn>();
            PlayerController playercontroller = GameObject.Find("Player").GetComponent<PlayerController>();
            asteroidSpawner.dontSpawn = true;
            playercontroller.blockPlayerControl = true;
            
            StartCoroutine(StartIntro());
            asteroidSpawner.dontSpawn = false;
            playercontroller.blockPlayerControl = false;
        
    }

    // Update is called once per frame
    void Update() {

    }


    IEnumerator StartIntro() {

        Player.applyRootMotion = false;
        SpaceShip.SetTrigger("SpaceShipIntroTrigger");
        Player.SetTrigger("playerIntroTrigger");
        Debug.Log("PlayIntro0 " + Player);
        yield return new WaitForSeconds(2.2f);
        Debug.Log("PlayIntro1 " + Player);
        playerJetPack.Play();
        yield return new WaitForSeconds(0.9f);
        Player.applyRootMotion = true;
        Debug.Log("PlayIntro2 " + Player);
    }
}
