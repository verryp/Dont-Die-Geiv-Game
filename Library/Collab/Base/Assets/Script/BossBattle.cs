using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBattle : MonoBehaviour {

    public float hp = 100;
    public Transform[] spots;
    public float speed;
    public Transform[] holes;
    public GameObject projectile;
    public Rigidbody2D rbd;
    public Player player;
    Vector3 playerPos;

    public Sprite[] sprites;
    public bool vulnarable;
    bool dead;
    public GameObject explossion;
	// Use this for initialization
	void Start () {
        StartCoroutine(boss());
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        rbd = gameObject.GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {

        if (hp <= 0 && !dead)
        {
            dead = true;
            GetComponent<SpriteRenderer>().color = Color.green;
            StartCoroutine("boss");
            Instantiate(explossion, transform.position, Quaternion.identity);
        }
	}
   
    IEnumerator boss()
    {
        while (true)
        {
            while(transform.position.x != spots[0].position.x)
             {
                 transform.position = Vector2.MoveTowards(transform.position, new Vector2(spots[0].position.x, transform.position.y), speed);
                 yield return null;
             }

             transform.localScale = new Vector2(2, 2);

             yield return new WaitForSeconds(1f);

             int i = 0;
             while (i < 6)
             {

                 GameObject bullet = Instantiate(projectile, holes[Random.Range(0, 2)].position, Quaternion.identity) as GameObject;
                 bullet.GetComponent<Rigidbody2D>().velocity = Vector2.left * 5;
                 i++;
                 yield return new WaitForSeconds(.7f);

             }

             //SECOND ATTACK
             rbd.isKinematic = true;
             while (transform.position!= spots[2].position)
             {

                 transform.position = Vector2.MoveTowards(transform.position, spots[2].position, speed);
                 yield return null;
             }


             playerPos = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z);

             print(playerPos.x);
             yield return new WaitForSeconds(1f);
             print(player.transform.position.x);
             rbd.isKinematic = false;
             while (transform.position.x != player.transform.position.x)
             {
                 transform.position = Vector2.MoveTowards(transform.position, new Vector2(player.transform.position.x, transform.position.y), speed);
                 yield return null;
             }

             this.tag = "Untagged";
             GetComponent<SpriteRenderer>().sprite = sprites[1];
             vulnarable = true;
             yield return new WaitForSeconds(4f);

             this.tag = "deadly";
             GetComponent<SpriteRenderer>().sprite = sprites[0];
             vulnarable = false;

             //THIRD ATTACK
             Transform temp;
             if (transform.position.x > player.transform.position.x)
             {
                 temp = spots[1];
             }
             else
             {
                 temp = spots[0];
             }

             while (transform.position.x != temp.position.x)
             {
                 transform.position = Vector2.MoveTowards(transform.position, new Vector2(temp.position.x, transform.position.y), speed);
                 yield return null;
             }
            
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player" && vulnarable)
        {
            hp -= 30;
            vulnarable = false;
            GetComponent<SpriteRenderer>().sprite = sprites[0];
        }
    }
}
