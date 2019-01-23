using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour {


    //Float
    public float distance;
    public float wakeRange;
    public float shootInterval;
    public float bulletSpeed = 100;
    public float bullettimer;

    //boolean
    public bool awake = false;
    public bool lookingRight = true;

    //references
    public GameObject bullet;
    public Transform target;
    public Animator anim;
    public Transform shootPointLeft;
    public Transform shootPointRight;

    void Awake()
    {
        anim = gameObject.GetComponent<Animator>(); 
    }

    void Start()
    {
		
    }

    void Update()
    {
        anim.SetBool("Awake", awake);
        anim.SetBool("LookingRight", lookingRight);

        RangeCheck();

        if(target.transform.position.x > transform.position.x)
        {
            lookingRight = true;
        }
        if(target.transform.position.x < transform.position.x)
        {
            lookingRight = false;
        }
    }

    void RangeCheck()
    {
        distance = Vector3.Distance(transform.position, target.transform.position);

        if(distance < wakeRange)
        {
            awake = true;
        }

        if(distance > wakeRange)
        {
            awake = false;
        }
    }

    public void attack(bool attackinRight)
    {
        bullettimer += Time.deltaTime;

        if (bullettimer >= shootInterval)
        {
            Vector2 direction = target.transform.position - transform.position;
            direction.Normalize();

            if(!attackinRight)
            {
                GameObject bulletClone;
                bulletClone = Instantiate(bullet, shootPointLeft.transform.position, shootPointLeft.transform.rotation) as GameObject;
                bulletClone.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;

                bullettimer = 0;

            }

            if(attackinRight)
            {
                GameObject bulletClone;
                bulletClone = Instantiate(bullet, shootPointRight.transform.position, shootPointRight.transform.rotation) as GameObject;
                bulletClone.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;

                bullettimer = 0;

            }

        }
    }
}
