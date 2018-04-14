using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoleScript : MonoBehaviour {

    AudioSource breakingAudio;
    [SerializeField]
    List<AudioClip> breakingSounds;
    AudioSource runningWaterAudio;
    [SerializeField]
    List<AudioClip> runningWaterSounds;

    Animator anim;
    [SerializeField]
    bool holeFixed;


    // Use this for initialization
    void Start() {

        anim = this.gameObject.GetComponent<Animator>();
        breakingAudio = gameObject.AddComponent<AudioSource>();
        runningWaterAudio = gameObject.AddComponent<AudioSource>();

        breakingAudio.clip = breakingSounds[Random.Range(0, breakingSounds.Count)];
        breakingAudio.PlayOneShot(breakingAudio.clip);

        runningWaterAudio.clip = runningWaterSounds[Random.Range(0, runningWaterSounds.Count)];
        print(runningWaterAudio.clip);
        runningWaterAudio.PlayDelayed(0.5f);

        
    }
	
	// Update is called once per frame
	void Update () {
        

	}

    void HoleRepaird()
    {
        anim.SetBool("HoleFixed", holeFixed);
    }
}
