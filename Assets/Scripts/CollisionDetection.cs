using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetection : MonoBehaviour
{

    public GameObject boat;
    public bool isDamaged = false;
    public int dmg = 20;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("CannonBall"))
        {
            isDamaged = true;

            boat.GetComponent<BoatHealthController>().TakeDamage(dmg);
            // particle effect should be here
            Destroy(other.gameObject);
        }
    }
}
