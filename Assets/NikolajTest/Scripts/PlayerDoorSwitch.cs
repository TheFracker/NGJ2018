using System.Collections;
using System;
using MEC;
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
        if (Input.GetButtonUp($"Player{Player}Inter2"))
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
        if (other.gameObject.tag == "doorButton" + (Lower ? "Lower" : "Upper") && Input.GetButtonDown($"Player{Player}Inter2"))
        {
            var s = other.gameObject.transform.GetComponentInChildren<DoorSwitch>();
            if (s == null) return;
            _buttonDown = true;
            StartCoroutine(ButtonDownTime(HoldTime, (f,c) => s.Repair(f,c), s.DoorRepair));
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "doorButton" + (Lower ? "Lower" : "Upper"))
        {
            _onCollider = false;
        }
    }

    IEnumerator ButtonDownTime(float holdTime, Func<float,Action,string> callback, Action call)
    {
        var routineTag = callback(holdTime, call);
        print(routineTag);
        var startTime = Time.time;
        while (_buttonDown && Time.time - startTime < holdTime && _onCollider)
        {
            print("While");
            yield return null;
        }

        if (!(_buttonDown && Time.time - startTime < holdTime && _onCollider))
            Timing.KillCoroutines(routineTag);
    }
}
