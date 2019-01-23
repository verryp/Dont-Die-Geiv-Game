using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopOutSpikes : MonoBehaviour {
    private Player player;
    public bool check;
    public float popBefore;
	public float popAfter;
    public float delay;

	public LevelManager levelManager;
    // Use this for initialization
    void Start () {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
		levelManager = FindObjectOfType<LevelManager> ();
		//transform.position = new Vector2(transform.position.x,popBefore);
        check = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (player.transform.position.x >= transform.position.x)
            {
				check = true;
				transform.position = new Vector2(transform.position.x,popBefore);
				levelManager.RespawnPlayer ();
            }
        }
    }

    // Update is called once per frame
    void Update () {
		StartCoroutine (deathDelay());
    }

	IEnumerator deathDelay(){
		if (player.transform.position.x >= transform.position.x)
		{
			if (check == true) {
				transform.position = new Vector2 (transform.position.x, popAfter);
				print ("Posisi Spikes" + transform.position.y);
				yield return new WaitForSeconds (delay);
				check = false;
			}
		}else

			if (player.transform.position.x <= transform.position.x) {
				transform.position = new Vector2 (transform.position.x, popBefore);
				check = true;
				yield return new WaitForSeconds (delay);
			}
	}
}
