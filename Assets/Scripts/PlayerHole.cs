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
    public string Player;
    private string _tag = "hole";

    public SpriteRenderer oButton;
    public Image progressBar;

    // Use this for initialization
    void Start()
    {
        _onCollider = false;

        oButton.enabled = false;
        progressBar.enabled = false;

        Player = transform.name.Remove(0, transform.name.Length - 1);
    }

    void Update()
    {
        if (Input.GetButtonUp($"Player{Player}Inter2"))
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
            var hole = other.gameObject.transform.GetComponent<HoleScript>();
            if (hole == null) return;
            oButton.enabled = !hole.HoleFixed;
            if (Input.GetButtonDown($"Player{Player}Inter2"))
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
