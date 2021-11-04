using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeController : MonoBehaviour
{
    private int health;
    // Start is called before the first frame update
    void Start()
    {
        health = 3;
    }

    public void hammerHit()
    {
        health--;
        if (health <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
