using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoleScript : Repairable
{
    AudioSource breakingAudio;
    [SerializeField]
    List<AudioClip> breakingSounds;
    AudioSource runningWaterAudio;
    [SerializeField]
    List<AudioClip> runningWaterSounds;
    AudioSource repairAudio;
    [SerializeField]
    AudioClip repairSound;

    Animator anim;
    [SerializeField]
    bool tempBool;
    public bool HoleFixed { get { return tempBool; } private set { tempBool = value; } }

    // Use this for initialization
    void Start()
    {
        anim = this.gameObject.GetComponent<Animator>();
        breakingAudio = gameObject.AddComponent<AudioSource>();
        breakingAudio.playOnAwake = false;
        runningWaterAudio = gameObject.AddComponent<AudioSource>();
        runningWaterAudio.playOnAwake = false;
        repairAudio = gameObject.AddComponent<AudioSource>();
        repairAudio.playOnAwake = false;

        breakingAudio.clip = breakingSounds[Random.Range(0, breakingSounds.Count)];
        breakingAudio.PlayOneShot(breakingAudio.clip);

        runningWaterAudio.clip = runningWaterSounds[Random.Range(0, runningWaterSounds.Count)];
        runningWaterAudio.PlayDelayed(0.5f);
    }

   

    public void HoleRepaird()
    {
        HoleFixed = true;
        anim.SetBool("HoleFixed", HoleFixed);
        runningWaterAudio.Stop();
        repairAudio.clip = repairSound;
        repairAudio.PlayOneShot(repairAudio.clip);
        StartCoroutine("Fade");
    }

    IEnumerator Fade()
    {


        var sr = GetComponent<SpriteRenderer>();
        for (float f = 1f; f >= 0.2; f -= 0.1f*Time.deltaTime)
        {
            
            sr.color = new Color(GetComponent<SpriteRenderer>().color.r, GetComponent<SpriteRenderer>().color.g, GetComponent<SpriteRenderer>().color.b, f);
            yield return null;
        }
        Destroy(this.gameObject,1);
    }
}
