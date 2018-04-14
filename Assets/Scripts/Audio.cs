using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using MEC;

public class Audio : IAudio
{
    private class source
    {
        public int number;
        public AudioSource audioSource;
        public bool inUse;
    }
    
    private List<source> _sources = new List<source>(8);
    private GameObject _audioGameObject;

    public Audio()
    {
        _audioGameObject = GameObject.Find("Audio");
        if (_audioGameObject == null)
            _audioGameObject = new GameObject("Audio");


        for (var i = 0; i < 8; i++)
        {
            _sources.Add(new source
            {
                number = i,
                audioSource = _audioGameObject.AddComponent<AudioSource>(),
                inUse = false
            });
        }
        Debug.Log(_sources.Count());
    }

    public void Play(int track)
    {
        if (track < _sources.Count) return;
        if (_sources[track].audioSource.clip != null)
            _sources[track].audioSource.Play();
        else
            MonoBehaviour.print("No Audio to play");
    }

    public void Pause(int track)
    {
        _sources[track].audioSource.Pause();
    }

    public void Stop(int track)
    {
        _sources[track].audioSource.Stop();
    }

    public void Fade(int track, float time, bool fadeIn)
    {
        if (fadeIn)
        {
            Timing.RunCoroutine(FadeIn(track, time));
            Play(track);
        }
        else
        {
            Timing.RunCoroutine(FadeOut(track, time));
        }
    }

    public void LoopAudioClip(int track, bool loop)
    {
        _sources[track].audioSource.loop = loop;
    }

    public int SetAudioClip(AudioClip clip)
    {
        for (int i = 0; i < _sources.Count; i++)
        {
            if (!_sources[i].inUse)
            {
                _sources[i].audioSource.clip = clip;
                _sources[i].inUse = true;
                return i;
            }
        }

        return -1;
    }

    public void SetAudioClip(AudioClip clip, int track)
    {
        if (track < 2 || _sources.Count <= track) return;
        _sources[track].audioSource.clip = clip;
    }

    public void ReleaseAudioClip(int track)
    {
        if (track < _sources.Count)
            _sources[track].inUse = false;
    }

    public void Cross(float time, int track1, int track2)
    {
        if (_sources[track2].audioSource.clip == null)
            return;

        _sources[track2].audioSource.Play();

        Timing.RunCoroutine(Crossfade(time, track1, track2));
    }

    private IEnumerator<float> Crossfade(float time, int track1, int track2)
    {
        float startTime = Time.time;
        float endTime = startTime + time;
        while (Time.time <= endTime)
        {
            _sources[track1].audioSource.volume = 1 - ((Time.time - startTime) / time);
            _sources[track2].audioSource.volume = 1 - _sources[track1].audioSource.volume;

            yield return Timing.WaitForOneFrame;
        }
        _sources[track1].audioSource.volume = 0;
        _sources[track2].audioSource.volume = 1;
    }

    private IEnumerator<float> FadeOut(int track, float time)
    {
        float startTime = Time.time;
        float endTime = startTime + time;
        while (Time.time <= endTime)
        {
            //_sources[track].volume = 1 - Mathf.((Time.time - startTime) / time);
            _sources[track].audioSource.volume = Mathf.SmoothStep(0, 1, 1 - ((Time.time - startTime) / time));
            yield return Timing.WaitForOneFrame;
        }
        _sources[track].audioSource.volume = 0;
    }

    private IEnumerator<float> FadeIn(int track, float time)
    {
        float startTime = Time.time;
        float endTime = startTime + time;
        while (Time.time <= endTime)
        {
            //_sources[track].volume = 1 - Mathf.((Time.time - startTime) / time);
            _sources[track].audioSource.volume = Mathf.SmoothStep(1, 0, 1 - ((Time.time - startTime) / time));
            yield return Timing.WaitForOneFrame;
        }
        _sources[track].audioSource.volume = 1;
    }
}
