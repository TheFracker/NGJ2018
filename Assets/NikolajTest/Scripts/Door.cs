using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Door : Repairable
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
        DoorOpen();
    }

    public void DoorOpen()
    {
        print(anim == null);
        anim.SetBool("DoorOpen", true);
        //thisSpriteRenderer.sprite = doorOpen;
        GetComponent<BoxCollider2D>().enabled = false;

        if (openAudio != null && openAudio.Any())
        {
            doorOpenAudio.clip = openAudio[Random.Range(0, openAudio.Count)];
            doorOpenAudio.PlayOneShot(doorOpenAudio.clip);
        }
    }

    public void DoorClosed()
    {
        print("Closing");
        anim.SetBool("DoorOpen", false);
        //thisSpriteRenderer.sprite = doorClosed;
        GetComponent<BoxCollider2D>().enabled = true;

        if (closeAudio != null && closeAudio.Any())
        {
            doorCloseAudio.clip = closeAudio[Random.Range(0, closeAudio.Count)];
            doorCloseAudio.PlayOneShot(doorOpenAudio.clip);
        }
    }
}
