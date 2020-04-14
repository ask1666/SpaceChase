using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

/**
 * Class for handling player movement.
 */
public class PlayerController : MonoBehaviour {

    public static float speed = 5f;
    

    private Vector3 fp;   //First touch position
    private Vector3 lp;   //Last touch position
    private float dragDistance;  //minimum distance for a swipe to be registered

    private bool swipeRight;
    private bool swipeLeft;

    public bool magnetActive, shieldActive;
    public GameObject shield, magnet;
    public float step;

    private float magnetTimer, shieldTimer;
    public static float magnetTime, shieldTime;
    public static bool pause;
    private float startMovePos;

    void Start() {
        pause = false;
        dragDistance = Screen.height * 5 / 100; //dragDistance is 7% height of the screen
        
    }
    void Update() {
        
        if (SceneManager.GetActiveScene().name.Equals("Game") || SceneManager.GetActiveScene().name.Equals("Game2") || SceneManager.GetActiveScene().name.Equals("Game3") || SceneManager.GetActiveScene().name.Equals("MainGame")) {
            if (this.gameObject.transform.position.y <= -1.5f) {
                this.gameObject.transform.Translate(Vector2.up * 0.001f);
            }
        }

        if (magnetActive) {
            Magnet();
            GameObject.Find("MagnetPanel").GetComponent<MagnetBarPanel>().magnetRefill();
        } else {
            magnet.SetActive(false);
        }

        if (shieldActive) {
            Shield();
            GameObject.Find("ShieldPanel").GetComponent<ShieldPanel>().refillShield();
        } else if (!GetComponent<Collider2D>().enabled || shield.activeSelf) {
            GetComponent<Collider2D>().enabled = true;
            shield.SetActive(false);
        }

       

        if (Input.GetKeyDown(KeyCode.A) && !swipeRight && !swipeLeft) {
            swipeLeft = true;
            startMovePos = transform.position.x;
        } else if (Input.GetKeyDown(KeyCode.D) && !swipeLeft && !swipeRight) {
            swipeRight = true;
            startMovePos = transform.position.x;
        }

        if (swipeLeft) {
            SwipeLeft();
        } else if (swipeRight) {
            SwipeRight();
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
                        if ((lp.x > fp.x) && !swipeLeft && !swipeRight) {
                            swipeRight = true;
                            startMovePos = transform.position.x;
                        } else if (!(lp.x > fp.x) && !swipeRight && !swipeLeft) {
                            swipeLeft = true;
                            startMovePos = transform.position.x;
                        }
                    } else {   //the vertical movement is greater than the horizontal movement
                        if (lp.y > fp.y)  //If the movement was up
                        {   //Up swipe
                        } else {   //Down swipe
                        }
                    }
                } else {   //It's a tap as the drag distance is less than 20% of the screen height
                }
            }
        }
    }


    private void SwipeRight() {
        if (transform.position.x >= 1f || transform.position.x >= startMovePos + 1.5f || pause) {
            swipeRight = false;
        } else
            transform.position = Vector2.MoveTowards(new Vector2(transform.position.x, transform.position.y), new Vector2(startMovePos + 1.5f, transform.position.y), Time.deltaTime * speed);
    }

    private void SwipeLeft() {
        if (transform.position.x <= -2f || transform.position.x <= startMovePos - 1.5f || pause) {
            swipeLeft = false;
        } else
            transform.position = Vector2.MoveTowards(new Vector2(transform.position.x, transform.position.y), new Vector2(startMovePos - 1.5f, transform.position.y), Time.deltaTime * speed);
    }

    private void Magnet() {
        magnetTimer += Time.deltaTime;
        if (magnetTimer <= magnetTime) {
            magnet.SetActive(true);
            GameObject[] powerUps = GameObject.FindGameObjectsWithTag("Collectable"); //This is the child of the powerup ( need to get the parent before using).

            for (int i = 0; i < powerUps.Length; i++) {
                powerUps[i].transform.parent.gameObject.transform.position = Vector2.MoveTowards(powerUps[i].transform.parent.gameObject.transform.position, transform.position, step);
            }
            MagnetBarPanel.magnetActive = true;
        } else {
            magnetActive = false;
            magnetTimer = 0;
            MagnetBarPanel.magnetActive = false;
        }
    }

    private void Shield() {
        shieldTimer += Time.deltaTime;
        if (shieldTimer <= shieldTime) {
            shield.SetActive(true);
            GetComponent<Collider2D>().enabled = false;
            ShieldPanel.shieldActive = true;
        } else {
            shieldActive = false;
            shieldTimer = 0;
            ShieldPanel.shieldActive = false;
        }
    }



}
