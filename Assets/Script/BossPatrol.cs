using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossPatrol : MonoBehaviour {

	/*public float moveSpeed;
	public bool moveRight;

	public Transform wallCheck;
	public float wallCheckRadius;
	public LayerMask whatIsWall;
	private bool hittingWall;

	private bool notAtEdge;
	public Transform edgeCheck;

	private Rigidbody2D myRigidbody2D;

	private float ySize;

	// Use this for initialization
	void Start () {
		myRigidbody2D = GetComponent<Rigidbody2D> ();

		ySize = transform.localScale.y;
	}
	
	// Update is called once per frame
	void Update () {
		hittingWall = Physics2D.OverlapCircle (wallCheck.position, wallCheckRadius, whatIsWall);

		notAtEdge = Physics2D.OverlapCircle (edgeCheck.position, wallCheckRadius, whatIsWall);

		if (hittingWall || !notAtEdge)
			moveRight = !moveRight;

		if (moveRight) {
			transform.localScale = new Vector3 (-ySize, transform.localScale.y, transform.localScale.z);
			myRigidbody2D.velocity = new Vector2 (moveSpeed, myRigidbody2D.velocity.y);
		} else {
			transform.localScale = new Vector3 (ySize, transform.localScale.y, transform.localScale.z);
			myRigidbody2D.velocity = new Vector2 (-moveSpeed, myRigidbody2D.velocity.y);
		}
	}*/

	public float EnemySpeed;
	private bool facingRight;
	private float moveX;
	public int XMoveDirection;

	public LevelManager levelManager;

	private Rigidbody2D myRigidbody2D;

	private float ySize;

	// Use this for initialization
	void Start () {
		levelManager = FindObjectOfType<LevelManager> ();

		myRigidbody2D = GetComponent<Rigidbody2D> ();

		ySize = transform.localScale.y;
	}



	// Update is called once per frame
	void Update () {
		RaycastHit2D hit = Physics2D.Raycast(transform.position, new Vector2(XMoveDirection, 0));
		gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(XMoveDirection, 0) * EnemySpeed; 

		moveX = Input.GetAxis("Horizontal");

		if(hit.distance < 2.33f){
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
			transform.localScale = new Vector3 (ySize, transform.localScale.y, transform.localScale.z);
			myRigidbody2D.velocity = new Vector2 (-EnemySpeed, myRigidbody2D.velocity.y);
			XMoveDirection = -2;
			FlipEnemy ();
		}
		else {
			transform.localScale = new Vector3 (-ySize, transform.localScale.y, transform.localScale.z);
			myRigidbody2D.velocity = new Vector2 (EnemySpeed, myRigidbody2D.velocity.y);
			XMoveDirection = 2;
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
