using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Manager : MonoBehaviour {

    [SerializeField]
    private List<GameObject> thingsThatBreakStuff;

    [SerializeField]
    float[] timerInterval;
    bool timeToBreakFound = false;
    float randomTimeToBreak;
    float timeStamp;

    float startIntervalMin = 7;
    float startIntervalMax = 10;
    float levelOfSpeed = 1;
    [SerializeField]
    float relativeTimeReductionPerLevel = 0.25f;

    private void Awake()
    {
        foreach (GameObject item in GameObject.FindGameObjectsWithTag("ThingsThatBreakStuff"))
        {
            thingsThatBreakStuff.Add(item);
        }
    }


    // Use this for initialization
    void Start () {
        timeStamp = Time.time;
        timerInterval = new float[2] { startIntervalMin, startIntervalMax };

    }
	
	// Update is called once per frame
	void Update () {

        if (!timeToBreakFound)
        {
            randomTimeToBreak = Random.Range(timerInterval[0], timerInterval[1]);
            print(randomTimeToBreak);
            timeToBreakFound = true;
        }
        else if (Time.time-timeStamp > randomTimeToBreak)
        {
            int whatToBreak = Random.Range(0, thingsThatBreakStuff.Count);
            thingsThatBreakStuff[whatToBreak].GetComponent<IBreakable>().Break();
            timeStamp = Time.time;
            Locator.GetGauge().Add();

            levelOfSpeed += relativeTimeReductionPerLevel;
            timerInterval[0] = startIntervalMin-Mathf.Sqrt(levelOfSpeed);
            timerInterval[1] = startIntervalMax - Mathf.Sqrt(levelOfSpeed);

            timeToBreakFound = false;
        }

		
	}
}
