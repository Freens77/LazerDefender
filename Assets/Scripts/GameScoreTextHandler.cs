using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameScoreTextHandler : MonoBehaviour {

	public Text gameScoreText;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		gameScoreText.text = FindObjectOfType<GameManager>().gameScore.ToString();
	}
}
