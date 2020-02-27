using UnityEngine;

/**
 * Class for handling player movement.
 */
public class PlayerController : MonoBehaviour {

    public float speed = 0.01f;
    public bool moveLeft = false;
    public bool moveRight = false;
    public bool blockPlayerControl = false;
    void Update() {

        if (moveLeft) {
            if (!blockPlayerControl)
            this.gameObject.transform.Translate(Vector2.left * (Time.deltaTime * speed));

        } else if (moveRight) {
            if (!blockPlayerControl)
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
