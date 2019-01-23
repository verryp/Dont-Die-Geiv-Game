using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {

	public GameObject currentCheckpoint;

	private Player player;

	public float respawnDelay;

	private Renderer rend;
	private PlayerHealth playerHealth;
	private DeathScreen deathScreen;


	// Use this for initialization
	void Start () {
		player = FindObjectOfType<Player> ();
		rend = player.GetComponent<Renderer> ();
		playerHealth = FindObjectOfType<PlayerHealth> ();
		deathScreen = FindObjectOfType<DeathScreen> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void RespawnPlayer(){
		StartCoroutine ("RespawnPlayerCo");
	}

	public IEnumerator RespawnPlayerCo()
	{
		player.enabled = false;
		rend.enabled = false;
		Debug.Log ("Player Respawn");
		yield return new WaitForSeconds (respawnDelay);
		player.transform.position = currentCheckpoint.transform.position;
		player.enabled = true;
		rend.enabled = true;
		deathScreen.isDead = false;
	}
}
