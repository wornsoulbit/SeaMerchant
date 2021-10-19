using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonController : MonoBehaviour {
    [Header("General options: ")]
    public Transform target;
    
    
    [Space(3)]
    
    [Header("Smoothing options: ")] [Tooltip("Enables rotational smoothing with linear interpolation.")]
    public bool enableSmoothing = true; //Enables LERP(Linear Interpolation) smoothing.
    [Range(1.0f, 10.0f)] [Tooltip("EnableSmoothing must be activated for the speed to take effect.")]
    public float speed = 5f;
    
    [Header("Miscellaneous options: ")]
    [Tooltip("Enabling this makes the cannon immobile.")]
    public bool disableTargetting = false;
    [Tooltip("Enabling this will make the cannon rotate on all axises instead of just the y axis.")]
    public bool disableRotationalConstraint = false;
    
    private void OnTriggerStay(Collider other) {
        if (other.gameObject.CompareTag("Player") && !disableTargetting && !disableRotationalConstraint) {
            Vector3 direction = target.position - transform.position;
            Quaternion rotation = Quaternion.LookRotation(direction);
            rotation = Quaternion.Euler(transform.eulerAngles.x, rotation.eulerAngles.y, transform.eulerAngles.z);
            if (!enableSmoothing) //If smoothing is disabled
                transform.rotation = rotation;
            else //If smooting is enabled
                transform.rotation = Quaternion.Lerp(transform.rotation, rotation, speed * Time.deltaTime);
        }
    }
}
