using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

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

        Vector2 direction = Vector2.right * variableJoystick.Horizontal;
            this.gameObject.transform.Translate(direction * (Time.deltaTime * speed));
        

        if (Input.GetKey(KeyCode.A)) {
            this.gameObject.transform.Translate(Vector2.left * (Time.deltaTime * speed));
        } else if (Input.GetKey(KeyCode.D)) {
            this.gameObject.transform.Translate(Vector2.right * (Time.deltaTime * speed));
        }

    }

    


}
