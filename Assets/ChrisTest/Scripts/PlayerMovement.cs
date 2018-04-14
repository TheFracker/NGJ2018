
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public float Speed;             //Floating point variable to store the player's movement speed.

    private Rigidbody2D _rb2D;       //Store a reference to the Rigidbody2D component required to use 2D Physics.

    bool _movingRight;
    public int PlayerNumber { get; private set; }

    // Use this for initialization
    void Start()
    {
        PlayerNumber = int.Parse(transform.name.Remove(0, transform.name.Length - 1));

        //Get and store a reference to the Rigidbody2D component so that we can access it.
        _rb2D = GetComponent<Rigidbody2D> ();
    }

    //FixedUpdate is called at a fixed interval and is independent of frame rate. Put physics code here.
    void FixedUpdate()
    {
        //Store the current horizontal input in the float moveHorizontal.
        float moveHorizontal = Input.GetAxis ($"Horizontal{PlayerNumber}");

        //Store the current vertical input in the float moveVertical.
        float moveVertical = 0;

        //Use the two store floats to create a new Vector2 variable movement.
        Vector2 movement = new Vector2 (moveHorizontal, moveVertical);

        //Call the AddForce function of our Rigidbody2D rb2d supplying movement multiplied by speed to move our player.
        _rb2D.AddForce (movement * Speed);

        if ( moveHorizontal <0 && !_movingRight)
        {
            
            transform.localScale = new Vector2(transform.localScale.x * -1,transform.localScale.y);
            _movingRight = true;
        }

        else if (moveHorizontal > 0 && _movingRight)
        {
            transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
            _movingRight = false;
        }
    }
}
