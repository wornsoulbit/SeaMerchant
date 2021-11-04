using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HammerController : MonoBehaviour {
    public Camera camera;
    public float rayDistance = 3f;
    private int supply;
    private int maxSupply;
    public GameObject supplyText;

    public int dmg = 15;

    private void Start()
    {
        supply = 20;
        maxSupply = 60;
    }

    void Update() {
        HitObject();
        supplyText.GetComponent<Text>().text = $"{supply} / {maxSupply}";
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
                    hitInfo.collider.gameObject.GetComponent<TreeController>().hammerHit();
                    hitTree();
                    //Debug.Log("hitting something");

                }
                if (hitInfo.collider.gameObject.CompareTag("Boat")) {
                    //Remove wood from player's resources.
                    //Increase boat health.
                    //Debug.Log("hitting something");
                    bool successful = hitInfo.collider.gameObject.GetComponent<BoatHealthController>().Repair();

                    if(successful)
                    {
                        useSupplyForRepair();
                    }
                }
                if (hitInfo.collider.gameObject.CompareTag("Pirate")) {
                    //Reduce pirate HP. (Pirates require 2 hits to eliminate)
                    //NOTE: Change to pirate later on
                    //hitInfo.collider.gameObject.GetComponent<BoatHealthController>().TakeDamage(dmg);
                    //Debug.Log("hitting something");

                }
                return hitInfo.collider.gameObject;
            }
        }
        else {
            Debug.DrawLine(ray.origin, ray.origin + ray.direction * rayDistance, Color.green);
        }
        return null;
    }

    void hitTree()
    {
        if(supply < maxSupply)
        {
            supply += 2;
            //Debug.Log(supply);
            supplyText.GetComponent<Text>().text = supply.ToString();
        }
    }

    void useSupplyForRepair()
    {
        supply -= 5;
        supplyText.GetComponent<Text>().text = supply.ToString();
    }

    //Create methods

}
