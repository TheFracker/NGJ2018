using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour {

    bool onStart;
    bool onQuit;
    bool gameStarting;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        while (gameStarting == false)
        {

            if (Input.GetAxis("Vertical") < 0)
            {
                print("going up");
                //print(Input.GetAxis("Vertical"));
            }
            if (Input.GetAxis("Vertical") > 0)
            {
                print("going down");
                //print(Input.GetAxis("Vertical"));
            }
        }
		
	}
}
