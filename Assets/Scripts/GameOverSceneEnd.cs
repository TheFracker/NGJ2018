using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverSceneEnd : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Invoke("changeScene", 13);
	}

    void changeScene()
    {
        SceneManager.LoadScene("Menu"); //STARTING SCENE
        print("Menu");
    }
}
