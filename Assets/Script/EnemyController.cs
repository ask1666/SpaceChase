using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

    
    public float speed;
    public Animator anim;
    public GameObject graphic;
    public ParticleSystem flames;

    // Start is called before the first frame update
    void Start() {
    }

    // Update is called once per frame
    void Update() {
        transform.position = (Vector2.MoveTowards(new Vector2(transform.position.x, transform.position.y), new Vector2(transform.position.x, 2.5f), speed * Time.deltaTime));
    }

    public void Die() {
        Destroy(graphic);
        flames.Stop();
        anim.SetTrigger("explode");
        Destroy(this.gameObject, 1f);
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag.Equals("Enemy")) {
            if (this.transform.position.y > collision.transform.position.y) {
                Destroy(this.gameObject);
            } else {
                Destroy(collision.gameObject);
            }
        }
    }
}
