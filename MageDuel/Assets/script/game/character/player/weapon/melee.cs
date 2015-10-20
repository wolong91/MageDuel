﻿using UnityEngine;
using System.Collections;

public class melee : weaponBase {
	
	BoxCollider myBC;
	// Use this for initialization
	void Awake () {
	
		myBC = GetComponent<BoxCollider> ();

	}

	void OnEnable()
	{
		//	rb.velocity = Vector3.zero;
		totalTime = Time.time + deSpawn_Time;
		myBC.enabled = true;

		
	}
	void OnDisable()
	{
		myBC.enabled = false;
	}

	// Update is called once per frame
	void Update () {
	
		if (deSpawn_Time == 0)//unlimited
			return;
		if(Time.time > totalTime)
		{
			//Debug.Log("false");
		
			gameObject.GetComponent<melee>().enabled = false;
		}
	}

	override protected void OnTriggerEnter(Collider other)
	{

       
       
        if (other.GetComponent<CharacterBase>() != null)//has a body
        {
            if (other.GetComponent<CharacterBase>().getEnemy().GetComponent<CharacterBase>().getCanCombo() == false)
            {
                other.GetComponent<CharacterBase>().getEnemy().GetComponent<CharacterBase>().setCanCombo(true);
                other.GetComponent<CharacterBase>().getEnemy().GetComponent<CharacterBase>().setFirstCoolDownMeleeTimer();

            }
            
            if (other.GetComponent<CharacterBase>().getIsBlocking() == false)
            {
                other.GetComponent<CharacterBase>().setStunRate(3);
            }
            
        }
        base.OnTriggerEnter(other);

        gameObject.GetComponent<melee>().enabled = false;
      
        //if(other.GetComponent<CharacterBase>() != null)//has a body
        //{

        //	other.GetComponent<CharacterBase>().TakesDamage(damage);
        //	other.GetComponent<CharacterBase>().checkDead();

        //	other.GetComponent<Rigidbody>().AddForce(transform.forward * knockBack);
        //	gameObject.GetComponent<melee>().enabled = false;
        //}
    }
}



