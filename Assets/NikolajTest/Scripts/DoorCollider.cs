using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MEC;

public class DoorCollider : MonoBehaviour
{
    private bool _broken;
    public bool Open;
    public bool Broken
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
    IEnumerator Start()
    {
        yield return null;
        _door = GetComponentInParent<Door>();
        Broken = false;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (!Broken || other.gameObject.tag != "Player") return;
        StartCoroutine(CloseDoor(1f));
    }

    IEnumerator CloseDoor(float openTime)
    {
        yield return new WaitForSeconds(openTime);
        _door.DoorClosed();
    }
}
