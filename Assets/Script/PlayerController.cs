using UnityEngine;

public class PlayerController : MonoBehaviour {


    public float speed = 0.01f;
    public bool moveLeft = false;
    public bool moveRight = false;
    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {

        /**
         * If you touch the screen on the left player will move to the left,
         * if you touch the screen on the right the player will move to the right.
         * speed = the rate of speed the player will move at.
        */

        if (moveLeft) {

            this.gameObject.transform.Translate(Vector2.left * (Time.deltaTime * speed));

        } else if (moveRight) {

            this.gameObject.transform.Translate(Vector2.right * (Time.deltaTime * speed));

        }

    }



    public void OnLeftBtnDown() {
        moveLeft = true;
        
    }

    public void OnLeftBtnUp() {
        moveLeft = false;
        
    }

    public void OnRightBtnDown() {
        moveRight = true;
        
    }

    public void OnRightBtnUp() {
        moveRight = false;
        
    }
}
