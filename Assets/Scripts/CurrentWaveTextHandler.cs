using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CurrentWaveTextHandler : MonoBehaviour {

	public Text currentWaveText;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		currentWaveText.text = FindObjectOfType<GameManager>().currentWave.ToString();
	
	}
}
