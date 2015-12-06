using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
	
	public static GameManager instance = null;
	private static LevelManager levelManager;
	
	
	//WAVE HANDLERS
	public int currentWave = 1;
	public int maxWaves = 5;
	
	//SCORE HANDLERS
	public int gameScore = 0;
	public int bonusPoints = 3;
	
	public bool isGameStarted = false;


	//WAVE HANDLER METHODS
	void SetNextWave()
	{
		currentWave++;	
	}
	
	public bool CheckWavesRemaining()
	{
		SetNextWave();
			
		if(currentWave > maxWaves)
		{
			return false;
		} 
		return true;
	}

	//GAMESCORE HANDLER METHODS
	public void AddScore(int addValue)
	{
		gameScore += addValue;
	}
	
	//BONUSSCORE HANDLER METHODS
	public void AddBonusPoints(int addValue)
	{
		bonusPoints += addValue;
	}
	
	
	
	public bool UseBonusPoints(int minusValue)
	{
		if(minusValue <= bonusPoints) 
		{
			bonusPoints -= minusValue;
			return true;
		}
		return false;
	}
	
	

	//SINGLETON PATTER FOR GAMEMANAGER OBJECT;
	void Awake () 
	{
		if(instance == null) 		{instance = this;}
		else if (instance != null) 	{Destroy(gameObject);}
		
		DontDestroyOnLoad(gameObject);
		
		
	}
	
	
	
}
