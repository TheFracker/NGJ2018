﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGrabber : MonoBehaviour
{
    public bool Grabbed { get; private set; }

    RaycastHit2D _hit;
    public Transform OtherConsolePoint;
    public float Distance = 1f;
    public bool PlayerOnConsol;
    public GameObject Consol;
    public GameObject Kit;
    public LayerMask Mask = 8;
    public int PlayerNumber { get; private set; }
    public AudioClip starFishPickUp;
    public AudioClip sendStarFish;

    private List<AudioSource> _clips = new List<AudioSource>(2);
    public SpriteRenderer xButton;


    void Start()
    {
        PlayerNumber = int.Parse(transform.name.Remove(0, transform.name.Length - 1));
        for (int i = 0; i < 2; i++)
        {
            _clips.Add(gameObject.AddComponent<AudioSource>());
        }

        _clips[0].clip = starFishPickUp;
        _clips[1].clip = sendStarFish;

        print(xButton == null);
        if (xButton != null)
            xButton.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!Grabbed)
        {
            _hit = Physics2D.Raycast(new Vector2(transform.position.x + Distance, transform.position.y),
                transform.position, Distance, Mask.value);
            if (_hit == false)
            {
                _hit = Physics2D.Raycast(new Vector2(transform.position.x - Distance, transform.position.y),
                    transform.position, Distance, Mask.value);
            }


            if (_hit.collider != null && !Grabbed)
            {
                if (xButton != null)
                    xButton.enabled = true;
            }
            else
            {
                if (xButton != null)
                    xButton.enabled = false;
            }
        }

        if (Grabbed && !PlayerOnConsol) xButton.enabled = false;

        if (Input.GetButtonDown($"Player{PlayerNumber}Inter1"))
        {
            if (!Grabbed)
            {
                if (_hit.collider != null)
                {
                    Grabbed = true;
                    GetComponent<Animator>().SetBool("carringStarFish", Grabbed);
                    _clips[0].Play();
                }
                //grab
            }
            else if (_hit.collider.gameObject.GetComponent<Rigidbody2D>() != null)
            {
                //throw
                Grabbed = false;
                GetComponent<Animator>().SetBool("carringStarFish", Grabbed);

                if (PlayerOnConsol)
                {
                    _hit.collider.gameObject.SetActive(true);
                    _clips[1].Play();
                    _hit.collider.gameObject.transform.position = new Vector2(OtherConsolePoint.position.x, OtherConsolePoint.position.y);
                }
                else
                {
                    _hit.collider.gameObject.SetActive(true);
                    _hit.collider.gameObject.transform.position = new Vector2(this.transform.position.x, this.transform.position.y);
                    _clips[0].Play();
                }

                _hit.collider.gameObject.GetComponent<BoxCollider2D>().isTrigger = false;
            }
        }

        if (Grabbed && _hit.collider != null)
        {
            _hit.collider.gameObject.SetActive(false);
            _hit.collider.gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject == Consol)
        {
            PlayerOnConsol = true;
            if (xButton != null)
            {
                xButton.enabled = Grabbed;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        PlayerOnConsol = false;
    }
}
