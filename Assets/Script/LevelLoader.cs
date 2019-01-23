using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelLoader : MonoBehaviour {

	private bool playerInStages;
	public string levelToLoad; // Nama buat next stage

	// Use this for initialization
	void Start () {
		playerInStages = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (playerInStages) {
			Application.LoadLevel (levelToLoad);
		}
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.name == "Player") {
			playerInStages = true;
		}
	}

	void OnTringgerExit2D(Collider2D other){
		if (other.name == "Player")
			playerInStages = false;
	}
}
