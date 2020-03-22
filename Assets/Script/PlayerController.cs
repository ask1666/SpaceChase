using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

/**
 * Class for handling player movement.
 */
public class PlayerController : MonoBehaviour {

    public float speed = 0.01f;
    public VariableJoystick variableJoystick;

    void Start() {
        variableJoystick = GameObject.Find("Variable Joystick").GetComponent<VariableJoystick>(); 
    }
    void Update() {

        if (SceneManager.GetActiveScene().name.Equals("Game2")) {
            if (this.gameObject.transform.position.y <= -1f) {
                this.gameObject.transform.Translate(Vector2.up * 0.001f);
            }
        }

        Vector2 direction = Vector2.right * variableJoystick.Horizontal;
            this.gameObject.transform.Translate(direction * (Time.deltaTime * speed));
        

        if (Input.GetKey(KeyCode.A)) {
            this.gameObject.transform.Translate(Vector2.left * (Time.deltaTime * speed));
        } else if (Input.GetKey(KeyCode.D)) {
            this.gameObject.transform.Translate(Vector2.right * (Time.deltaTime * speed));
        }

    }

    


}
