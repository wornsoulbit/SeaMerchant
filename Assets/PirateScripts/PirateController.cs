using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PirateController : MonoBehaviour
{
    // float heigh = 4f;
    public bool OnBoat = false;
    private GameObject target;
    public Transform target2;
    public GameObject boatJumpTarget;
    public float speed = 4f;
    Rigidbody rig;
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
        rig = GetComponent<Rigidbody>();
        target2 = GameObject.FindGameObjectWithTag("Player").transform;
        boatJumpTarget = GameObject.FindGameObjectWithTag("PirateJumpPoint");
    }

    private void Update() {
        bool Jumping = false;
        if(!OnBoat){
            float distance = Vector3.Distance(this.gameObject.transform.position, boatJumpTarget.transform.position);
            Debug.Log(distance);
            if(distance <= 55){
                // ParabolicMove(this.gameObject.transform, this.gameObject.transform.position, boatJumpTarget.transform.position, 15f);
                Jumping = true;
            }
            if(Jumping){
                Vector3 pos = Vector3.MoveTowards(transform.position, boatJumpTarget.transform.position, (speed*20) * Time.fixedDeltaTime);
                rig.MovePosition(pos);
                transform.LookAt(target2);
                transform.eulerAngles = new Vector3(0,transform.eulerAngles.y,0);
            }
        }
        else{
            Jumping = false;
        }
    }

    // public void ParabolicMove(Transform target, Vector3 a, Vector3 b, float time)
    //  {
    //      float target_X = a.x + (b.x - a.x) * time;
    //      float maxHeigh = (a.y + b.y) / 2 + heigh;
    //      float target_Y = a.y + ((b.y - a.y)) * time + heigh * (1-(Mathf.Abs(0.5f - time) / 0.5f) * (Mathf.Abs(0.5f - time) / 0.5f));
    //      target.position = new Vector3(target_X, target_Y);
    //  }

    private void FixedUpdate() {
        if(OnBoat){
            Vector3 pos = Vector3.MoveTowards(transform.position, target2.position, speed * Time.fixedDeltaTime);
            rig.MovePosition(pos);
            transform.LookAt(target2);
            transform.eulerAngles = new Vector3(0,transform.eulerAngles.y,0);
        }
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
        if(!OnBoat){
            if (!agent.isStopped) {
                pirateAnimation.UpdateMovementAnimation(agent.desiredVelocity.magnitude);
                Debug.Log("MOVING_1");
            } else {
                pirateAnimation.UpdateMovementAnimation(0);
                Debug.Log("MOVING_2");
            }
        }
    }
    
    public void StopPirate() {
        if (agent.velocity.magnitude <= 1f) {
            pirateAnimation.UpdateMovementAnimation(0);
        }
    }

    private int cooldown; //"cooldown" set to "COOLDOWN_THRESHOLD" in "Awake()".
    private const int COOLDOWN_THRESHOLD = 60;
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