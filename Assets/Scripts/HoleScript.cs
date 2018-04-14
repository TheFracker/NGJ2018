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


    // Use this for initialization
    void Start() {
        breakingAudio = gameObject.AddComponent<AudioSource>();
        runningWaterAudio = gameObject.AddComponent<AudioSource>();

        breakingAudio.clip = breakingSounds[Random.Range(0, breakingSounds.Count)];
        breakingAudio.PlayOneShot(breakingAudio.clip);

        runningWaterAudio.clip = breakingSounds[Random.Range(0, runningWaterSounds.Count)];
        runningWaterAudio.Play((uint)runningWaterAudio.clip.samples / 2);


    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
