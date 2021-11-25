using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PirateController : MonoBehaviour
{
    private GameObject target;
    private PlayerHealthController playerHealthController;
    private const int PIRATE_ATTACK_DAMAGE = 20;
    //public bool isChasingTarget;
    //public bool isAwareOfTarget;
    // Start is called before the first frame update

    private NavMeshAgent agent;
    public PirateAnimationBehavior pirateAnimation;
    [SerializeField]
    private float t;
    
    void Awake() {
        agent = GetComponent<NavMeshAgent>();
        //isChasingTarget = false;
        //isAwareOfTarget = false;
        ResetAttackCooldown();
    }
    
    private void Start() {
        pirateAnimation.SetupBehaviour();    
    }

    //GETTER
    public GameObject GetTarget() {
        return target;
    }

    //SETTER
    public void SetTarget(GameObject target) {
        this.target = target;
        
        if (target != null) {
            playerHealthController = target.GetComponent<PlayerHealthController>();
        } else {
            playerHealthController = null;
        }
    }
    
    public void MovePirate() {
        if (!agent.isStopped) {
            pirateAnimation.UpdateMovementAnimation(agent.desiredVelocity.magnitude);
            Debug.Log("MOVING_1");
        } else {
            pirateAnimation.UpdateMovementAnimation(0);
            Debug.Log("MOVING_2");
        }
    }
    
    public void StopPirate() {
        if (agent.velocity.magnitude <= 1f) {
            pirateAnimation.UpdateMovementAnimation(0);
        }
    }

    private int cooldown; //"cooldown" set to "COOLDOWN_THRESHOLD" in "Awake()".
    private const int COOLDOWN_THRESHOLD = 40;
    private const int DAMAGING_FRAME = COOLDOWN_THRESHOLD / 4 * 3; //This will give half of COOLDOWN_THRESHOLD
    public void Attack() {
        if (target != null && target.CompareTag("Player")) {
            if (!playerHealthController.isDead) { //if player is not dead.
                if (cooldown == COOLDOWN_THRESHOLD) {
                    pirateAnimation.PlayAttackAnimation();
                }
                
                if (cooldown == DAMAGING_FRAME) {
                    playerHealthController.TakeDamage(PIRATE_ATTACK_DAMAGE);
                }

                if (cooldown >= 0) {
                    cooldown--;
                }
                else {
                    ResetAttackCooldown(); //Restart the cooldown.
                }
            }
            else {
                StopPirate();
                //Play pirate dancing animation. Or Pirate laughing animation. Or Pirate cackle animation.
            }
        }
    }

    public void ResetAttackCooldown() {
        cooldown = COOLDOWN_THRESHOLD; //Restart the cooldown.
    }
        
    public void SetTargetDirection(Collider other) {
        if (!agent.destination.Equals(other.gameObject.transform.position))
            agent.SetDestination(other.transform.position);
    }
    
}