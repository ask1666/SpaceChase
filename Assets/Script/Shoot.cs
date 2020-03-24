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

    private Vector3 fp;   //First touch position
    private Vector3 lp;   //Last touch position
    private float dragDistance;  //minimum distance for a swipe to be registered

    // Start is called before the first frame update
    void Start() {

        shootBtn = GameObject.Find("ShootBtn").GetComponent<Button>();
        score = GameObject.Find("GameControl").GetComponent<Score>();
        shootBtn.onClick.AddListener(delegate () { OnClick(); });
        shootBtn.GetComponent<Button>().interactable = true;
        dragDistance = Screen.height * 5 / 100; //dragDistance is 7% height of the screen
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

            if (shootBtn.GetComponent<Button>().interactable == true && score.ammo >= 0) {
                OnClick();
            }
        }
        if (score.ammo <= 0) {
            shoot = false;
            shootBtn.GetComponent<Button>().interactable = false;
        } else if (score.ammo > 0) {
            shoot = true;
            shootBtn.GetComponent<Button>().interactable = true;
        }

        if (Input.touchCount == 1) // user is touching the screen with a single touch
        {
            Touch touch = Input.GetTouch(0); // get the touch
            if (touch.phase == TouchPhase.Began) //check for the first touch
            {
                fp = touch.position;
                lp = touch.position;
            } else if (touch.phase == TouchPhase.Moved) // update the last position based on where they moved
              {
                lp = touch.position;
            } else if (touch.phase == TouchPhase.Ended) //check if the finger is removed from the screen
              {
                lp = touch.position;  //last touch position. Ommitted if you use list

                //Check if drag distance is greater than 20% of the screen height
                if (Mathf.Abs(lp.x - fp.x) > dragDistance || Mathf.Abs(lp.y - fp.y) > dragDistance) {//It's a drag
                                                                                                     //check if the drag is vertical or horizontal
                    if (Mathf.Abs(lp.x - fp.x) > Mathf.Abs(lp.y - fp.y)) {   //If the horizontal movement is greater than the vertical movement...
                        if ((lp.x > fp.x))  //If the movement was to the right)
                        {   //Right swipe
                        } else {   //Left swipe
                        }
                    } else {   //the vertical movement is greater than the horizontal movement
                        if (lp.y > fp.y)  //If the movement was up
                        {   //Up swipe
                        } else {   //Down swipe
                        }
                    }
                } else {   //It's a tap as the drag distance is less than 20% of the screen height
                    if (shootBtn.GetComponent<Button>().interactable == true && score.ammo >= 0) {
                        OnClick();
                    }
                }
            }
        }
    }

    IEnumerator doShoot() {
        if (bullet.gameObject.name.Equals("Missile")) {
            score.ammo -= 1;
            GameObject spawnedBullet = Instantiate(bullet, bulletSpawnPoint.position, Quaternion.identity);
            spawnedBullet.transform.localScale = new Vector3(1f, 1f, 1f);

            sound.Play();
            Destroy(spawnedBullet, 0.9f);
            yield return new WaitForSeconds(soundPlayTime);
            sound.Stop();


        } else {
            score.ammo -= 1;
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

        }

    }

    public void OnClick() {
        if (gunCooldownTimer > gunCooldown && score.ammo > 0) {
            StartCoroutine(doShoot());
            shoot = false;
            gunCooldownTimer = 0;
        }
    }


}
