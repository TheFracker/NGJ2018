using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour {

    bool onStart;
    bool onQuit;
    bool gameStarting;
    bool something;
    public GameObject btnStart;
    public GameObject btnStartHover;
    public GameObject btnQuit;
    public GameObject btnQuitHover;


	// Use this for initialization
	void Start () {
        btnQuitHover.SetActive(false);
        btnStartHover.SetActive(true);
	}
	
	// Update is called once per frame
	void Update () {


        if (Input.GetAxis("Vertical") < 0)
        {
            print("going up");
            onStart = true;
            onQuit = false;
            btnStart.SetActive(false);
            btnStartHover.SetActive(true);
            btnQuitHover.SetActive(false);
            btnQuit.SetActive(true);
            //print(Input.GetAxis("Vertical"));
        }

        if (Input.GetAxis("Vertical") > 0)
        {
            print("going down");
            onQuit = true;
            onStart = false;
            btnStart.SetActive(true);
            btnStartHover.SetActive(false);
            btnQuitHover.SetActive(true);
            btnQuit.SetActive(false);

            //print(Input.GetAxis("Vertical"));
        }





        print("start is " + onStart);
        print("quit is " + onQuit);
		
	}
}
