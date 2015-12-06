using UnityEngine;
using System.Collections;

public class EnemyBehavior : MonoBehaviour {
	
	public GameObject projectile;
	public float projectileShotSpeed = 7f;
	public float projectileShotsPerSecond = 1.25f;

	public float hitPoints = 500f;
	public float maxHitPoints = 1000f;
	public float hitPointsPercentage;
	
	public AudioClip enemyShootingSound;


	void OnTriggerEnter2D(Collider2D col)
	{
		Projectile projectileLazer = col.gameObject.GetComponent<Projectile>();
		if(projectileLazer)	
		{
			Destroy(col.gameObject);
			TakeDamage(projectileLazer.damage);
		}
	}

				
	void Update() 
	{
		float probability = Time.deltaTime * projectileShotsPerSecond;
		if(Random.value < probability) 
		{
			FireProjectile();
		}
	}


	void FireProjectile()
	{
		Vector3 startPosition = transform.position + new Vector3(0, -1, 0);
		GameObject projectileShot = (GameObject)Instantiate(projectile, startPosition, Quaternion.identity);
		projectileShot.GetComponent<Rigidbody2D>().velocity = new Vector3(0,-projectileShotSpeed);
		AudioSource.PlayClipAtPoint(enemyShootingSound, gameObject.transform.position);
	}

	
	void TakeDamage(float damage)
	{
		hitPoints -= damage;
		CheckRemainingHP();
	}

		
	void CheckRemainingHP()
	{
		if(hitPoints <= 0f)
		{
		
			FindObjectOfType<GameManager>().AddScore(10);
			Destroy(gameObject);
		}
	}

		
	void SetHitPointsPercentage()
	{
		hitPointsPercentage = hitPoints / maxHitPoints;
	}
	

}
