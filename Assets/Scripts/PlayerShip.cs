using UnityEngine;
using System.Collections;

public class PlayerShip : MonoBehaviour {
	
	public float speed = 12.0f;
	
	public GameObject projectile;
	public float projectileShotSpeed = 7f;
	float projectileFirerate = 0.2f;
	
	public float hitPoints = 1000f;
	public float maxHitPoints = 1000f;
	public float hitPointsPercentage;
	
	//power ups
	public bool powerUp1Available = true;
	public int powerUpCoolDown = 10;
	public float powerUpUsedTime;


	public AudioClip playerShootingSound;
	GameManager gm;
	
	float minX;
	float maxX;
	float paddingX = 0.5f;
	
	
	void OnTriggerEnter2D(Collider2D col)
	{
		Projectile projectileLazer = col.gameObject.GetComponent<Projectile>();
		
		if(projectileLazer)
		{
			Destroy(col.gameObject);
			TakeDamage(projectileLazer.damage);
		}
	}



	//Manage Hit Points
	void TakeDamage(float damage)
	{
		hitPoints -= damage;
		
	}
	
	void CheckRemainingHP()
	{
		if(hitPoints <= 0f)	{Destroy(gameObject);}
	}


	void SetHitPointsPercentage()
	{
		hitPointsPercentage = hitPoints / maxHitPoints;
	}
	
	
	//Manage PowerUp - Under Construction
	void ResetPowerUpAvailable()
	{
		powerUp1Available = true;
	}
	
	
	void UsePowerUp()
	{
		if(gm.UseBonusPoints(2))
		{
			ResetHealth();
			powerUpUsedTime = Time.time;
			powerUp1Available = false;
		}
		
	}
	
	void CheckPowerUpCooldownTime()
	{
		if(Time.time - powerUpUsedTime >= powerUpCoolDown)
		{
			ResetPowerUpAvailable();
		}
		
	}
	


	void Start () 
	{
		float distance = transform.position.z - Camera.main.transform.position.z;
		Vector3 leftmostPos = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distance));
		Vector3 rightmostPos = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, distance));
		minX = leftmostPos.x + paddingX;
		maxX = rightmostPos.x - paddingX;
		gm = FindObjectOfType<GameManager>();
	}
		
		
	void FireProjectile()
	{
		Vector3 startPosition = transform.position + new Vector3(0, 1, 0);
		GameObject projectileShot = (GameObject)Instantiate(projectile, startPosition, Quaternion.identity);
		projectileShot.GetComponent<Rigidbody2D>().velocity = new Vector3(0,projectileShotSpeed);
		AudioSource.PlayClipAtPoint(this.playerShootingSound, gameObject.transform.position);
	}
	
	void ResetHealth()
	{
		hitPoints = maxHitPoints;
	}


	
	void Update () {
	
		if(Input.GetKeyDown (KeyCode.Space))
		{
			InvokeRepeating("FireProjectile", 0.0001f, projectileFirerate); 
		}
		else if(Input.GetKeyUp (KeyCode.Space))
		{
			CancelInvoke("FireProjectile");
		}
		
		if(Input.GetKey(KeyCode.LeftArrow)) 
		{
			transform.position += Vector3.left * speed * Time.deltaTime;
		} 
		else if(Input.GetKey(KeyCode.RightArrow)) 
		{
			transform.position += Vector3.right * speed * Time.deltaTime;
		}
		
		if(Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Keypad1))
		{
			if(powerUp1Available == true)	{UsePowerUp();}
		}
	
		float newX = Mathf.Clamp(transform.position.x, minX, maxX);
		transform.position = new Vector3(newX, transform.position.y, transform.position.z);
		
		SetHitPointsPercentage();
		CheckRemainingHP();
		CheckPowerUpCooldownTime();
	
	}
	
	
	
	
}
