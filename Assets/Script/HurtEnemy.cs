using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtEnemy : MonoBehaviour {

	public int damageToGive;

	public float bounceOnEnemy;

	private Rigidbody2D myrigidbody2D;

	// Use this for initialization
	void Start () {
		myrigidbody2D = transform.parent.GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D col) {
		if (col.CompareTag("Enemy")) {
			col.GetComponent<EnemyHealthManager> ().giveDamage(damageToGive);

			myrigidbody2D.velocity = new Vector2 (myrigidbody2D.velocity.x, bounceOnEnemy); //kalo bunuh musuh, si geiv loncat
		}

		if (col.CompareTag ("Boss")) {
			col.GetComponent<BossHealthManager>().giveDamage(damageToGive);
		}
	}
}
