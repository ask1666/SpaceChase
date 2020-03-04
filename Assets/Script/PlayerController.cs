using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

/**
 * Class for handling player movement.
 */
public class PlayerController : MonoBehaviour {

    public float speed = 0.01f;
    public VariableJoystick variableJoystick;
    void Update() {

        Vector2 direction = Vector2.right * variableJoystick.Horizontal;
            this.gameObject.transform.Translate(direction * (Time.deltaTime * speed));
        

    }

    


}
