using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

	public int damageToGive;
	private LevelManager levelManager;

    void Start()
    {
        levelManager = FindObjectOfType<LevelManager>();
    }

    void Update ()
    {
		
	}

    private void OnTriggerEnter2D(Collider2D col)
    {   
        if(col.isTrigger != true)
        {
            if(col.CompareTag("Player"))
            {
				PlayerHealth.HurtPlayer (damageToGive);
                levelManager.RespawnPlayer();
            }
            Destroy(gameObject);
        }
    }
}
