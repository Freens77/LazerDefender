	using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {
	public GameObject enemyPrefab;
	public float width = 10f; 
	public float height = 5f;
	public float speed = 5f;
	public bool movingRight = true;
	public float spawnDelay = 0.5f;
	private float minX, maxX;
	
	

	void Start () 
	{
		float distnaceToCamera = transform.position.z - Camera.main.transform.position.z;
		Vector3 leftBorder = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distnaceToCamera));
		Vector3 rightBorder = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, distnaceToCamera));
		minX = leftBorder.x;
		maxX = rightBorder.x;
		
		SpawnUntilFull();
	}
	
	
	
	public void OnDrawGizmos()
	{
		Gizmos.DrawWireCube(transform.position, new Vector3(width, height));
	}
	
	
	void Update () 
	
	{
		if(movingRight) 
		{
			transform.position += Vector3.right * speed * Time.deltaTime;
		} 
		else
		{
			transform.position += Vector3.left * speed * Time.deltaTime;
		}
		
		SetMovingRight();	
		
		if(AllMembersDead())
		{
			GameManager gm = FindObjectOfType<GameManager>();
			gm.AddBonusPoints(1);
			
			if(gm.CheckWavesRemaining())
			{
				SpawnUntilFull();
			}
			else 
			{
				FindObjectOfType<LevelManager>().LoadNextLevel();
			}	
		}
	}
	
		
	bool AllMembersDead()
	{
		foreach(Transform childGameObject in transform)
		{
			if(childGameObject.childCount > 0)
			{
				return false;
			}
		}
		
		return true;
	}
	
	
	
	void SpawnUntilFull()
	{
		Transform freePosition = NextFreePosition();
		if(freePosition)
		{
			GameObject enemy = (GameObject) Instantiate(enemyPrefab, freePosition.position, Quaternion.identity);
			enemy.transform.parent = freePosition;
		}
		
		if(NextFreePosition())
		{
			Invoke("SpawnUntilFull", spawnDelay);
		}
		
	}
	
	
	Transform NextFreePosition()
	{
		foreach(Transform childGameObject in transform)
		{
			if(childGameObject.childCount == 0)
			{
				return childGameObject;
			}
		}

		return null;
	}
	
	
	void SetMovingRight() {
		float rightEdgeOfFormation = transform.position.x + (width * 0.5f);
		float leftEdgeOfFormation = transform.position.x - (width * 0.5f);
		
		if(rightEdgeOfFormation >= maxX)		
		{
			movingRight = false;
		}
		else if(leftEdgeOfFormation <= minX)
		{
			movingRight = true;
		}
		
		
	}
	
	
}
