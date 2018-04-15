using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class scoreScript : MonoBehaviour {

    public static float scoreValue = 0;
    Text score; 
	// Use this for initialization
	void Start () {
        score = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        scoreValue = Mathf.Round(Time.timeSinceLevelLoad);
        score.text = "Time Survived: " + scoreValue;
		
	}
}
