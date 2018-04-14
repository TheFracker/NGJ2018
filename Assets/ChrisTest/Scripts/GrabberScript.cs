﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabberScript : MonoBehaviour {

	public string playerInter1;
	private bool grabbed;

	RaycastHit2D hit;
	public Transform holdPoint;
    public Transform otherConsolePoint;
	public float distance = 2f;
    public float throwForce = 2f;
    public bool playerOnConsol;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        
		
		if (Input.GetButtonDown("Fire1"))
		{
			if(!grabbed)
			{
				Physics2D.queriesStartInColliders = false;
				hit = Physics2D.Raycast(transform.position,Vector2.right*transform.localScale.x,distance);

				if(hit.collider != null)
				{
					grabbed = true;


				}
				//grab
			}
			else
			{
                //throw
                grabbed = false;
        

                if (hit.collider.gameObject.GetComponent<Rigidbody2D>() != null && playerOnConsol == true)
                {
                    hit.collider.gameObject.GetComponent<Rigidbody2D>().MovePosition(otherConsolePoint.position);
                    print("is trigger");
                }

                else
                    
                {
                    hit.collider.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(transform.localScale.x, 1) * throwForce;
                }

            

                hit.collider.gameObject.GetComponent<BoxCollider2D>().isTrigger = false;

				
			}
		}

		if(grabbed){
            hit.collider.gameObject.GetComponent<Rigidbody2D>().MovePosition(holdPoint.position);
            hit.collider.gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
         

		}
	}

	void onDrawGizmos()
	{
		Gizmos.color = Color.green;

		Gizmos.DrawLine(transform.position, transform.position+Vector3.right*transform.localScale.x*distance);
	}

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Consol")
        {
            playerOnConsol = true;
        }
    }

	private void OnTriggerExit2D(Collider2D other)
	{
        playerOnConsol = false;
	}
}