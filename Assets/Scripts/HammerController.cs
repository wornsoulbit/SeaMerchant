using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HammerController : MonoBehaviour {
    public Camera camera;
    public float rayDistance = 3f;

    public int dmg = -15;

    void Update() {
        HitObject();
    }

    private GameObject HitObject() {
        Ray ray = new Ray(camera.transform.position, camera.transform.forward);
        RaycastHit hitInfo;

        if (Physics.Raycast(ray, out hitInfo, rayDistance))
        {
            Debug.DrawLine(ray.origin, hitInfo.point, Color.red);
            if (Input.GetMouseButtonDown(0)) { //If left mouse button is pressed
                Debug.Log("Object hit: " + hitInfo.collider.gameObject.name);
                if (hitInfo.collider.gameObject.CompareTag("Tree")) {
                    //Change tree into chopped tree trunk.
                    //Add wood to player's resources.
                }
                if (hitInfo.collider.gameObject.CompareTag("Boat")) {
                    //Remove wood from player's resources.
                    //Increase boat health.
                }
                if (hitInfo.collider.gameObject.CompareTag("Pirate")) {
                    //Reduce pirate HP. (Pirates require 2 hits to eliminate)
                    hitInfo.collider.gameObject.GetComponent<HealthController>().updateHealth(dmg);
                }
                return hitInfo.collider.gameObject;
            }
        }
        else {
            Debug.DrawLine(ray.origin, ray.origin + ray.direction * rayDistance, Color.green);
        }

        return null;
    }

    //Create methods

}
