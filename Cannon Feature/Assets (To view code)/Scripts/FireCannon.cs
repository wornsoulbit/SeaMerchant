using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireCannon : MonoBehaviour {
    private float startDelay = 1;
    private float firingInterval = 1.5f;
    
    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Player")) {
            InvokeRepeating("Fire", startDelay, firingInterval);
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.gameObject.CompareTag("Player")) {
            CancelInvoke("Fire");
        }
    }

    private void Fire() {
        Debug.Log("Cannon fired!");
    }
}
