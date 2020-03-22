using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Shoot : MonoBehaviour {

    public Transform bulletSpawnPoint;
    public GameObject bullet;
    public ParticleSystem smoke;
    public ParticleSystem sparks;
    public Animator anim;
    public AudioSource sound;

    public static bool shoot = false;
    public float gunCooldown = 1f;
    private float gunCooldownTimer = 1f;
    public float soundPlayTime;
    private Score score;

    private Button shootBtn;

    // Start is called before the first frame update
    void Start() {
        
        shootBtn = GameObject.Find("ShootBtn").GetComponent<Button>();
        score = GameObject.Find("GameControl").GetComponent<Score>();
        shootBtn.onClick.AddListener(delegate () { OnClick(); });

    }

    // Update is called once per frame
    void Update() {
        gunCooldownTimer += Time.deltaTime;

        if (gunCooldownTimer > gunCooldown) {
            shootBtn.GetComponent<Button>().interactable = true;
        } else {
            shootBtn.GetComponent<Button>().interactable = false;
        }

        if (Input.GetKeyDown(KeyCode.Space)) {

            if (shootBtn.GetComponent<Button>().interactable == true && score.ammo != 0)
                OnClick();
        }

        if (score.ammo == 0) {
            shoot = false;
            shootBtn.GetComponent<Button>().interactable = false;
        } else if (score.ammo > 0) {
            shoot = true;
            shootBtn.GetComponent<Button>().interactable = true;
        }
    }

    IEnumerator doShoot() {
        
        GameObject spawnedBullet = Instantiate(bullet, bulletSpawnPoint.position, Quaternion.identity);
        spawnedBullet.transform.localScale = new Vector3(1f, 1f, 1f);
        try {
            smoke.Play();
            sparks.Play();
        } catch (UnassignedReferenceException) {

        }
        anim.SetTrigger("Shoot");
        sound.Play();
        Destroy(spawnedBullet, 0.9f);
        yield return new WaitForSeconds(soundPlayTime);
        sound.Stop();
        score.ammo -= 1;


    }

    public void OnClick() {
        if (gunCooldownTimer > gunCooldown && score.ammo > 0) {
            StartCoroutine(doShoot());
            shoot = false;
            gunCooldownTimer = 0;
        }
    }

    
}
