﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabberScriptPlayerTwo: MonoBehaviour
{

    public string playerInter1;
    private bool grabbed;

    RaycastHit2D hit2;
    public Transform holdPoint;
    public Transform otherConsolePoint1;
    public float distance = 2f;
    public float throwForce = 2f;
    public bool playerOnConsol;
    public GameObject consol;
    public GameObject kit;
    public  LayerMask mask = 8;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    // Update is called once per frame
    void FixedUpdate()
    {


        if (Input.GetButtonDown("Player2Inter1"))
        {
            if (!grabbed)
            {
                Physics2D.queriesStartInColliders = false;
                hit2 = Physics2D.Raycast(transform.position, Vector2.right * transform.localScale.x, distance, mask.value);

                if (hit2.collider != null )
                {
                    grabbed = true;
                    GetComponent<Animator>().SetBool("carringStarFish", grabbed);
                }
                //grab
            }
            else if(hit2.collider.gameObject.GetComponent<Rigidbody2D>() != null)
            {
                hit2.collider.gameObject.SetActive(true);
                //throw
                grabbed = false;
                GetComponent<Animator>().SetBool("carringStarFish", grabbed);


                if (playerOnConsol == true)
                {
                    
                    hit2.collider.gameObject.GetComponent<Rigidbody2D>().MovePosition(otherConsolePoint1.position);
                    print("is trigger");
                }

                else

                {
                    hit2.collider.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(transform.localScale.x, 1) * throwForce;
                }



                hit2.collider.gameObject.GetComponent<BoxCollider2D>().isTrigger = false;


            }
        }

        if (grabbed)
        {
            hit2.collider.gameObject.SetActive(false);
            hit2.collider.gameObject.GetComponent<BoxCollider2D>().isTrigger = true;


        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject == consol)
        {
            playerOnConsol = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        playerOnConsol = false;
    }
}
