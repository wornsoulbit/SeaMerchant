using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBridge : MonoBehaviour
{
    public GameObject bridge;
    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.CompareTag("OnBoatChecker")){
            Destroy(bridge);
        }
    }
}
