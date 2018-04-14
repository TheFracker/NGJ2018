﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public SpriteRenderer thisSpriteRenderer;
    [SerializeField]
    private Sprite doorOpen;
    [SerializeField]
    private Sprite doorClosed;

    AudioSource doorOpenAudio;
    [SerializeField]
    List<AudioClip> openAudio;
    AudioSource doorCloseAudio;
    [SerializeField]
    List<AudioClip> closeAudio;

    Animator anim;

    // Use this for initialization
    void Start()
    {
        thisSpriteRenderer = GetComponent<SpriteRenderer>();

        doorCloseAudio = gameObject.AddComponent<AudioSource>();
        doorOpenAudio = gameObject.AddComponent<AudioSource>();

        anim = this.gameObject.GetComponent<Animator>();
    }

    public void DoorOpen()
    {
        anim.SetBool("DoorOpen", true);
        //thisSpriteRenderer.sprite = doorOpen;
        GetComponent<BoxCollider2D>().enabled = false;
       
        doorOpenAudio.clip = openAudio[Random.Range(0, openAudio.Count)];
        doorOpenAudio.PlayOneShot(doorOpenAudio.clip);
    }

    public void DoorClosed()
    {
        anim.SetBool("DoorOpen", true);
        //thisSpriteRenderer.sprite = doorClosed;
        GetComponent<BoxCollider2D>().enabled = true;
        
        doorCloseAudio.clip = closeAudio[Random.Range(0, closeAudio.Count)];
        print(doorCloseAudio.clip);
        doorCloseAudio.PlayOneShot(doorOpenAudio.clip);
    }
}
