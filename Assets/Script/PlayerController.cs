using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

/**
 * Class for handling player movement.
 */
public class PlayerController : MonoBehaviour {

    public float speed = 0.01f;
    //public VariableJoystick variableJoystick;

    private Vector3 fp;   //First touch position
    private Vector3 lp;   //Last touch position
    private float dragDistance;  //minimum distance for a swipe to be registered

    void Start() {
        //variableJoystick = GameObject.Find("Variable Joystick").GetComponent<VariableJoystick>(); 
        dragDistance = Screen.height * 7 / 100; //dragDistance is 7% height of the screen
    }
    void Update() {
        
        if (SceneManager.GetActiveScene().name.Equals("Game") || SceneManager.GetActiveScene().name.Equals("Game2") || SceneManager.GetActiveScene().name.Equals("Game3") || SceneManager.GetActiveScene().name.Equals("MainGame")) {
            if (this.gameObject.transform.position.y <= -1.5f) {
                this.gameObject.transform.Translate(Vector2.up * 0.001f);
            }
        }

       // Vector2 direction = Vector2.right * variableJoystick.Horizontal;
       // this.gameObject.transform.Translate(direction * (Time.deltaTime * speed));

        if (Input.GetKeyDown(KeyCode.A)) {
            SwipeLeft();
        } else if (Input.GetKeyDown(KeyCode.D)) {
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
                        if ((lp.x > fp.x))  //If the movement was to the right)
                        {   //Right swipe
                            SwipeRight();
                        } else {   //Left swipe
                            SwipeLeft();
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
        if (transform.position.x >= 1.7f) {

        } else
            transform.Translate(new Vector2( 1.7f, 0));
    }

    private void SwipeLeft() {
        if (transform.position.x <= -1.7f) {

        } else
            transform.Translate(new Vector2( - 1.7f, 0));
    }



}
