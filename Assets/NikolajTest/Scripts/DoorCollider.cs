using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MEC;

public class DoorCollider : MonoBehaviour
{
    private bool _broken;
    public bool doorCollider;
    public bool open;
    public bool broken
    {
        get { return _broken; }
        set
        {
            _broken = value;
            if (!_broken)
                open = true;
        }
    }
    public SpriteRenderer thisSpriteRenderer;
    public Sprite doorOpen;
    public Sprite doorClosed;
    private bool buttonDown;
    public float holdTime = 2f;

    // Use this for initialization
    void Start()
    {
        thisSpriteRenderer = GetComponent<SpriteRenderer>();
        doorCollider = false;
        open = true;
        broken = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!broken) return;

        if (doorCollider && Input.GetButtonDown("Fire1"))
        {
            buttonDown = true;
            StartCoroutine(buttonDownTime(holdTime));
        }
        if (Input.GetButtonUp("Fire1"))
        {
            buttonDown = false;
        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            doorCollider = true;
            print("triggered");
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            doorCollider = false;
            print("Exited");
            StartCoroutine(CloseDoor(1f));
        }
    }

    IEnumerator buttonDownTime(float holdTime)
    {
        var startTime = Time.time;
        print(buttonDown && Time.time - startTime < holdTime);
        while (buttonDown && Time.time - startTime < holdTime)
        {
            yield return null;
        }
        yield return null;
        if (buttonDown && (Time.time - startTime >= holdTime))
            open = true;
    }

    IEnumerator CloseDoor(float openTime)
    {
        var startTime = Time.time;
        yield return new WaitForSeconds(openTime);
        open = false;
    }
}
