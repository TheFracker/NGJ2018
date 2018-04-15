using System.Collections;
using System;
using MEC;
using UnityEngine;
using UnityEngine.UI;

public class PlayerDoorSwitch : MonoBehaviour
{
    private bool _onCollider;
    private bool _buttonDown;
    public float HoldTime = 2f;
    public bool Lower = false;
    public string Player;
    private string _tag;

    public SpriteRenderer oButton;
    public SpriteRenderer xButton;
    public Image progressBar;

    // Use this for initialization
    void Start()
    {
        Player = transform.name.Remove(0, transform.name.Length - 1);
        _tag = "doorButton" + (Lower ? "Lower" : "Upper");

        oButton.enabled = false;
        xButton.enabled = false;
        progressBar.enabled = false;
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
        if (other.gameObject.tag == _tag)
        {
            var s = other.gameObject.transform.GetComponentInChildren<DoorSwitch>();
            if (s == null) return;
            oButton.enabled = s.DoorsBroken;
            if (Input.GetButtonDown($"Player{Player}Inter2"))
            {
                _buttonDown = true;
                StartCoroutine(ButtonDownTime(HoldTime, (f, c) => s.Repair(f, c), s.DoorRepair, s));
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == _tag)
        {
            _onCollider = false;
            oButton.enabled = false;
            progressBar.enabled = false;
        }
    }

    IEnumerator ButtonDownTime(float holdTime, Func<float, Action, string> callback, Action call, IRepairProgress prog)
    {
        var routineTag = callback(holdTime, call);
        print(routineTag);
        var startTime = Time.time;
        progressBar.fillAmount = 0;
        progressBar.enabled = true;
        while (_buttonDown && Time.time - startTime < holdTime && _onCollider)
        {
            progressBar.fillAmount = prog.Progress;
            yield return null;
        }

        progressBar.enabled = false;

        yield return null;
        if (!(_buttonDown && Time.time - startTime < holdTime && _onCollider))
            Timing.KillCoroutines(routineTag);
    }
}
