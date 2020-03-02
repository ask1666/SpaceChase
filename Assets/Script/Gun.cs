﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

/**
 * Class for handling shooting etc.
 */
public class Gun : MonoBehaviour {

    private LineRenderer lr;
    public Button shootBtn;
    public float beamRange;
    public static bool shoot = false;
    public float gunCooldown = 1f;
    private float gunCooldownTimer = 1f;

    
    void Start() {
        lr = gameObject.GetComponent<LineRenderer>();
    }

    void FixedUpdate() {
        gunCooldownTimer += Time.deltaTime;

        Debug.DrawRay(new Vector2(transform.position.x -0.09f, transform.position.y), Vector2.up * beamRange, Color.green);

        RaycastHit2D hit = Physics2D.Raycast(new Vector2(transform.position.x - 0.09f, transform.position.y), Vector2.up * beamRange);

        if (hit.collider != null) {
            float distance = Mathf.Abs(hit.point.y - transform.position.y);
            if (hit.collider.gameObject.tag == "Asteroid" && lr.enabled == true && distance <= beamRange) {
                hit.collider.gameObject.GetComponent<AsteroidExplosion>().explode = true;
            }
        }

        if (gunCooldownTimer > gunCooldown) {
            shootBtn.GetComponent<Button>().interactable = true;
        } else {
            shootBtn.GetComponent<Button>().interactable = false;
        }


    }

    IEnumerator doBeam() {

        lr.enabled = true;
        lr.SetPosition(0, new Vector2(transform.position.x - 0.09f, transform.position.y));
        lr.SetPosition(1, new Vector2(transform.position.x - 0.09f, transform.position.y + beamRange));
        yield return new WaitForSeconds(0.2f);
        lr.enabled = false;
        lr.SetPosition(1, transform.position);
        
    }

    /**
     * When you shoot, the doBeam() is called, and the cooldownTimer is reset.
     */
    public void OnClick() {
        if (gunCooldownTimer > gunCooldown) {
            StartCoroutine(doBeam());
            shoot = false;
            gunCooldownTimer = 0;
        }
    }

}
