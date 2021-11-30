using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PirateRadius3 : MonoBehaviour {
    [Header("General options: ")]
    [SerializeField]
    private GameObject radiusTarget;

    private PirateController pirateController;

    private void Start() {
        pirateController = this.GetComponentInParent<PirateController>();
        radiusTarget = pirateController.GetTarget();
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Player")) {
            Debug.Log("Pirate in range to ATTACK player.", radiusTarget);
            pirateController.ResetAttackCooldown();
        }
    }

    private void OnTriggerStay(Collider other) {
        if (other.gameObject.CompareTag("Player")) {
            //Trigger event
                //Attack Player
            pirateController.Attack();

            //PSEUDO CODE of Attack Player:
            //if (attackTimer < 0) {
            //    HitPlayer();
            //    attackTimer = ATTACK_COOLDOWN;
            //}
            //else {
            //    attackTimer -= Time.deltaTime;
            //}
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.gameObject.CompareTag("Player")) {
            Debug.Log("Pirate NOT in range ATTACK player.", radiusTarget);
        }
    }
}
