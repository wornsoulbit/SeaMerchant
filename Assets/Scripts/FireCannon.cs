using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireCannon : MonoBehaviour {
    [Header("General Options")]
    public GameObject cannonBallPrefab;
    [Space(1.0f)]
    public GameObject cannonBarrel;
    public GameObject cannonOutputNozzle;
    [Space(1.0f)]
    public GameObject cannonProjectiles;

    [Header("Firing Options")]
    public float defaultCannonFireForce = 15.0f;
    [Tooltip("If cannonFireForce is 20 and randVal is 5, then the cannonFireForce will be a range of 15 to 25.")]
    public int firingInaccuracyValue = 5;
    [Space(10)]
    [Range(0, 2)]
    public float startDelay = 1;
    public float firingInterval = 1.5f;
    
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
        GameObject cannonBall = Instantiate(cannonBallPrefab, cannonOutputNozzle.transform.position, cannonBallPrefab.transform.rotation);

        cannonBall.transform.SetParent(cannonProjectiles.transform, false); //Stores the cannonball gameobject without changing its transform.
        Rigidbody cannonBallRigidbody = cannonBall.GetComponent<Rigidbody>();

        float randCannonFireForce = SetRandomFiringForce(defaultCannonFireForce);
        cannonBallRigidbody.AddForce(cannonBarrel.transform.forward * randCannonFireForce, ForceMode.Impulse);
        Debug.Log("Cannon fired!\n Randomized Firing Force: " + randCannonFireForce, gameObject);
    }

    private float SetRandomFiringForce(float originalFiringForce) {
        float newFiringForce = Random.Range(originalFiringForce - firingInaccuracyValue, originalFiringForce + firingInaccuracyValue);

        return newFiringForce;
    }
}
