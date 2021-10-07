using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBallCollisions : MonoBehaviour {
    void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Boat")) {// To handle what happens when a boat is hit by a cannonball
            Debug.LogWarning("BLAST! (CannonBall exploded on Boat) [Target name: " + other.gameObject.name + "] [Replace later with real blast]"); //Note: CannonBall is destroyed on contact
            //TODO: Create an Explosion/Blast effect at cannonball's position.
            Destroy(gameObject);//Destroy this cannonball
            //TODO: Reduce the boat's durability (HP).
        }
        else if (other.gameObject.CompareTag("Player")) {//To handle what happens when the player is hit by a cannonball
            Debug.LogError("BLAM!!! (CannonBall violently collided with Player) [Target name: " + other.gameObject.name + "] [Replace later]");
            //TODO: Create an Explosion/Blast effect at cannonball's position.
            Destroy(gameObject);
            //TODO: Handle the consequences the collision will have on the player.
        }
    }
}
