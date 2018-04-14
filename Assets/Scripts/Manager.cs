using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour {

    private static int numberOfBrokenStuff;

    [SerializeField]
    private List<GameObject> thingsThatBreakStuff;


    float timeStamp;

	// Use this for initialization
	void Start () {
        thingsThatBreakStuff[0].GetComponent<IBreakable>().Break();
        timeStamp = Time.time;
		
	}
	
	// Update is called once per frame
	void Update () {
        print(Time.time - timeStamp);

		
	}
}
