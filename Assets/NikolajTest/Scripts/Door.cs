using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public SpriteRenderer thisSpriteRenderer;
    [SerializeField]
    private Sprite doorOpen;
    [SerializeField]
    private Sprite doorClosed;

    // Use this for initialization
    void Start()
    {
        thisSpriteRenderer = GetComponent<SpriteRenderer>();
    }

   /* void Update()
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
    }*/
    public void DoorOpen()
    {
        thisSpriteRenderer.sprite = doorOpen;
        GetComponent<BoxCollider2D>().enabled = false;

    }
    public void DoorClosed()
    {
        thisSpriteRenderer.sprite = doorClosed;
        GetComponent<BoxCollider2D>().enabled = true;
    }
}
