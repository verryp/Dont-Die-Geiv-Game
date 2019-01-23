using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyMove : MonoBehaviour {

    public float EnemySpeed;
	private bool facingRight;
	private float moveX;
    public int XMoveDirection;

	public LevelManager levelManager;

	// Use this for initialization
	void Start () {
		levelManager = FindObjectOfType<LevelManager> ();

        
	}



	// Update is called once per frame
	void Update () {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, new Vector2(XMoveDirection, 0));
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(XMoveDirection, 0) * EnemySpeed; 

		moveX = Input.GetAxis("Horizontal");

        if(hit.distance < 0.33f){
            Flip();
			//FlipEnemy ();
			if (hit.collider!=null && hit.collider.tag=="Player") {
				levelManager.RespawnPlayer ();
			}
        }
	}

    void Flip() {
		if (XMoveDirection > 0 && facingRight == false)
        {
            XMoveDirection = -1;
			FlipEnemy ();
        }
        else {
            XMoveDirection = 1;
			FlipEnemy ();
        }
    }

	void FlipEnemy()
	{
		facingRight = facingRight;
		Vector2 localScale = gameObject.transform.localScale;
		localScale.x *= -1;
		transform.localScale = localScale;
	}
}
