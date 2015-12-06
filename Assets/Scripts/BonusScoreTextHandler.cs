using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BonusScoreTextHandler : MonoBehaviour {

	public Text bonusScoreText;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		bonusScoreText.text = FindObjectOfType<GameManager>().bonusPoints.ToString();
	}
}
