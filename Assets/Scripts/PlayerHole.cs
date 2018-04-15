using System;
using System.Collections;
using System.Collections.Generic;
using MEC;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHole : MonoBehaviour
{
    private bool _onCollider;
    private bool _buttonDown;
    public float HoldTime = 2f;
    public string PlayerNumber;
    private string _tag = "hole";
    private PlayerGrabber _grabber;

    public SpriteRenderer oButton;
    public Image progressBar;

    // Use this for initialization
    void Start()
    {
        _onCollider = false;

        oButton.enabled = false;
        progressBar.enabled = false;
        _grabber = GetComponent<PlayerGrabber>();

        PlayerNumber = transform.name.Remove(0, transform.name.Length - 1);
    }

    void Update()
    {
        if (Input.GetButtonUp($"Player{PlayerNumber}Inter2"))
        {
            _buttonDown = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == _tag)
        {
            print("enter");
            _onCollider = true;
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == _tag)
        {
            print("staying");
            var hole = other.gameObject.GetComponent<HoleScript>();
            if (hole == null || !_grabber.Grabbed) return;
            print("Should press");
            oButton.enabled = !hole.HoleFixed;
            if (Input.GetButtonDown($"Player{PlayerNumber}Inter2"))
            {
                _buttonDown = true;
                StartCoroutine(ButtonDownTime(HoldTime, (f, c) => hole.Repair(f, c), hole.HoleRepaird, hole));
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
