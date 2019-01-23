using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {

	//public int startingLives;
	public int maxPlayerHealth;
	public static int playerHealth;
	//public bool isDead;

	Text text;

	private LevelManager levelManager;
	//public GameObject gameDeathScreen;
	//public Player player;
	//public float waitAfterDeathScreen;
	//private float tempTimeDelayDS;
	//private LifeManger lifeSystem;

	// Use this for initialization
	void Start () {
		text = GetComponent<Text> ();
		playerHealth = PlayerPrefs.GetInt ("PlayerCurrentLives");

		levelManager = FindObjectOfType<LevelManager> ();
		//player = FindObjectOfType<Player> ();

		//lifeSystem = FindObjectOfType<LifeManger> ();

		//isDead = false;
		//tempTimeDelayDS = waitAfterDeathScreen;
		//gameDeathScreen.SetActive (false);

	}


	// Update is called once per frame
	void Update () {
		/*if (playerHealth <= 0) {
			//playerHealth = 1;
			levelManager.RespawnPlayer ();
			//lifeSystem.TakeLife ();
			//isDead = false;
		}*/

		/*if (isDead == true) {
			gameDeathScreen.SetActive (true);
			player.gameObject.SetActive (false);
		}

		if(gameDeathScreen.activeSelf){
			tempTimeDelayDS -= Time.deltaTime;
		}

		if (tempTimeDelayDS < 0) {
			gameDeathScreen.SetActive (false);
			player.gameObject.SetActive (true);
			tempTimeDelayDS = waitAfterDeathScreen;
		}*/
		text.text = "X " + playerHealth;
		PlayerPrefs.SetInt ("PlayerCurrentLives", playerHealth);
	}

	public static void HurtPlayer(int damageToGive){
		playerHealth -= damageToGive;
		//PlayerPrefs.SetInt ("PlayerCurrentLives", playerHealth);
	}

	public void FullHealth()
	{
		playerHealth = maxPlayerHealth;
	}
}
 