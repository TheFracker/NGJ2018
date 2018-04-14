﻿
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Menu : MonoBehaviour
{

    bool onStart;
    bool onQuit;
    bool gameStarting;
    bool something;
    public GameObject btnStart;
    public GameObject btnStartHover;
    public GameObject btnStartPress;
    public GameObject btnQuit;
    public GameObject btnQuitHover;
    public GameObject btnQuitPress;
    private List<AudioSource> _clips = new List<AudioSource>(6);
    private int __clipNumber;
    private int _clipNumber { get { return __clipNumber; } set { __clipNumber = value % 6; }}

    public AudioClip clip1;
    public AudioClip clip2;
    public AudioClip clip3;
    public AudioClip clip4;
    public AudioClip clip5;
    public AudioClip clip6;

    // Use this for initialization
    void Start()
    {
        btnQuitHover.SetActive(false);
        btnStartHover.SetActive(true);
        btnStartPress.SetActive(false);
        btnQuitPress.SetActive(false);


        for (int i = 0; i < 6; i++)
        {
            _clips.Add(gameObject.AddComponent<AudioSource>());
        }

        print(_clips == null);
        print(_clips[0] == null);
        print(clip1 == null);
        _clips[0].clip = clip1;
        _clips[1].clip = clip2;
        _clips[2].clip = clip3;
        _clips[3].clip = clip4;
        _clips[4].clip = clip5;
        _clips[5].clip = clip6;

        _clipNumber = 0;


     
    }

    // Update is called once per frame

    void Update()
    {


        if (Input.GetAxis("Vertical") < 0 && onStart == false)
        {
            print("going up");
            onStart = true;
            onQuit = false;
            btnStart.SetActive(false);
            btnStartHover.SetActive(true);
            btnQuitHover.SetActive(false);
            btnQuit.SetActive(true);
            //print(Input.GetAxis("Vertical"));
            _clips[_clipNumber++].Play();


        }

        if (Input.GetAxis("Vertical") > 0 && onQuit == false)
        {
            print("going down");
            onQuit = true;
            onStart = false;
            btnStart.SetActive(true);
            btnStartHover.SetActive(false);
            btnQuitHover.SetActive(true);
            btnQuit.SetActive(false);
            print(_clipNumber);
            _clips[_clipNumber++].Play();

            //print(Input.GetAxis("Vertical"));

        }

        if (onStart && Input.GetButtonDown("Player1Inter1"))
        {
            btnStartPress.SetActive(true);
            btnStartHover.SetActive(false);
            Invoke("starting", 1);



        }
        if (onQuit && Input.GetButtonDown("Player1Inter1"))
        {
            btnQuitPress.SetActive(true);
            btnQuitHover.SetActive(false);
            Invoke("quitting", 1);

        }

    }

    void quitting()
    {
        print("Quiting");
        Application.Quit();
    }

    void starting()
    {
        print("Starting Final");
        SceneManager.LoadScene("Christopher Scene"); //STARTING SCENE
    }
}