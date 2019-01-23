using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyMove : MonoBehaviour {

    public float EnemySpeed;
    public int XMoveDirection;
	private bool faceRigthEnemy = true;

	public LevelManager levelManager;

	// Use this for initialization
	void Start () {
		levelManager = FindObjectOfType<LevelManager> ();
	}

	// Update is called once per frame
	void Update () {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, new Vector2(XMoveDirection, 0));
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(XMoveDirection, 0) * EnemySpeed; 
/*
        if(hit.distance < 0.33f){
            Flip();
			if (hit.collider.tag == "Player") {
				levelManager.RespawnPlayer ();
			}
        }*/
	}

    void Flip() {
		if (XMoveDirection > 0 && faceRigthEnemy == false)
        {
			FlipEnemy ();
            XMoveDirection = -1;
        }
        else {
			FlipEnemy ();
            XMoveDirection = 1;
        }
    }

	void FlipEnemy(){
		faceRigthEnemy = !faceRigthEnemy;
		Vector2 localScale = gameObject.transform.localScale;
		localScale.x *= -1;
		transform.localScale = localScale;
	}
}
