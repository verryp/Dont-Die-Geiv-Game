using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthManager : MonoBehaviour {

	public int enemyHealth;
	//public GameObject deathEffect;
	//public int pointsOnDeath;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		//bunuh musuh
		if (enemyHealth <= 0) {
			//Instantiate (deathEffect, transform.position, transform.rotation);
			//blabla.AddPoints(pointsOnDeath); //Nambah point kalo mau pake tembakan
			Destroy (gameObject);
			Debug.Log ("Tes");
		}
	}

	public void giveDamage(int damageToGive){
		enemyHealth = damageToGive - enemyHealth;
	}
}
