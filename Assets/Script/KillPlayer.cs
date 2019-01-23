using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlayer : MonoBehaviour {

	public int damageToGive;

	private LevelManager levelManager;
    private Rigidbody2D rb2d;
    private Animator anim;

	private DeathScreen deathScreen;
	private PlayerHealth playerHealth;



    // Use this for initialization
    void Start () {
		levelManager = FindObjectOfType<LevelManager> ();
        anim = gameObject.GetComponent<Animator>();
        rb2d = gameObject.GetComponent<Rigidbody2D>();
		playerHealth = FindObjectOfType<PlayerHealth> ();
		deathScreen = FindObjectOfType<DeathScreen> ();
    }
	
	// Update is called once per frame
	void Update () {
       
	}
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag=="Player" && !deathScreen.isDead)
        {
            levelManager.RespawnPlayer();
            PlayerHealth.HurtPlayer(damageToGive);
            deathScreen.isDead = true;
        }
    }
    void OnTriggerEnter2D(Collider2D other){
		if (other.name == "Player" && !deathScreen.isDead) {
            levelManager.RespawnPlayer ();
			PlayerHealth.HurtPlayer (damageToGive);
			deathScreen.isDead = true;
		}
	}
}
