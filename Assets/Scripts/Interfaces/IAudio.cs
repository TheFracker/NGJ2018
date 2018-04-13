using UnityEngine;

public interface IAudio
{
    void Play(int track);
    void Pause(int track);
    void Stop(int track);
    int SetAudioClip(AudioClip clip);
    void SetAudioClip(AudioClip clip, int track);
    void Cross(float time, int track1, int track2);
    void Fade(int track, float time, bool fadeIn);
    void LoopAudioClip(int track, bool loop);
}
