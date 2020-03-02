using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

/**
 * Class for handling player movement.
 */
public class PlayerController : MonoBehaviour {

    public float speed = 0.01f;

    public bool blockPlayerControl = false;
    void Update() {


        if (!IsPointerOverUIObject()) {
            if (Input.touchCount > 0) {                 //Get touch from left or right and act accordingly.
                var touch = Input.GetTouch(0);
                if (touch.position.x < Screen.width / 2) {
                    if (!blockPlayerControl)
                        this.gameObject.transform.Translate(Vector2.left * (Time.deltaTime * speed));
                } else if (touch.position.x > Screen.width / 2) {
                    if (!blockPlayerControl)
                        this.gameObject.transform.Translate(Vector2.right * (Time.deltaTime * speed));
                }
            } else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) {            //get key from left or right and act accordingly.
                if (!blockPlayerControl)
                    this.gameObject.transform.Translate(Vector2.left * (Time.deltaTime * speed));
            } else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) {
                if (!blockPlayerControl)
                    this.gameObject.transform.Translate(Vector2.right * (Time.deltaTime * speed));
            }
        }

    }

    private bool IsPointerOverUIObject() {
        PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);
        eventDataCurrentPosition.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventDataCurrentPosition, results);
        return results.Count > 0;
    }


}
