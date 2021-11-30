using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PirateRadius2 : MonoBehaviour {
    [Header("General options: ")] [SerializeField]
    private GameObject radiusTarget;

    private PirateController pirateController;
    //private bool isChasingTargetPlayer;
    //private bool isAwareOfTargetPlayer;
    
    private void Start() {
        pirateController = this.GetComponentInParent<PirateController>();
        //isChasingTargetPlayer = pirateController.isChasingTarget;
        //isAwareOfTargetPlayer = pirateController.isAwareOfTarget;
        radiusTarget = pirateController.GetTarget();
        //isAwareOfTargetPlayer = false;
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Player")) {
            radiusTarget = other.gameObject;
            pirateController.SetTarget(radiusTarget);
            //isChasingTargetPlayer = true;
            Debug.Log("Pirate MOVING towards player with NavMesh.", radiusTarget);
        }
    }

    private void OnTriggerStay(Collider other) {
        if (other.gameObject.CompareTag("Player")) {
            pirateController.SetTargetDirection(other);
            pirateController.MovePirate();
            //Trigger event
            //Get position of target. (This will be used as the destination of the nav mesh agent.)
            //Move towards destination
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.gameObject.CompareTag("Player")) {
            radiusTarget = null;
            pirateController.SetTarget(radiusTarget);
            Debug.Log("Pirate NOT MOVING towards player with NavMesh.", radiusTarget);
        }
    }
    
    private void Update() {
        pirateController.StopPirate();
    }
}
