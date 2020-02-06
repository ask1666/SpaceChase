using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class Gun : MonoBehaviour {

    private LineRenderer lr;
    public float beamRange;
    public static bool shoot = false;
    public float gunCooldown = 1f;
    private float gunCooldownTimer = 0;

    // Start is called before the first frame update
    void Start() {
        lr = gameObject.GetComponent<LineRenderer>();
        
    }

    // Update is called once per frame
    void FixedUpdate() {
        gunCooldownTimer += Time.deltaTime;

        Debug.DrawRay(new Vector2(transform.position.x + 0.52f, transform.position.y + 0.7f), Vector2.up * beamRange, Color.green);

        RaycastHit2D hit = Physics2D.Raycast(new Vector2(transform.position.x + 0.52f, transform.position.y + 0.7f), Vector2.up * beamRange);

        if ((hit.collider != null && hit.collider.gameObject.tag == "Asteroid") && lr.enabled == true) {
            
                hit.collider.gameObject.GetComponent<AsteroidExplosion>().explode = true;
                
            
        }


    }

    IEnumerator doBeam() {

        lr.enabled = true;
        lr.SetPosition(0, new Vector2(transform.position.x + 0.52f, transform.position.y + 0.7f));
        lr.SetPosition(1, new Vector2(transform.position.x + 0.52f, transform.position.y + beamRange));
        yield return new WaitForSeconds(0.2f);
        lr.enabled = false;
        lr.SetPosition(1, transform.position);
        

    }

    /**
     * When you shoot the doBeam() is called, and the cooldownTimer is reset.
     */
    public void OnClick() {
        if (gunCooldownTimer > gunCooldown) {
            StartCoroutine(doBeam());
            shoot = false;
            gunCooldownTimer = 0;
        }
    }

    
}
