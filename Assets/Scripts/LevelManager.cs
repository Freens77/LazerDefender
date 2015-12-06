using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

	public void LoadLevel(string levelName) 
	{
		Application.LoadLevel(levelName);
	}
	
	public void QuitGame() 
	{
		Application.Quit();
        
	}
	
	public void LoadNextLevel()
	{
		Application.LoadLevel(Application.loadedLevel + 1);	
	
	}
	
	
}
