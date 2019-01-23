using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingSpikes : MonoBehaviour {
    private Player player;
    public bool check;
    public float popBefore;
    public float delay;

    public Rigidbody2D rb2;
    public LevelManager levelManager;
    // Use this for initialization
    void Start () {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        levelManager = FindObjectOfType<LevelManager>();
        rb2 = GetComponent<Rigidbody2D>();
        check = true;
    }
	
	// Update is called once per frame
	void Update () {

        print("Player"+player.transform.position.x);

        if (player.transform.position.x >= transform.position.x)
        {
            rb2.isKinematic = false;
            rb2.gravityScale = 5;
            check = true;
            print("Spikes"+transform.position.x);
        }
       
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            print("Kena Dehhh");
            check = true;
            transform.position = new Vector2(transform.position.x, popBefore);
            levelManager.RespawnPlayer();
        }
    }
  
}
