using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack_Come : MonoBehaviour {

    public Turret turretAI;

    public bool isLeft = false;

    private void Awake()
    {
        turretAI = gameObject.GetComponentInParent<Turret>();
    }

    private void OnTriggerStay2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            if(isLeft)
            {
                turretAI.attack(false);
            }
            else
            {
                turretAI.attack(true);
            }
        }
    }
}
