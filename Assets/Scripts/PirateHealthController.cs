using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PirateHealthController : MonoBehaviour
{
    public int maxHealth = 100;
	public int currentHealth;

	void Start()
	{
		currentHealth = maxHealth;
	}

	public void TakeDamage(int damage)
	{
		currentHealth -= damage;
		if (currentHealth <= 0)
		{
			Destroy(this.gameObject);
		}
	}
}
