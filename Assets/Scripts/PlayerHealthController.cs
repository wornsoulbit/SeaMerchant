using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealthController : MonoBehaviour
{
	public int maxHealth = 100;
	public int currentHealth;
	public bool isDead = false;

	/*public HealthBar healthBar;*/

	// Start is called before the first frame update
	void Start()
	{
		currentHealth = maxHealth;
		/*healthBar.SetMaxHealth(maxHealth);*/
	}

	// Update is called once per frame
	void Update()
	{
		/*		if (Input.GetKeyDown(KeyCode.Space))
				{
					TakeDamage(20);
				}*/
		if(currentHealth == 0)
        {
			SceneManager.LoadScene("DeathScreen");
		}
	}

	public void TakeDamage(int damage)
	{
		currentHealth -= damage;
		if (currentHealth <= 0)
		{
			isDead = true;
		}
		/*healthBar.SetHealth(currentHealth);*/
	}

    private void OnTriggerEnter(Collider other)
    {
		if (other.gameObject.CompareTag("Water"))
		{
			currentHealth = 0;
			isDead = true;
		}
	}
}
