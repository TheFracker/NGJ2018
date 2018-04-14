using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerDoorOpen : MonoBehaviour
{
    private bool _onCollider;
    private bool _buttonDown;
    public float HoldTime = 2f;
    public string Player;
    public bool Lower = false;

    // Use this for initialization
    void Start()
    {
        _onCollider = false;

        Player = transform.name.Remove(0, transform.name.Length - 1);
    }
    
    void Update()
    {
        if (Input.GetButtonUp($"Player{Player}Inter1"))
        {
            _buttonDown = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "doorButton" + (Lower ? "Lower" : "Upper"))
        {
            _onCollider = true;
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "door" && Input.GetButtonDown($"Player{Player}Inter1"))
        {
            var s = other.gameObject.transform.GetComponentInParent<Door>();
            if (s == null) return;
            _buttonDown = true;
            StartCoroutine(ButtonDownTime(HoldTime, s.DoorOpen));
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            _onCollider = false;
        }
    }

    IEnumerator ButtonDownTime(float holdTime, Action callback)
    {
        var startTime = Time.time;
        while (_buttonDown && Time.time - startTime < holdTime && _onCollider)
        {
            yield return null;
        }
        yield return null;
        if (_buttonDown && Time.time - startTime >= holdTime && _onCollider)
            callback();
    }
}
