using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLightSwitch : MonoBehaviour
{
    private bool _onCollider;
    private bool _buttonDown;
    public float HoldTime = 2f;
    public bool Lower = false;
    public string Player;
    private string _tag;

    // Use this for initialization
    void Start()
    {
        _tag = "lightSwitch" + (Lower ? "Lower" : "Upper");
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
        if (other.gameObject.tag == _tag)
        {
            _onCollider = true;
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == _tag && Input.GetButtonDown($"Player{Player}Inter1"))
        {
            var s = other.gameObject.transform.GetComponentInChildren<LightSwitch>();
            if (s == null) return;
            _buttonDown = true;
            StartCoroutine(ButtonDownTime(HoldTime, x => s.Repair(x)));
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == _tag)
        {
            _onCollider = false;
        }
    }

    IEnumerator ButtonDownTime(float holdTime, Action<float> callback)
    {
        var startTime = Time.time;

        while (_buttonDown && Time.time - startTime < holdTime && _onCollider)
        {
            yield return null;
        }
        yield return null;
        if (_buttonDown && (Time.time - startTime >= holdTime) && _onCollider)
            callback(1);
    }
}
