using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public SpriteRenderer thisSpriteRenderer;
    public Sprite doorOpen;
    public Sprite doorClosed;
    private DoorCollider _collider;

    // Use this for initialization
    void Start()
    {
        thisSpriteRenderer = GetComponent<SpriteRenderer>();
        _collider = GetComponentInChildren<DoorCollider>();
    }

    void Update()
    {
        if (_collider.open)
        {
            thisSpriteRenderer.sprite = doorOpen;
            GetComponent<BoxCollider2D>().enabled = false;
        }
        else if (!_collider.open)
        {
            thisSpriteRenderer.sprite = doorClosed;
            GetComponent<BoxCollider2D>().enabled = true;
        }
    }
}
