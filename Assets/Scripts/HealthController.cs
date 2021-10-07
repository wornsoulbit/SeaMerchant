using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthController : MonoBehaviour
{
    public int health = 100;

    public void updateHealth(int amount)
    {
        health += amount;
    }
}
