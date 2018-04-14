
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public float Speed;             //Floating point variable to store the player's movement speed.
    public float maxSpeed;
    private List<AudioSource> _clips = new List<AudioSource>(13);

    public AudioClip clip1;
    public AudioClip clip2;
    public AudioClip clip3;
    public AudioClip clip4;
    public AudioClip clip5;
    public AudioClip clip6;
    public AudioClip clip7;
    public AudioClip clip8;
    public AudioClip clip9;
    public AudioClip clip10;
    public AudioClip clip11;
    public AudioClip clip12;
    public AudioClip clip13;
    float clipNumberF = 0f;
    int clipNumberI = 0;

    private Rigidbody2D _rb2D;       //Store a reference to the Rigidbody2D component required to use 2D Physics.

    bool _movingRight;
    public int PlayerNumber { get; private set; }

    // Use this for initialization
    void Start()
    {
        PlayerNumber = int.Parse(transform.name.Remove(0, transform.name.Length - 1));

        //Get and store a reference to the Rigidbody2D component so that we can access it.
        _rb2D = GetComponent<Rigidbody2D> ();

        for (int i = 0; i < 13; i++)
        {
            _clips.Add(gameObject.AddComponent<AudioSource>());
        }

        _clips[0].clip = clip1;
        _clips[1].clip = clip2;
        _clips[2].clip = clip3;
        _clips[3].clip = clip4;
        _clips[4].clip = clip5;
        _clips[5].clip = clip6;
        _clips[6].clip = clip7;
        _clips[7].clip = clip8;
        _clips[8].clip = clip9;
        _clips[9].clip = clip10;
        _clips[10].clip = clip11;
        _clips[11].clip = clip12;
        _clips[12].clip = clip13;


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
        

        if (_rb2D.velocity.x < maxSpeed && _rb2D.velocity.x > -maxSpeed)
        {
            _rb2D.AddForce(movement * Speed);

        }

        if(_rb2D.velocity.x > 0.5 && _rb2D.velocity.x < - 0.5)
        {
            walkingSound();
        }

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

    void walkingSound()
    {
        clipNumberF = Random.Range(0f, 13f);
        clipNumberI = Mathf.RoundToInt(clipNumberF);
        _clips[clipNumberI].Play();
    }
}
