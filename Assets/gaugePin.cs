using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gaugePin : MonoBehaviour
{
    private float rotation;
    private float prevRot;
    private float maxRotation = -240;


    // Use this for initialization
    void Start()
    {
        prevRot = 0;
        rotation = 0;
        Locator.GetGauge().Add();
        Locator.GetGauge().Add();
        Locator.GetGauge().Add();
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
    }
}
