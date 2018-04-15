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

    Animator anim;
    [SerializeField]
    bool tempBool;
    public bool HoleFixed { get { return tempBool; } private set { tempBool = value; } }

    // Use this for initialization
    void Start()
    {
        anim = this.gameObject.GetComponent<Animator>();
        breakingAudio = gameObject.AddComponent<AudioSource>();
        runningWaterAudio = gameObject.AddComponent<AudioSource>();

        breakingAudio.clip = breakingSounds[Random.Range(0, breakingSounds.Count)];
        breakingAudio.PlayOneShot(breakingAudio.clip);

        runningWaterAudio.clip = runningWaterSounds[Random.Range(0, runningWaterSounds.Count)];
        print(runningWaterAudio.clip);
        runningWaterAudio.PlayDelayed(0.5f);
    }

    private void Update()
    {
        if(HoleFixed == true)
        {
            HoleRepaird();
        }
    }

    public void HoleRepaird()
    {
        anim.SetBool("HoleFixed", HoleFixed);
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
