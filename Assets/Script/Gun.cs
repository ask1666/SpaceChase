using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

/**
 * Class for handling shooting etc.
 */
public class Gun : MonoBehaviour {

    private LineRenderer lr;
    public Button shootBtn;
    public TextMeshProUGUI ammoText;
    public float beamRange;
    public static bool shoot = false;
    public float gunCooldown = 1f;
    private float gunCooldownTimer = 1f;
    public int ammo;
    public int startAmmo;
    public int ammoRefillAmount;

    
    void Start() {
        lr = gameObject.GetComponent<LineRenderer>();
        ammo = startAmmo;
    }

    void Update() {
        gunCooldownTimer += Time.deltaTime;
        ammoText.text = "" + ammo;
        Debug.DrawRay(new Vector2(transform.position.x -0.15f, transform.position.y), Vector2.up * beamRange, Color.green);

        RaycastHit2D hit = Physics2D.Raycast(new Vector2(transform.position.x - 0.15f, transform.position.y), Vector2.up * beamRange);

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

        if (lr.enabled) {
            lr.SetPosition(0, new Vector2(transform.position.x - 0.15f, transform.position.y));
            lr.SetPosition(1, new Vector2(transform.position.x - 0.15f, transform.position.y + beamRange));
        }

        if (Input.GetKeyDown(KeyCode.Space)) {

            if (shootBtn.GetComponent<Button>().interactable == true && ammo != 0)
            OnClick();
        }

        if (ammo == 0) {
            shoot = false;
            shootBtn.GetComponent<Button>().interactable = false;
        } else if (ammo > 0) {
            shoot = true;
            shootBtn.GetComponent<Button>().interactable = true;
        }

    }

    IEnumerator doBeam() {
        if (ammo > 0)
            ammo -= 1;
        lr.enabled = true;
        lr.SetPosition(0, new Vector2(transform.position.x - 0.15f, transform.position.y));
        lr.SetPosition(1, new Vector2(transform.position.x - 0.15f, transform.position.y + beamRange));
        yield return new WaitForSeconds(0.2f);
        lr.enabled = false;
        lr.SetPosition(1, transform.position);
        
    }

    /**
     * When you shoot, the doBeam() is called, and the cooldownTimer is reset.
     */
    public void OnClick() {
        if (gunCooldownTimer > gunCooldown && ammo > 0) {
            StartCoroutine(doBeam());
            shoot = false;
            gunCooldownTimer = 0;
        }
    }

    public void RefillAmmo() {
        ammo += ammoRefillAmount;
    }

}
