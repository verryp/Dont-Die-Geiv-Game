using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathScreen : MonoBehaviour {

	public float waitAfterDeathScreen;
	private float tempTimeDelayDS;
	public GameObject gameDeathScreen;
	public bool isDead;
	public Player player;
	// Use this for initialization
	void Start () {
		isDead = false;
		tempTimeDelayDS = waitAfterDeathScreen;
		gameDeathScreen.SetActive (false);
		player = FindObjectOfType<Player> ();
	}

	// Update is called once per frame
	void Update () {
		if (isDead == true) {
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
		}
	}
}
