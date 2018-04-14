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
            if (_broken)
                _door.DoorClosed();
            else
                _door.DoorOpen();
        }
    }
    private bool buttonDown;
    public float holdTime = 2f;
    private Door _door;

    // Use this for initialization
    void Start()
    {
        _door = GetComponentInParent<Door>();
        doorCollider = false;
        broken = false;
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
        if (!broken) return;
        if (other.gameObject.tag == "Player")
        {
            doorCollider = false;
            print("Exited");
            StartCoroutine(CloseDoor(1f));
        }
    }

    IEnumerator CloseDoor(float openTime)
    {
        var startTime = Time.time;
        yield return new WaitForSeconds(openTime);
        _door.DoorClosed();
    }
}
