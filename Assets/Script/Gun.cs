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
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.up);
        
        
    }

    IEnumerator doBeam() {

        lr.enabled = true;
        lr.SetPosition(0, new Vector2(transform.position.x + 0.52f, transform.position.y + 0.7f));
        lr.SetPosition(1, new Vector2(transform.position.x + 0.52f, transform.position.y + beamRange));
        yield return new WaitForSeconds(0.2f);
        lr.enabled = false;
        lr.SetPosition(1, transform.position);
        

    }

    public void OnClick() {
        Debug.Log(gunCooldownTimer);
        if (gunCooldownTimer > gunCooldown) {
            StartCoroutine(doBeam());
            shoot = false;
            gunCooldownTimer = 0;
        }
    }

    
}
