using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gaugePin : MonoBehaviour
{
    private float rotation;
    private float prevRot;
    private float maxRotation = -240;
    bool end = false;
    public GameObject gameOver;

    // Use this for initialization
    void Start()
    {
        gameOver.SetActive(false);
        end = false; 
        prevRot = 0;
        rotation = 0;
        
    }

    // Update is called once per frame
    void Update()
    {
        rotation = maxRotation * Locator.GetGauge().FailurePercentage;
        if (rotation != prevRot)
        {
            this.transform.Rotate(0, 0, rotation - prevRot);
            prevRot = rotation;
        }
        if (Input.GetKeyDown(KeyCode.M))
            Locator.GetGauge().Add();

        if (!end && Locator.GetGauge().FailureCounter == Locator.GetGauge().MaxFailures) {
            end = true;
            gameOver.SetActive(true);
            SceneManager.LoadScene("GameOver");
            
        }
    }
    
}
