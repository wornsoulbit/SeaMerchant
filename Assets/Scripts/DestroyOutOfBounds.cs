using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour {
    public int yAxisThreshold = -10;

    void Update() {
        if (gameObject.transform.position.y < yAxisThreshold) {
            Destroy(gameObject);
        }
    }
}
