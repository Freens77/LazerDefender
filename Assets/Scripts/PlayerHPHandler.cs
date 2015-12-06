using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerHPHandler : MonoBehaviour {

	public Text playerHP_Text;
	


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		float playerHP = FindObjectOfType<PlayerShip>().hitPointsPercentage;
		
		playerHP_Text.text = (playerHP * 100).ToString() + "%";
		
		float green = playerHP;
		float red = 1 - playerHP;
		playerHP_Text.color = new Color(red, green, 0);
	}
}
