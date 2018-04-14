using System.Collections;
using System;
using UnityEngine;

public class PlayerDoorSwitch : MonoBehaviour
{
    private bool _onCollider;
    private bool _buttonDown;
    public float HoldTime = 2f;
    public bool Lower = false;
    public string Player;

    // Use this for initialization
    void Start()
    {
        Player = transform.name.Remove(0, transform.name.Length - 1);
    }

    // Update is called once per frame
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
        if (other.gameObject.tag == "doorButton" + (Lower ? "Lower" : "Upper") && Input.GetButtonDown($"Player{Player}Inter1"))
        {
            var s = other.gameObject.transform.GetComponentInChildren<DoorSwitch>();
            if (s == null) return;
            _buttonDown = true;
            StartCoroutine(ButtonDownTime(HoldTime, s.DoorRepair));
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "doorButton" + (Lower ? "Lower" : "Upper"))
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
        if (_buttonDown && (Time.time - startTime >= holdTime) && _onCollider)
            callback();
    }

}
