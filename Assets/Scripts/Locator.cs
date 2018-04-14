using UnityEngine;

public class Locator
{
    private static IAudio _audio;
    private static IGauge _gauge;
    private static AudioContainer _audioContainer;
    
    public static void Initialize()
    {
        _audio = new Audio();
        _gauge = new Gauge(10, 2);
        _audioContainer = GameObject.FindObjectOfType<AudioContainer>();
    }

    public static IAudio GetAudio()
    {
        return _audio;
    }

    public static IGauge GetGauge()
    {
        return _gauge;
    }

    public static AudioContainer GetAudioContainer()
    {
        return _audioContainer;
    }

    public static void Provide(IAudio audio)
    {
        _audio = audio;
    }

    public static void Provide(IGauge gauge)
    {
        _gauge = gauge;
    }
}
