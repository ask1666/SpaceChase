using UnityEngine;

public class PlayerController : MonoBehaviour {

    
    public float speed = 0.01f;
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
        if (Input.touchCount > 0) {
            var touch = Input.GetTouch(0);

             if (touch.position.x < Screen.width / 2) {

                this.gameObject.transform.Translate(Vector2.left * (Time.deltaTime * speed));

                

            } else if (touch.position.x > Screen.width / 2) {

                this.gameObject.transform.Translate(Vector2.right * (Time.deltaTime * speed));

                

            }
        }

    }
}
