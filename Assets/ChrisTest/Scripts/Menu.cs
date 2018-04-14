using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {

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





	// Use this for initialization
	void Start () {
        btnQuitHover.SetActive(false);
        btnStartHover.SetActive(true);
        btnStartPress.SetActive(false);
        btnQuitPress.SetActive(false);

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

        if(onStart && Input.GetButtonDown("Player1Inter1"))
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
       // SceneManager.LoadScene("Scene"); //STARTING SCENE
    }
}
