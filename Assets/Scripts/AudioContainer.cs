using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AudioContainer : MonoBehaviour
{
    [SerializeField]
    List<string> Keys;
    [SerializeField]
    List<AudioClip> Values;

    private void Awake()
    {
        foreach (var item in Values)
        {
            Keys.Add(item.name);
        }
    }

    public AudioClip GetAudioClip(string audioClip)
    {
        if (Keys.Count != Values.Count)
            throw new Exception("Mismatch with keys and values");

        if (Keys.Contains(audioClip))
        {
            var i = Keys.IndexOf(audioClip);
            return Values[i];
        }
        return null;
    }
}
