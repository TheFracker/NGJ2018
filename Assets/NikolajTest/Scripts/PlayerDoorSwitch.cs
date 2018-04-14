using System.Collections;
using System;
using UnityEngine;

public class PlayerDoorSwitch : MonoBehaviour
{
    private bool onCollider;
    private bool buttonDown;
    public float holdTime = 2f;
    public bool lower = false;
    public string player;

    // Use this for initialization
    void Start()
    {
        player = transform.name.Remove(0, transform.name.Length - 1);
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetButtonUp($"Player{player}Inter1"))
        {
            buttonDown = false;
        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "doorButton" + (lower ? "Lower" : "Upper"))
        {
            onCollider = true;
            print("triggered");
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "doorButton" + (lower ? "Lower" : "Upper") && (Input.GetButtonDown($"Player{player}Inter1")))
        {
            var s = other.gameObject.transform.GetComponentInChildren<DoorSwitch>();
            buttonDown = true;
            StartCoroutine(buttonDownTime(holdTime, s.DoorRepair));
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "doorButton" + (lower ? "Lower" : "Upper"))
        {
            onCollider = false;
            print("Exited");
        }
    }

    IEnumerator buttonDownTime(float holdTime, Action callback)
    {
        var startTime = Time.time;

        while (buttonDown && Time.time - startTime < holdTime && onCollider)
        {
            yield return null;
        }
        yield return null;
        if (buttonDown && (Time.time - startTime >= holdTime) && onCollider)
            callback();
    }

}
