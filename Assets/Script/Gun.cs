using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

/**
 * Class for handling shooting etc.
 */
public class Gun : MonoBehaviour {

    private LineRenderer lr;
    public Button shootBtn;
    public AudioSource sound;
    public float beamRange;
    public static bool shoot = false;
    public float gunCooldown = 1f;
    private float gunCooldownTimer = 1f;

    public static bool pause;
    private Score score;

    private Vector3 fp;   //First touch position
    private Vector3 lp;   //Last touch position
    private float dragDistance;  //minimum distance for a swipe to be registered


    void Start() {
        pause = false;
        shootBtn = GameObject.Find("ShootBtn").GetComponent<Button>();
        lr = gameObject.GetComponent<LineRenderer>();
        score = GameObject.Find("GameControl").GetComponent<Score>();
        shootBtn.onClick.AddListener(delegate () { OnClick(); });
        dragDistance = Screen.height * 5 / 100; //dragDistance is 7% height of the screen
    }

    void Update() {
        gunCooldownTimer += Time.deltaTime;
        Debug.DrawRay(new Vector2(transform.position.x -0f, transform.position.y), Vector2.up * beamRange, Color.green);

        RaycastHit2D hit = Physics2D.Raycast(new Vector2(transform.position.x - 0f, transform.position.y), Vector2.up * beamRange);
        
        if (hit.collider != null) {
            float distance = Mathf.Abs(hit.point.y - transform.position.y);
            if (hit.collider.gameObject.tag.Equals("Asteroid") && lr.enabled == true && distance <= beamRange) {
                hit.collider.gameObject.GetComponent<ObstacleExplosion>().explode = true;
            } 
            if (hit.collider.gameObject.tag.Equals("Mine") && lr.enabled == true && distance <= beamRange) {
                hit.collider.gameObject.GetComponent<MineExplosion>().explode = true;
            }
            if (hit.collider.gameObject.tag.Equals("Garbage") && lr.enabled == true && distance <= beamRange) {
                hit.collider.gameObject.GetComponent<ObstacleExplosion>().explode = true;
            }
            if (hit.collider.gameObject.tag.Equals("Enemy") && lr.enabled == true && distance <= beamRange) {
                hit.collider.gameObject.GetComponent<EnemyController>().Die();
            }
        }

        if (gunCooldownTimer > gunCooldown) {
            shootBtn.GetComponent<Button>().interactable = true;
        } else {
            shootBtn.GetComponent<Button>().interactable = false;
        }

        if (lr.enabled) {
            lr.SetPosition(0, new Vector2(transform.position.x - 0f, transform.position.y));
            lr.SetPosition(1, new Vector2(transform.position.x - 0f, transform.position.y + beamRange));
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

    IEnumerator doBeam() {
        if (score.ammo > 0)
            score.ammo -= 1;
        lr.enabled = true;
        sound.Play();
        lr.SetPosition(0, new Vector2(transform.position.x - 0f, transform.position.y));
        lr.SetPosition(1, new Vector2(transform.position.x - 0f, transform.position.y + beamRange));
        yield return new WaitForSeconds(0.8f);
        lr.enabled = false;
        lr.SetPosition(1, transform.position);
        
    }

    /**
     * When you shoot, the doBeam() is called, and the cooldownTimer is reset.
     */
    public void OnClick() {
        if (gunCooldownTimer > gunCooldown && score.ammo > 0 && !pause) {
            StartCoroutine(doBeam());
            shoot = false;
            gunCooldownTimer = 0;
        }
    }

    

}
