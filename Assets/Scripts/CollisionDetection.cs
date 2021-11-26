using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetection : MonoBehaviour
{

    public GameObject boat;
    public int cannonDmg = 20;
    public int environmentDmg = 10;
    public int hitCount;

    private void Start()
    {
        hitCount = 0;
    }

    private void Update()
    {
        if (hitCount > 0) {
            //generate particles.
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("CannonBall"))
        {
            boat.GetComponent<BoatHealthController>().TakeDamage(cannonDmg);
            hitCount += 3;
            // particle effect should be here
            Destroy(other.gameObject);
        }
        if(other.gameObject.layer == LayerMask.NameToLayer("Ground")){
            boat.GetComponent<BoatHealthController>().TakeDamage(environmentDmg);
            hitCount += 3;
        }
    }

    public int Repair()
    {
        return hitCount--;
    }
}
