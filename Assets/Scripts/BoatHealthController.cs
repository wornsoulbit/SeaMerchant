using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoatHealthController : MonoBehaviour
{
	private int maxHealth = 100;
	private int currentHealth = 80;
	private bool isDead = false;
	//public GameObject healthBar;

	public HealthBar healthBar;

	// Start is called before the first frame update
	void Start()
	{
	}

	// Update is called once per frame
	void Update()
	{
		/*		if (Input.GetKeyDown(KeyCode.Space))
				{
					TakeDamage(20);
				}*/

	}

	public void TakeDamage(int damage)
	{
		currentHealth -= damage;
		if (currentHealth <= 0)
        {
			isDead = true;
        }
		healthBar.GetComponent<Slider>().value = (float)currentHealth;

	}

	public bool Repair()
    {
		if(currentHealth < maxHealth)
        {
			currentHealth += 5;
			healthBar.GetComponent<Slider>().value = (float)currentHealth;
			return true;
		}
		else
        {
			return false;
        }

	}

}
