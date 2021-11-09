using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetection : MonoBehaviour
{

    public GameObject boat;
    public int dmg = 20;
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
            boat.GetComponent<BoatHealthController>().TakeDamage(dmg);
            hitCount += 3;
            // particle effect should be here
            Destroy(other.gameObject);
        }
    }

    public int Repair()
    {
        return hitCount--;
    }
}
