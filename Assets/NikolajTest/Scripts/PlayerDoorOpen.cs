using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerDoorOpen : MonoBehaviour
{
    public bool onCollider;
    private bool buttonDown;
    public float holdTime = 2f;
    public string player;
    public bool lower = false;

    // Use this for initialization
    void Start()
    {
        onCollider = false;

        player = transform.name.Remove(0, transform.name.Length - 1);
    }

    // Update is called once per frame
    void Update()
    {
        if (onCollider && Input.GetButtonDown("Player1Inter1"))
        {
            buttonDown = true;
        }
        if (Input.GetButtonUp("Player1Inter1"))
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
        if ((Input.GetButtonDown($"Player{player}Inter1")))
        {
            var s = other.gameObject.transform.GetComponentInParent<Door>();
            buttonDown = true;
            StartCoroutine(buttonDownTime(holdTime, s.DoorOpen));
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            onCollider = false;
            print("Exited");
        }
    }

    IEnumerator buttonDownTime(float holdTime, Action callback)
    {
        var startTime = Time.time;
        while (buttonDown && Time.time - startTime < holdTime)
        {
            yield return null;
        }
        yield return null;
        if (buttonDown && (Time.time - startTime >= holdTime))
            callback();
    }
}
